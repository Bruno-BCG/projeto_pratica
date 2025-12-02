using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
    internal class DaoContasReceber : Dao
    {
        public DaoContasReceber() { }

        /// <summary>
        /// Gera as parcelas de Contas a Receber a partir de uma Nota de Saída,
        /// com base nas parcelas da condição de pagamento da nota.
        /// SITUACAO: 0 = Em Aberto, 1 = Recebido, 2 = Cancelado.
        /// </summary>
        public void GerarParcelas(NotaSaida aNota, SqlConnection cnn, SqlTransaction transaction)
        {

            decimal valorTotal = aNota.SubTotalProdutos; 

            foreach (ParcelaCondPag parcelaCond in aNota.ACondicaoPagamento.ParcelasCondPag)
            {
                const string sql = @"
                    INSERT INTO CONTAS_A_RECEBER
                        (NOTA_SAIDA_ID, NUMERO_PARCELA, ID_CLIENTE, DATA_EMISSAO, DATA_VENCIMENTO,
                         VALOR_PARCELA, ID_FORMA_PAGAMENTO, JUROS, MULTA, DESCONTO, ATIVO, SITUACAO)
                    VALUES
                        (@NotaId, @NumParcela, @ClienteId, @DtEmissao, @DtVencimento,
                         @ValorParcela, @FormaPagId, @Juros, @Multa, @Desconto, 1, 0)";

                using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
                {
                    decimal valorDaParcela = valorTotal * (parcelaCond.Percentual / 100m);
                    DateTime dtVencimento = aNota.DataEmissao.AddDays(parcelaCond.Prazo);

                    cmd.Parameters.AddWithValue("@NotaId", aNota.Id);
                    cmd.Parameters.AddWithValue("@NumParcela", parcelaCond.NumeroParcela);
                    cmd.Parameters.AddWithValue("@ClienteId", aNota.OCliente.Id);
                    cmd.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                    cmd.Parameters.AddWithValue("@DtVencimento", dtVencimento);
                    cmd.Parameters.AddWithValue("@ValorParcela", valorDaParcela);
                    cmd.Parameters.AddWithValue("@FormaPagId", parcelaCond.AFormPag.Id);

                    cmd.Parameters.AddWithValue("@Juros", (decimal)aNota.ACondicaoPagamento.Juro);
                    cmd.Parameters.AddWithValue("@Multa", (decimal)aNota.ACondicaoPagamento.Multa);
                    cmd.Parameters.AddWithValue("@Desconto", (decimal)aNota.ACondicaoPagamento.Desconto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InativarParcelas(int notaSaidaId, string motivoCancelamento, SqlConnection cnn, SqlTransaction transaction)
        {
            const string sql = @"
                UPDATE CONTAS_A_RECEBER
                SET 
                    ATIVO = 0,
                    MOTIVO_CANCELAMENTO = @Motivo,
                    DATA_ULTIMA_EDICAO = GETDATE()
                WHERE 
                    NOTA_SAIDA_ID = @NotaId
                    AND SITUACAO = 0"; // Em Aberto

            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@NotaId", notaSaidaId);
                cmd.Parameters.AddWithValue("@Motivo", (object)motivoCancelamento ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public override string Salvar(object obj)
        {
            var conta = (ContasReceber)obj;
            string resultado = "";

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return "Erro ao conectar ao Banco de dados.";

                string sql;
                if (conta.Id == 0)
                {
                    sql = @"
                        INSERT INTO CONTAS_A_RECEBER
                            (NOTA_SAIDA_ID, NUMERO_PARCELA, ID_CLIENTE, DATA_EMISSAO, DATA_VENCIMENTO,
                             VALOR_PARCELA, ID_FORMA_PAGAMENTO, JUROS, MULTA, DESCONTO, ATIVO, SITUACAO)
                        OUTPUT INSERTED.CONTA_RECEBER_ID
                        VALUES
                            (@NotaId, @NumParcela, @ClienteId, @DtEmissao, @DtVencimento,
                             @ValorParcela, @FormaPagId, @Juros, @Multa, @Desconto, @Ativo, @Situacao)";
                }
                else
                {
                    sql = @"
                        UPDATE CONTAS_A_RECEBER SET
                            NOTA_SAIDA_ID = @NotaId,
                            NUMERO_PARCELA = @NumParcela,
                            ID_CLIENTE = @ClienteId,
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
                        WHERE CONTA_RECEBER_ID = @ContaId";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@NotaId", conta.ANotaSaida.Id == 0 ? DBNull.Value : (object)conta.ANotaSaida.Id);
                    cmd.Parameters.AddWithValue("@ClienteId", conta.OCliente.Id == 0 ? DBNull.Value : (object)conta.OCliente.Id);

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

                    cmd.Parameters.AddWithValue("@ValorPago", conta.ValorPago == null ? DBNull.Value : (object)conta.ValorPago);
                    cmd.Parameters.AddWithValue("@DataPagamento", conta.DataPagamento == null ? DBNull.Value : (object)conta.DataPagamento);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", string.IsNullOrEmpty(conta.MotivoCancelamento) ? DBNull.Value : (object)conta.MotivoCancelamento);

                    if (conta.Id != 0)
                        cmd.Parameters.AddWithValue("@ContaId", conta.Id);

                    try
                    {
                        if (conta.Id == 0)
                            conta.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        else
                            cmd.ExecuteNonQuery();

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

        public List<ContasReceber> Listar()
        {
            var lista = new List<ContasReceber>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) throw new Exception("Erro ao conectar ao Banco de dados.");

                const string sql = @"
                    SELECT 
                        CR.*,
                        C.CLIENTE_NOME_RS,
                        FP.FORMAPAG_DESC,
                        NS.NOTA_SAIDA_MODELO,
                        NS.NOTA_SAIDA_SERIE,
                        NS.NOTA_SAIDA_NUMERO
                    FROM CONTAS_A_RECEBER CR
                    LEFT JOIN CLIENTE C          ON CR.ID_CLIENTE = C.CLIENTE_ID
                    LEFT JOIN FORMA_PAGAMENTO FP ON CR.ID_FORMA_PAGAMENTO = FP.FORMAPAG_ID
                    LEFT JOIN NOTA_SAIDA NS      ON CR.NOTA_SAIDA_ID = NS.NOTA_SAIDA_ID
                    ORDER BY CR.DATA_VENCIMENTO";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var conta = new ContasReceber
                        {
                            Id = Convert.ToInt32(dr["CONTA_RECEBER_ID"]),
                            NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]),
                            DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]),
                            DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]),
                            ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]),
                            Ativo = Convert.ToBoolean(dr["ATIVO"]),
                            Situacao = Convert.ToInt32(dr["SITUACAO"]),
                            Juros = Convert.ToDecimal(dr["JUROS"]),
                            Multa = Convert.ToDecimal(dr["MULTA"]),
                            Desconto = Convert.ToDecimal(dr["DESCONTO"]),
                            ValorPago = dr["VALOR_PAGO"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]),
                            DataPagamento = dr["DATA_PAGAMENTO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]),
                            MotivoCancelamento = dr["MOTIVO_CANCELAMENTO"] == DBNull.Value ? string.Empty : dr["MOTIVO_CANCELAMENTO"].ToString()
                        };

                        if (dr["NOTA_SAIDA_ID"] != DBNull.Value)
                        {
                            conta.ANotaSaida.Id = Convert.ToInt32(dr["NOTA_SAIDA_ID"]);
                            conta.ANotaSaida.Modelo = dr["NOTA_SAIDA_MODELO"].ToString();
                            conta.ANotaSaida.Serie = dr["NOTA_SAIDA_SERIE"].ToString();
                            conta.ANotaSaida.Numero = dr["NOTA_SAIDA_NUMERO"].ToString();
                        }
                        if (dr["ID_CLIENTE"] != DBNull.Value)
                        {
                            conta.OCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                            conta.OCliente.NomeRazaoSocial = dr["CLIENTE_NOME_RS"].ToString();
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

            return lista;
        }

        public override string Excluir(object obj)
        {
            var conta = (ContasReceber)obj;
            string resultado = "";

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return "Erro ao conectar ao Banco de dados.";

                const string sql = @"
                    UPDATE CONTAS_A_RECEBER SET 
                        ATIVO = 0,
                        DATA_ULTIMA_EDICAO = GETDATE()
                    WHERE CONTA_RECEBER_ID = @ContaId";

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

        public bool ExistemParcelasAnterioresPendentesPorNota(int notaSaidaId, int numeroParcela)
        {
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return false;

                const string sql = @"
                    SELECT COUNT(*)
                    FROM CONTAS_A_RECEBER
                    WHERE
                        NOTA_SAIDA_ID = @NotaId
                        AND NUMERO_PARCELA < @NumParcela
                        AND SITUACAO = 0
                        AND ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@NotaId", notaSaidaId);
                    cmd.Parameters.AddWithValue("@NumParcela", numeroParcela);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool ExistemParcelasAvulsasPendentes(int idCliente, int numeroParcela)
        {
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return false;

                const string sql = @"
                    SELECT COUNT(*)
                    FROM CONTAS_A_RECEBER
                    WHERE 
                        NOTA_SAIDA_ID IS NULL
                        AND ID_CLIENTE = @ClienteId
                        AND NUMERO_PARCELA < @NumParcela
                        AND SITUACAO = 0
                        AND ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", idCliente);
                    cmd.Parameters.AddWithValue("@NumParcela", numeroParcela);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
