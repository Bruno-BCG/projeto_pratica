using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
    internal class DaoNotaSaida : Dao
    {
        public DaoNotaSaida() { }

        public List<NotaSaida> Listar()
        {
            bool HasCol(System.Data.IDataRecord r, string col)
            {
                try { return r.GetOrdinal(col) >= 0; } catch { return false; }
            }

            var notas = new Dictionary<int, NotaSaida>();
            var condicoesPagamento = new Dictionary<int, CondicaoPagamento>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                // --- Cabeçalho (cliente + condição de pagamento)
                // ... dentro do sqlNotas:
                string sqlNotas = @"
                SELECT 
                    N.NOTA_SAIDA_ID, N.NOTA_SAIDA_MODELO, N.NOTA_SAIDA_SERIE, N.NOTA_SAIDA_NUMERO,
                    N.NOTA_SAIDA_DT_EMISSAO, N.NOTA_SAIDA_MOT_CANCELAMENTO, N.ATIVO,
                    N.NOTA_SAIDA_DT_CRIACAO, N.NOTA_SAIDA_DT_ALT,

                    C.CLIENTE_ID, C.CLIENTE_NOME_RS, C.CLIENTE_LIMITE_CREDITO,

                    F.FUNCIONARIO_ID, F.FUNCIONARIO_NOME,

                    CP.CONDPAG_ID, CP.CONDPAG_DESC, CP.CONDPAG_PARCELAS, CP.CONDPAG_JURO, CP.CONDPAG_MULTA, CP.CONDPAG_DESCONTO
                FROM NOTA_SAIDA N
                INNER JOIN CLIENTE C          ON N.CLIENTE_ID = C.CLIENTE_ID
                INNER JOIN FUNCIONARIO F      ON N.FUNCIONARIO_ID = F.FUNCIONARIO_ID
                INNER JOIN COND_PAGAMENTO CP  ON N.CONDPAG_ID = CP.CONDPAG_ID";


                using (SqlCommand cmd = new SqlCommand(sqlNotas, conexao))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int condPagId = Convert.ToInt32(dr["CONDPAG_ID"]);
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

                        var cliente = new Cliente
                        {
                            Id = Convert.ToInt32(dr["CLIENTE_ID"]),
                            NomeRazaoSocial = dr["CLIENTE_NOME_RS"].ToString(),
                            ACondPag = condicoesPagamento[condPagId],
                            LimiteCredito = HasCol(dr, "CLIENTE_LIMITE_CREDITO") && dr["CLIENTE_LIMITE_CREDITO"] != DBNull.Value
                                ? Convert.ToDouble(dr["CLIENTE_LIMITE_CREDITO"])
                                : 0.0
                        };

                        var funcionario = new Funcionario
                        {
                            Id = Convert.ToInt32(dr["FUNCIONARIO_ID"]),
                            NomeRazaoSocial = dr["FUNCIONARIO_NOME"].ToString()
                        };

                        var nota = new NotaSaida
                        {
                            Id = Convert.ToInt32(dr["NOTA_SAIDA_ID"]),
                            Modelo = dr["NOTA_SAIDA_MODELO"].ToString(),
                            Serie = dr["NOTA_SAIDA_SERIE"].ToString(),
                            Numero = dr["NOTA_SAIDA_NUMERO"].ToString(),
                            DataEmissao = Convert.ToDateTime(dr["NOTA_SAIDA_DT_EMISSAO"]),
                            MotivoCancelamento = dr["NOTA_SAIDA_MOT_CANCELAMENTO"] == DBNull.Value ? null : dr["NOTA_SAIDA_MOT_CANCELAMENTO"].ToString(),
                            Ativo = Convert.ToBoolean(dr["ATIVO"]),
                            DtCriacao = Convert.ToDateTime(dr["NOTA_SAIDA_DT_CRIACAO"]),
                            DtAlt = dr["NOTA_SAIDA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["NOTA_SAIDA_DT_ALT"]),
                            OCliente = cliente,
                            OFuncionario = funcionario,
                            ACondicaoPagamento = condicoesPagamento[condPagId],
                            ItensDaNota = new List<ItensNotaSaida>()
                        };

                        notas.Add(nota.Id, nota);
                    }
                }

                // --- Itens
                string sqlItens = @"
                SELECT 
                    I.ITEM_NOTA_ID, I.NOTA_SAIDA_ID, I.ITEM_NOTA_QTD, I.ITEM_NOTA_VLR_UNIT, I.ATIVO,
                    P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_VENDA
                FROM ITENS_NOTA_SAIDA I
                INNER JOIN PRODUTO P ON I.PRODUTO_ID = P.PRODUTO_ID";

                using (SqlCommand cmd = new SqlCommand(sqlItens, conexao))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int notaId = Convert.ToInt32(dr["NOTA_SAIDA_ID"]);
                        if (!notas.ContainsKey(notaId)) continue;

                        var item = new ItensNotaSaida
                        {
                            Id = Convert.ToInt32(dr["ITEM_NOTA_ID"]),
                            Qtd = Convert.ToDecimal(dr["ITEM_NOTA_QTD"]),
                            ValorUnitario = Convert.ToDecimal(dr["ITEM_NOTA_VLR_UNIT"]),
                            Ativo = Convert.ToBoolean(dr["ATIVO"]),
                            OProduto = new Produto
                            {
                                Id = Convert.ToInt32(dr["PRODUTO_ID"]),
                                Nome = dr["PRODUTO_NOME"].ToString(),
                                Venda = dr["PRODUTO_VENDA"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PRODUTO_VENDA"]),
                            }
                        };

                        notas[notaId].ItensDaNota.Add(item);
                    }
                }

                // --- Parcelas da condição de pagamento
                if (condicoesPagamento.Any())
                {
                    string sqlParcelas = $@"
                    SELECT 
                        P.PARCELA_ID, P.CONDPAG_ID, P.PARCELA_NUM, P.PARCELA_PRAZO, P.PARCELA_PERCT,
                        FP.FORMAPAG_ID, FP.FORMAPAG_DESC
                    FROM PARCELA_CONDPAG P
                    INNER JOIN FORMA_PAGAMENTO FP ON P.FORMAPAG_ID = FP.FORMAPAG_ID AND FP.ATIVO = 1
                    WHERE P.CONDPAG_ID IN ({string.Join(",", condicoesPagamento.Keys)}) AND P.ATIVO = 1
                    ORDER BY P.CONDPAG_ID, P.PARCELA_NUM";

                    using (SqlCommand cmd = new SqlCommand(sqlParcelas, conexao))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int condPagId = Convert.ToInt32(dr["CONDPAG_ID"]);
                            if (!condicoesPagamento.ContainsKey(condPagId)) continue;

                            var parcela = new ParcelaCondPag
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

            return notas.Values.ToList();
        }

        public void SalvarCabecalho(NotaSaida nota, SqlConnection cnn, SqlTransaction transaction)
        {
            if (nota.Id == 0)
            {
                string sqlInsert = @"
                INSERT INTO NOTA_SAIDA
                    (NOTA_SAIDA_MODELO, NOTA_SAIDA_SERIE, NOTA_SAIDA_NUMERO, NOTA_SAIDA_DT_EMISSAO,
                     CLIENTE_ID, FUNCIONARIO_ID, CONDPAG_ID, NOTA_SAIDA_MOT_CANCELAMENTO, ATIVO, NOTA_SAIDA_DT_CRIACAO)
                OUTPUT INSERTED.NOTA_SAIDA_ID
                VALUES
                    (@Modelo, @Serie, @Numero, @DtEmissao,
                     @ClienteId, @FuncionarioId, @CondPagId, @MotivoCancelamento, @Ativo, @DtCriacao)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, cnn, transaction))
                {
                    nota.DtCriacao = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Modelo", nota.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", nota.Serie);
                    cmd.Parameters.AddWithValue("@Numero", nota.Numero);
                    cmd.Parameters.AddWithValue("@DtEmissao", nota.DataEmissao);
                    cmd.Parameters.AddWithValue("@ClienteId", nota.OCliente.Id);
                    cmd.Parameters.AddWithValue("@FuncionarioId", nota.OFuncionario.Id);
                    cmd.Parameters.AddWithValue("@CondPagId", nota.ACondicaoPagamento.Id);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)nota.MotivoCancelamento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", nota.Ativo);
                    cmd.Parameters.AddWithValue("@DtCriacao", nota.DtCriacao);
                    nota.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            else
            {
                string sqlUpdate = @"
                UPDATE NOTA_SAIDA SET
                    NOTA_SAIDA_MODELO = @Modelo,
                    NOTA_SAIDA_SERIE = @Serie,
                    NOTA_SAIDA_NUMERO = @Numero,
                    NOTA_SAIDA_DT_EMISSAO = @DtEmissao,
                    CLIENTE_ID = @ClienteId,
                    FUNCIONARIO_ID = @FuncionarioId,  
                    CONDPAG_ID = @CondPagId,
                    NOTA_SAIDA_MOT_CANCELAMENTO = @MotivoCancelamento,
                    ATIVO = @Ativo,
                    NOTA_SAIDA_DT_ALT = @DtAlt
                WHERE NOTA_SAIDA_ID = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, cnn, transaction))
                {
                    nota.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Modelo", nota.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", nota.Serie);
                    cmd.Parameters.AddWithValue("@Numero", nota.Numero);
                    cmd.Parameters.AddWithValue("@DtEmissao", nota.DataEmissao);
                    cmd.Parameters.AddWithValue("@ClienteId", nota.OCliente.Id);
                    cmd.Parameters.AddWithValue("@FuncionarioId", nota.OFuncionario.Id);
                    cmd.Parameters.AddWithValue("@CondPagId", nota.ACondicaoPagamento.Id);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)nota.MotivoCancelamento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", nota.Ativo);
                    cmd.Parameters.AddWithValue("@DtAlt", nota.DtAlt);
                    cmd.Parameters.AddWithValue("@Id", nota.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InativarItensAntigos(int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = @"UPDATE ITENS_NOTA_SAIDA 
                        SET ATIVO = 0, ITEM_NOTA_DT_ALT = @DtAlt 
                        WHERE NOTA_SAIDA_ID = @Id AND ATIVO = 1";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", notaId);
                cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ItensNotaSaida> ListarItensAtivos(int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            var lista = new List<ItensNotaSaida>();
            string sql = @"
            SELECT 
                I.ITEM_NOTA_QTD,
                I.ITEM_NOTA_VLR_UNIT,
                I.PRODUTO_ID
            FROM ITENS_NOTA_SAIDA I
            WHERE I.NOTA_SAIDA_ID = @NotaId AND I.ATIVO = 1";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@NotaId", notaId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ItensNotaSaida
                        {
                            Qtd = Convert.ToDecimal(dr["ITEM_NOTA_QTD"]),
                            ValorUnitario = Convert.ToDecimal(dr["ITEM_NOTA_VLR_UNIT"]),
                            OProduto = new Produto { Id = Convert.ToInt32(dr["PRODUTO_ID"]) }
                        });
                    }
                }
            }
            return lista;
        }

        public void InserirItem(ItensNotaSaida item, int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = @"
            INSERT INTO ITENS_NOTA_SAIDA
                (NOTA_SAIDA_ID, PRODUTO_ID, ITEM_NOTA_QTD, ITEM_NOTA_VLR_UNIT, ATIVO, ITEM_NOTA_DT_CRIACAO)
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

        public bool ExistemParcelasPagasPorNota(int notaSaidaId, SqlConnection cnn, SqlTransaction tx = null)
        {
            const string sql = @"
            SELECT COUNT(1)
            FROM CONTAS_A_RECEBER WITH (NOLOCK)
            WHERE NOTA_SAIDA_ID = @NotaId
              AND SITUACAO = 1   -- 1 = recebido/baixado
              AND ATIVO = 1;";

            using (var cmd = new SqlCommand(sql, cnn))
            {
                if (tx != null) cmd.Transaction = tx; 
                cmd.Parameters.AddWithValue("@NotaId", notaSaidaId);

                object o = null;
                try
                {
                    o = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao consultar CONTAS_A_RECEBER: " + ex.Message, ex);
                }

                int count = (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
                return count > 0;
            }
        }

        public bool ExistemParcelasPagasPorNota(int notaSaidaId)
        {
            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return false;
                return ExistemParcelasPagasPorNota(notaSaidaId, cnn, null);
            }

        }
    }
}

