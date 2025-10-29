using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
    internal class DaoContasPagar : Dao
    {
        public DaoContasPagar() { }

        // ======================================================================
        // MÉTODOS CHAMADOS PELO NotaEntradaService (O "Maestro")
        // ======================================================================

        /// <summary>
        /// (Chamado pelo Service) Gera as parcelas no banco com base na Nota e Condição de Pagamento.
        /// </summary>
        public void GerarParcelas(NotaEntrada aNota, SqlConnection cnn, SqlTransaction transaction)
        {
            // Pega o valor total da nota (Produtos + Custos)
            decimal valorTotal = aNota.ValorTotalNota;

            // Loop nas parcelas da Condição de Pagamento
            foreach (ParcelaCondPag parcelaCond in aNota.ACondicaoPagamento.ParcelasCondPag)
            {
                string sql = @"
                    INSERT INTO CONTAS_A_PAGAR 
                        (NOTA_ENTRADA_ID, NUMERO_PARCELA, ID_FORNECEDOR, DATA_EMISSAO, DATA_VENCIMENTO, 
                         VALOR_PARCELA, ID_FORMA_PAGAMENTO, JUROS, MULTA, DESCONTO, ATIVO, SITUACAO)
                    VALUES
                        (@NotaId, @NumParcela, @FornecedorId, @DtEmissao, @DtVencimento, 
                         @ValorParcela, @FormaPagId, @Juros, @Multa, @Desconto, 1, 0)";

                using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
                {
                    // Calcula o valor da parcela baseado no percentual
                    decimal valorDaParcela = valorTotal * (parcelaCond.Percentual / 100);
                    // Calcula a data de vencimento (Emissão + Prazo em dias)
                    DateTime dtVencimento = aNota.DataEmissao.AddDays(parcelaCond.Prazo);

                    cmd.Parameters.AddWithValue("@NotaId", aNota.Id);
                    cmd.Parameters.AddWithValue("@NumParcela", parcelaCond.NumeroParcela);
                    cmd.Parameters.AddWithValue("@FornecedorId", aNota.OFornecedor.Id);
                    cmd.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                    cmd.Parameters.AddWithValue("@DtVencimento", dtVencimento);
                    cmd.Parameters.AddWithValue("@ValorParcela", valorDaParcela);
                    cmd.Parameters.AddWithValue("@FormaPagId", parcelaCond.AFormPag.Id);

                    // Pega Juros/Multa da Condição de Pagamento principal
                    cmd.Parameters.AddWithValue("@Juros", aNota.ACondicaoPagamento.Juro);
                    cmd.Parameters.AddWithValue("@Multa", aNota.ACondicaoPagamento.Multa);
                    cmd.Parameters.AddWithValue("@Desconto", aNota.ACondicaoPagamento.Desconto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// (Chamado pelo Service) Inativa (Cancela) todas as parcelas em aberto de uma Nota de Entrada.
        /// </summary>
        public void InativarParcelas(int notaEntradaId, string motivoCancelamento, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = @"
                UPDATE CONTAS_A_PAGAR 
                SET 
                    ATIVO = 0, 
                    MOTIVO_CANCELAMENTO = @Motivo,
                    DATA_ULTIMA_EDICAO = GETDATE()
                WHERE 
                    NOTA_ENTRADA_ID = @NotaId 
                    AND SITUACAO = 0"; // Só cancela o que está "Em Aberto"

            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@NotaId", notaEntradaId);
                cmd.Parameters.AddWithValue("@Motivo", (object)motivoCancelamento ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }


        // ======================================================================
        // MÉTODOS CHAMADOS PELA TELA DE CONTAS A PAGAR
        // ======================================================================

        /// <summary>
        /// Salva uma conta avulsa (INSERT) ou atualiza uma conta existente (UPDATE).
        /// Usado para "Dar Baixa" (pagar) ou editar uma conta avulsa.
        /// </summary>
        public override string Salvar(object obj)
        {
            ContasPagar conta = (ContasPagar)obj;
            string resultado = "";

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return "Erro ao conectar ao Banco de dados.";

                string sql;
                if (conta.Id == 0) // ID vem da classe Pai
                {
                    // --- INSERT (Conta Avulsa) ---
                    sql = @"
                        INSERT INTO CONTAS_A_PAGAR
                            (NOTA_ENTRADA_ID, NUMERO_PARCELA, ID_FORNECEDOR, DATA_EMISSAO, DATA_VENCIMENTO, 
                             VALOR_PARCELA, ID_FORMA_PAGAMENTO, JUROS, MULTA, DESCONTO, ATIVO, SITUACAO)
                        OUTPUT INSERTED.CONTA_PAGAR_ID
                        VALUES
                            (@NotaId, @NumParcela, @FornecedorId, @DtEmissao, @DtVencimento, 
                             @ValorParcela, @FormaPagId, @Juros, @Multa, @Desconto, @Ativo, @Situacao)";
                }
                else
                {
                    // --- UPDATE (Dar Baixa / Editar) ---
                    sql = @"
                        UPDATE CONTAS_A_PAGAR SET
                            NOTA_ENTRADA_ID = @NotaId,
                            NUMERO_PARCELA = @NumParcela,
                            ID_FORNECEDOR = @FornecedorId,
                            DATA_EMISSAO = @DtEmissao,
                            DATA_VENCIMENTO = @DtVencimento,
                            VALOR_PARCELA = @ValorParcela,
                            ID_FORMA_PAGAMENTO = @FormaPagId,
                            ATIVO = @Ativo,
                            SITUACAO = @Situacao,
                            JUROS = @Juros,
                            MULTA = @Multa,
                            DESCONTO = @Desconto,
                            VALOR_PAGO = @ValorPago,
                            DATA_PAGAMENTO = @DataPagamento,
                            MOTIVO_CANCELAMENTO = @MotivoCancelamento,
                            DATA_ULTIMA_EDICAO = GETDATE()
                        WHERE CONTA_PAGAR_ID = @ContaId";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    // Se for 0, salva como DBNull.Value (para contas avulsas)
                    cmd.Parameters.AddWithValue("@NotaId", conta.ANotaEntrada.Id == 0 ? DBNull.Value : (object)conta.ANotaEntrada.Id);
                    cmd.Parameters.AddWithValue("@FornecedorId", conta.OFornecedor.Id == 0 ? DBNull.Value : (object)conta.OFornecedor.Id);

                    cmd.Parameters.AddWithValue("@NumParcela", conta.NumeroParcela);
                    cmd.Parameters.AddWithValue("@DtEmissao", conta.DataEmissao);
                    cmd.Parameters.AddWithValue("@DtVencimento", conta.DataVencimento);
                    cmd.Parameters.AddWithValue("@ValorParcela", conta.ValorParcela);
                    cmd.Parameters.AddWithValue("@FormaPagId", conta.AFormaPagamento.Id);
                    cmd.Parameters.AddWithValue("@Ativo", conta.Ativo);
                    cmd.Parameters.AddWithValue("@Situacao", conta.Situacao);
                    cmd.Parameters.AddWithValue("@Juros", conta.Juros);
                    cmd.Parameters.AddWithValue("@Multa", conta.Multa);
                    cmd.Parameters.AddWithValue("@Desconto", conta.Desconto);

                    // Lida com valores Nulos
                    cmd.Parameters.AddWithValue("@ValorPago", conta.ValorPago == null ? DBNull.Value : (object)conta.ValorPago);
                    cmd.Parameters.AddWithValue("@DataPagamento", conta.DataPagamento == null ? DBNull.Value : (object)conta.DataPagamento);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", string.IsNullOrEmpty(conta.MotivoCancelamento) ? DBNull.Value : (object)conta.MotivoCancelamento);

                    if (conta.Id != 0)
                    {
                        cmd.Parameters.AddWithValue("@ContaId", conta.Id);
                    }

                    try
                    {
                        if (conta.Id == 0)
                            conta.Id = Convert.ToInt32(cmd.ExecuteScalar()); // Pega o novo ID
                        else
                            cmd.ExecuteNonQuery(); // Apenas atualiza

                        resultado = conta.Id.ToString();
                    }
                    catch (SqlException ex)
                    {
                        resultado = "Erro ao salvar conta: " + ex.Message;
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Lista todas as contas a pagar (para a tela de gerenciamento).
        /// </summary>
        public List<ContasPagar> Listar()
        {
            var lista = new List<ContasPagar>();
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) throw new Exception("Erro ao conectar ao Banco de dados.");

                string sql = @"
                    SELECT 
                        CP.*,
                        F.FORNECEDOR_NOME_RS,
                        FP.FORMAPAG_DESC,
                        NE.NOTA_ENTRADA_NUMERO
                    FROM CONTAS_A_PAGAR CP
                    LEFT JOIN FORNECEDOR F ON CP.ID_FORNECEDOR = F.FORNECEDOR_ID
                    LEFT JOIN FORMA_PAGAMENTO FP ON CP.ID_FORMA_PAGAMENTO = FP.FORMAPAG_ID
                    LEFT JOIN NOTA_ENTRADA NE ON CP.NOTA_ENTRADA_ID = NE.NOTA_ENTRADA_ID
                    WHERE CP.ATIVO = 1 
                    ORDER BY CP.DATA_VENCIMENTO";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ContasPagar conta = new ContasPagar();

                            conta.Id = Convert.ToInt32(dr["CONTA_PAGAR_ID"]);
                            conta.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                            conta.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                            conta.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                            conta.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                            conta.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                            conta.Situacao = Convert.ToInt32(dr["SITUACAO"]);
                            conta.Juros = Convert.ToDecimal(dr["JUROS"]);
                            conta.Multa = Convert.ToDecimal(dr["MULTA"]);
                            conta.Desconto = Convert.ToDecimal(dr["DESCONTO"]);

                            // Preenche campos nulos
                            conta.ValorPago = dr["VALOR_PAGO"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]);
                            conta.DataPagamento = dr["DATA_PAGAMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                            conta.MotivoCancelamento = dr["MOTIVO_CANCELAMENTO"] == DBNull.Value ? string.Empty : dr["MOTIVO_CANCELAMENTO"].ToString();

                            // Preenche objetos
                            if (dr["NOTA_ENTRADA_ID"] != DBNull.Value)
                            {
                                conta.ANotaEntrada.Id = Convert.ToInt32(dr["NOTA_ENTRADA_ID"]);
                                conta.ANotaEntrada.Numero = dr["NOTA_ENTRADA_NUMERO"].ToString();
                            }
                            if (dr["ID_FORNECEDOR"] != DBNull.Value)
                            {
                                conta.OFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                                conta.OFornecedor.NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString();
                            }
                            if (dr["ID_FORMA_PAGAMENTO"] != DBNull.Value)
                            {
                                conta.AFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                                conta.AFormaPagamento.Descricao = dr["FORMAPAG_DESC"].ToString();
                            }

                            lista.Add(conta);
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Exclusão lógica (Soft Delete) de uma conta.
        /// </summary>
        public override string Excluir(object obj)
        {
            ContasPagar conta = (ContasPagar)obj;
            string resultado = "";

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return "Erro ao conectar ao Banco de dados.";

                // Apenas inativa a conta (Soft Delete)
                string sql = @"
                    UPDATE CONTAS_A_PAGAR SET 
                        ATIVO = 0,
                        DATA_ULTIMA_EDICAO = GETDATE()
                    WHERE CONTA_PAGAR_ID = @ContaId";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ContaId", conta.Id);
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        resultado = rows > 0 ? "OK" : "Conta não encontrada.";
                    }
                    catch (SqlException ex)
                    {
                        resultado = "Erro ao excluir conta: " + ex.Message;
                    }
                }
            }
            return resultado;
        }
    }
}
