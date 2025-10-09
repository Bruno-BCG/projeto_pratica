using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{ 
    internal class DaoNotaEntrada : Dao
    {
        public DaoNotaEntrada() { }
        public override string Salvar(object obj)
        {
            NotaEntrada aNota = (NotaEntrada)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                SqlTransaction transaction = cnn.BeginTransaction();

                try
                {
                    if (aNota.Id == 0)
                    {
                        InserirNotaCompleta(aNota, cnn, transaction);
                    }
                    else
                    {
                        AtualizarNotaCompleta(aNota, cnn, transaction);
                    }

                    transaction.Commit();
                    resultado = aNota.Id.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    resultado = "Erro ao salvar a nota: " + ex.Message;
                }
            }
            return resultado;
        }

        public override string Excluir(object obj)
        {
            NotaEntrada aNota = (NotaEntrada)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return "Erro ao conectar ao banco de dados.";

                SqlTransaction transaction = cnn.BeginTransaction();
                try
                {
                    // Inativa todos os itens da nota
                    string sqlItens = "UPDATE ITENS_NOTA_ENTRADA SET ATIVO = 0, ITEM_NOTA_DT_ALT = @DtAlt WHERE NOTA_ENTRADA_ID = @Id";
                    using (SqlCommand cmdItens = new SqlCommand(sqlItens, cnn, transaction))
                    {
                        cmdItens.Parameters.AddWithValue("@Id", aNota.Id);
                        cmdItens.Parameters.AddWithValue("@DtAlt", DateTime.Now);
                        cmdItens.ExecuteNonQuery();
                    }

                    // Inativa o cabeçalho da nota
                    string sqlNota = "UPDATE NOTA_ENTRADA SET ATIVO = 0, NOTA_ENTRADA_DT_ALT = @DtAlt WHERE NOTA_ENTRADA_ID = @Id";
                    using (SqlCommand cmdNota = new SqlCommand(sqlNota, cnn, transaction))
                    {
                        cmdNota.Parameters.AddWithValue("@Id", aNota.Id);
                        cmdNota.Parameters.AddWithValue("@DtAlt", DateTime.Now);
                        int rows = cmdNota.ExecuteNonQuery();
                        resultado = (rows > 0) ? "OK" : "Nota de entrada não encontrada.";
                    }

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    resultado = "Erro ao inativar a nota: " + ex.Message;
                }
            }
            return resultado;
        }
        public List<NotaEntrada> Listar()
        {
            var notas = new Dictionary<int, NotaEntrada>();
            // Dicionário auxiliar para otimizar o preenchimento das parcelas
            var condicoesPagamento = new Dictionary<int, CondicaoPagamento>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                // PASSO 1: Busca todas as notas ATIVAS e as informações principais de Fornecedor e CondPag
                string sqlNotas = @"
                    SELECT 
                        N.NOTA_ENTRADA_ID, N.NOTA_ENTRADA_MODELO, N.NOTA_ENTRADA_SERIE, N.NOTA_ENTRADA_NUMERO,
                        N.NOTA_ENTRADA_DT_EMISSAO, N.NOTA_ENTRADA_DT_CHEGADA, N.NOTA_ENTRADA_VLR_FRETE,
                        N.NOTA_ENTRADA_VLR_SEGURO, N.NOTA_ENTRADA_VLR_DESPESAS, N.ATIVO,
                        N.NOTA_ENTRADA_DT_CRIACAO, N.NOTA_ENTRADA_DT_ALT,
                        F.FORNECEDOR_ID, F.FORNECEDOR_NOME_RS,
                        C.CONDPAG_ID, C.CONDPAG_DESC, C.CONDPAG_PARCELAS, C.CONDPAG_JURO, C.CONDPAG_MULTA, C.CONDPAG_DESCONTO
                    FROM NOTA_ENTRADA N
                    INNER JOIN FORNECEDOR F ON N.FORNECEDOR_ID = F.FORNECEDOR_ID
                    INNER JOIN COND_PAGAMENTO C ON N.CONDPAG_ID = C.CONDPAG_ID
                    WHERE N.ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sqlNotas, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int condPagId = Convert.ToInt32(dr["CONDPAG_ID"]);
                            // Adiciona a condição de pagamento ao dicionário auxiliar se ela ainda não existir
                            if (!condicoesPagamento.ContainsKey(condPagId))
                            {
                                condicoesPagamento.Add(condPagId, new CondicaoPagamento
                                {
                                    Id = condPagId,
                                    Descricao = dr["CONDPAG_DESC"].ToString(),
                                    NumParcelas = Convert.ToInt32(dr["CONDPAG_PARCELAS"]),
                                    Juro = Convert.ToDouble(dr["CONDPAG_JURO"]),
                                    Multa = Convert.ToDouble(dr["CONDPAG_MULTA"]),
                                    Desconto = Convert.ToDouble(dr["CONDPAG_DESCONTO"])
                                });
                            }

                            NotaEntrada nota = new NotaEntrada
                            {
                                Id = Convert.ToInt32(dr["NOTA_ENTRADA_ID"]),
                                Modelo = dr["NOTA_ENTRADA_MODELO"].ToString(),
                                Serie = dr["NOTA_ENTRADA_SERIE"].ToString(),
                                Numero = dr["NOTA_ENTRADA_NUMERO"].ToString(),
                                DataEmissao = Convert.ToDateTime(dr["NOTA_ENTRADA_DT_EMISSAO"]),
                                DataChegada = dr["NOTA_ENTRADA_DT_CHEGADA"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["NOTA_ENTRADA_DT_CHEGADA"]),
                                ValorFrete = Convert.ToDecimal(dr["NOTA_ENTRADA_VLR_FRETE"]),
                                ValorSeguro = Convert.ToDecimal(dr["NOTA_ENTRADA_VLR_SEGURO"]),
                                OutrasDespesas = Convert.ToDecimal(dr["NOTA_ENTRADA_VLR_DESPESAS"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                DtCriacao = Convert.ToDateTime(dr["NOTA_ENTRADA_DT_CRIACAO"]),
                                DtAlt = dr["NOTA_ENTRADA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["NOTA_ENTRADA_DT_ALT"]),
                                OFornecedor = new Fornecedor
                                {
                                    Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString()
                                },
                                // Associa a nota à condição de pagamento do dicionário
                                ACondicaoPagamento = condicoesPagamento[condPagId]
                            };
                            notas.Add(nota.Id, nota);
                        }
                    }
                }

                // PASSO 2: Busca todos os itens ATIVOS para preencher as notas já carregadas
                string sqlItens = @"
                    SELECT 
                        I.ITEM_NOTA_ID, I.NOTA_ENTRADA_ID, I.ITEM_NOTA_QTD, I.ITEM_NOTA_VLR_UNIT, I.ATIVO,
                        P.PRODUTO_ID, P.PRODUTO_NOME
                    FROM ITENS_NOTA_ENTRADA I
                    INNER JOIN PRODUTO P ON I.PRODUTO_ID = P.PRODUTO_ID
                    WHERE I.ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sqlItens, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int notaId = Convert.ToInt32(dr["NOTA_ENTRADA_ID"]);

                            if (notas.ContainsKey(notaId))
                            {
                                ItensNotaEntrada item = new ItensNotaEntrada
                                {
                                    Id = Convert.ToInt32(dr["ITEM_NOTA_ID"]),
                                    Qtd = Convert.ToDecimal(dr["ITEM_NOTA_QTD"]),
                                    ValorUnitario = Convert.ToDecimal(dr["ITEM_NOTA_VLR_UNIT"]),
                                    Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                    OProduto = new Produto
                                    {
                                        Id = Convert.ToInt32(dr["PRODUTO_ID"]),
                                        Nome = dr["PRODUTO_NOME"].ToString()
                                    }
                                };
                                notas[notaId].ItensDaNota.Add(item);
                            }
                        }
                    }
                }

                // ============================================================================================
                // PASSO 3 (NOVO): Busca todas as parcelas das condições de pagamento carregadas
                // ============================================================================================
                if (condicoesPagamento.Any())
                {
                    string sqlParcelas = $@"
                        SELECT 
                            P.PARCELA_ID, P.CONDPAG_ID, P.PARCELA_NUM, P.PARCELA_PRAZO, P.PARCELA_PERCT,
                            FP.FORMAPAG_ID, FP.FORMAPAG_DESC
                        FROM PARCELA_CONDPAG P
                        INNER JOIN FORMA_PAGAMENTO FP ON P.FORMAPAG_ID = FP.FORMAPAG_ID
                        WHERE P.CONDPAG_ID IN ({string.Join(",", condicoesPagamento.Keys)})";

                    using (SqlCommand cmd = new SqlCommand(sqlParcelas, conexao))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int condPagId = Convert.ToInt32(dr["CONDPAG_ID"]);

                                // Se a condição de pagamento existe no nosso dicionário, adiciona a parcela a ela
                                if (condicoesPagamento.ContainsKey(condPagId))
                                {
                                    ParcelaCondPag parcela = new ParcelaCondPag
                                    {
                                        Id = Convert.ToInt32(dr["PARCELA_ID"]),
                                        CondPagId = condPagId,
                                        NumeroParcela = Convert.ToInt32(dr["PARCELA_NUM"]),
                                        Prazo = Convert.ToInt32(dr["PARCELA_PRAZO"]),
                                        Percentual = Convert.ToDecimal(dr["PARCELA_PERCT"]),
                                        AFormPag = new FormaPagamento
                                        {
                                            Id = Convert.ToInt32(dr["FORMAPAG_ID"]),
                                            Descricao = dr["FORMAPAG_DESC"].ToString()
                                        }
                                    };
                                    condicoesPagamento[condPagId].ParcelasCondPag.Add(parcela);
                                }
                            }
                        }
                    }
                }
            }
            return notas.Values.ToList();
        }

        private void InserirNotaCompleta(NotaEntrada aNota, SqlConnection cnn, SqlTransaction transaction)
        {
            // Insere o cabeçalho da nota
            string sqlNota = @"
                INSERT INTO NOTA_ENTRADA 
                    (NOTA_ENTRADA_MODELO, NOTA_ENTRADA_SERIE, NOTA_ENTRADA_NUMERO, NOTA_ENTRADA_DT_EMISSAO, 
                     NOTA_ENTRADA_DT_CHEGADA, NOTA_ENTRADA_VLR_FRETE, NOTA_ENTRADA_VLR_SEGURO, NOTA_ENTRADA_VLR_DESPESAS,
                     FORNECEDOR_ID, CONDPAG_ID, ATIVO, NOTA_ENTRADA_DT_CRIACAO)
                OUTPUT INSERTED.NOTA_ENTRADA_ID
                VALUES (@Modelo, @Serie, @Numero, @DtEmissao, @DtChegada, @VlrFrete, @VlrSeguro, @VlrDespesas,
                        @FornecedorId, @CondPagId, @Ativo, @DtCriacao)";

            using (SqlCommand cmdNota = new SqlCommand(sqlNota, cnn, transaction))
            {
                aNota.DtCriacao = DateTime.Now;
                cmdNota.Parameters.AddWithValue("@Modelo", aNota.Modelo);
                cmdNota.Parameters.AddWithValue("@Serie", aNota.Serie);
                cmdNota.Parameters.AddWithValue("@Numero", aNota.Numero);
                cmdNota.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                cmdNota.Parameters.AddWithValue("@DtChegada", aNota.DataChegada);
                cmdNota.Parameters.AddWithValue("@VlrFrete", aNota.ValorFrete);
                cmdNota.Parameters.AddWithValue("@VlrSeguro", aNota.ValorSeguro);
                cmdNota.Parameters.AddWithValue("@VlrDespesas", aNota.OutrasDespesas);
                cmdNota.Parameters.AddWithValue("@FornecedorId", aNota.OFornecedor.Id);
                cmdNota.Parameters.AddWithValue("@CondPagId", aNota.ACondicaoPagamento.Id);
                cmdNota.Parameters.AddWithValue("@Ativo", aNota.Ativo);
                cmdNota.Parameters.AddWithValue("@DtCriacao", aNota.DtCriacao);

                aNota.Id = Convert.ToInt32(cmdNota.ExecuteScalar());
            }

            // Insere os novos itens
            foreach (var item in aNota.ItensDaNota)
            {
                item.Ativo = true; // Garante que o item seja inserido como ativo
                InserirItem(item, aNota.Id, cnn, transaction);
            }
        }

        private void AtualizarNotaCompleta(NotaEntrada aNota, SqlConnection cnn, SqlTransaction transaction)
        {
            // 1. Atualiza o cabeçalho da nota
            string sqlNota = @"
                UPDATE NOTA_ENTRADA SET 
                    NOTA_ENTRADA_MODELO = @Modelo, NOTA_ENTRADA_SERIE = @Serie, NOTA_ENTRADA_NUMERO = @Numero, 
                    NOTA_ENTRADA_DT_EMISSAO = @DtEmissao, NOTA_ENTRADA_DT_CHEGADA = @DtChegada, 
                    NOTA_ENTRADA_VLR_FRETE = @VlrFrete, NOTA_ENTRADA_VLR_SEGURO = @VlrSeguro, NOTA_ENTRADA_VLR_DESPESAS = @VlrDespesas,
                    FORNECEDOR_ID = @FornecedorId, CONDPAG_ID = @CondPagId, ATIVO = @Ativo,
                    NOTA_ENTRADA_DT_ALT = @DtAlt
                WHERE NOTA_ENTRADA_ID = @Id";

            using (SqlCommand cmdNota = new SqlCommand(sqlNota, cnn, transaction))
            {
                aNota.DtAlt = DateTime.Now;
                cmdNota.Parameters.AddWithValue("@Modelo", aNota.Modelo);
                cmdNota.Parameters.AddWithValue("@Serie", aNota.Serie);
                cmdNota.Parameters.AddWithValue("@Numero", aNota.Numero);
                cmdNota.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                cmdNota.Parameters.AddWithValue("@DtChegada", aNota.DataChegada);
                cmdNota.Parameters.AddWithValue("@VlrFrete", aNota.ValorFrete);
                cmdNota.Parameters.AddWithValue("@VlrSeguro", aNota.ValorSeguro);
                cmdNota.Parameters.AddWithValue("@VlrDespesas", aNota.OutrasDespesas);
                cmdNota.Parameters.AddWithValue("@FornecedorId", aNota.OFornecedor.Id);
                cmdNota.Parameters.AddWithValue("@CondPagId", aNota.ACondicaoPagamento.Id);
                cmdNota.Parameters.AddWithValue("@Ativo", aNota.Ativo);
                cmdNota.Parameters.AddWithValue("@DtAlt", aNota.DtAlt);
                cmdNota.Parameters.AddWithValue("@Id", aNota.Id);
                cmdNota.ExecuteNonQuery();
            }

            SincronizarItens(aNota, cnn, transaction);
        }

        private void SincronizarItens(NotaEntrada aNota, SqlConnection cnn, SqlTransaction transaction)
        {
            // Pega a lista de IDs de todos os itens da nota que estão atualmente no banco
            var idsNoBanco = new List<int>();
            string sqlSelectIds = "SELECT ITEM_NOTA_ID FROM ITENS_NOTA_ENTRADA WHERE NOTA_ENTRADA_ID = @NotaId";
            using (SqlCommand cmdSelect = new SqlCommand(sqlSelectIds, cnn, transaction))
            {
                cmdSelect.Parameters.AddWithValue("@NotaId", aNota.Id);
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idsNoBanco.Add(reader.GetInt32(0));
                    }
                }
            }

            var idsDaTela = new List<int>();
            foreach (var item in aNota.ItensDaNota)
            {
                item.Ativo = true;
                if (item.Id > 0) 
                {
                    AtualizarItem(item, cnn, transaction);
                    idsDaTela.Add(item.Id);
                }
                else 
                {
                    InserirItem(item, aNota.Id, cnn, transaction);
                }
            }

            // Compara as listas para descobrir quais itens foram removidos
            var idsParaInativar = idsNoBanco.Except(idsDaTela).ToList();
            if (idsParaInativar.Count > 0)
            {
                string sqlInativar = $"UPDATE ITENS_NOTA_ENTRADA SET ATIVO = 0, ITEM_NOTA_DT_ALT = @DtAlt WHERE ITEM_NOTA_ID IN ({string.Join(",", idsParaInativar)})";
                using (SqlCommand cmdInativar = new SqlCommand(sqlInativar, cnn, transaction))
                {
                    cmdInativar.Parameters.AddWithValue("@DtAlt", DateTime.Now);
                    cmdInativar.ExecuteNonQuery();
                }
            }
        }

        private void InserirItem(ItensNotaEntrada item, int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = @"
                INSERT INTO ITENS_NOTA_ENTRADA
                    (NOTA_ENTRADA_ID, PRODUTO_ID, ITEM_NOTA_QTD, ITEM_NOTA_VLR_UNIT, ATIVO, ITEM_NOTA_DT_CRIACAO)
                VALUES 
                    (@NotaId, @ProdutoId, @Qtd, @ValorUnit, @Ativo, @DtCriacao)";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                item.DtCriacao = DateTime.Now;
                cmd.Parameters.AddWithValue("@NotaId", notaId);
                cmd.Parameters.AddWithValue("@ProdutoId", item.OProduto.Id);
                cmd.Parameters.AddWithValue("@Qtd", item.Qtd);
                cmd.Parameters.AddWithValue("@ValorUnit", item.ValorUnitario);
                cmd.Parameters.AddWithValue("@Ativo", item.Ativo);
                cmd.Parameters.AddWithValue("@DtCriacao", item.DtCriacao);
                cmd.ExecuteNonQuery();
            }
        }

        private void AtualizarItem(ItensNotaEntrada item, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = @"
                UPDATE ITENS_NOTA_ENTRADA SET
                    PRODUTO_ID = @ProdutoId, 
                    ITEM_NOTA_QTD = @Qtd, 
                    ITEM_NOTA_VLR_UNIT = @ValorUnit, 
                    ATIVO = @Ativo, 
                    ITEM_NOTA_DT_ALT = @DtAlt
                WHERE ITEM_NOTA_ID = @Id";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                item.DtAlt = DateTime.Now;
                cmd.Parameters.AddWithValue("@ProdutoId", item.OProduto.Id);
                cmd.Parameters.AddWithValue("@Qtd", item.Qtd);
                cmd.Parameters.AddWithValue("@ValorUnit", item.ValorUnitario);
                cmd.Parameters.AddWithValue("@Ativo", item.Ativo);
                cmd.Parameters.AddWithValue("@DtAlt", item.DtAlt);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

