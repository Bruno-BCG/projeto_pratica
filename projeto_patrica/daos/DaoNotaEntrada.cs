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
            
        public List<NotaEntrada> Listar()
        {
            var notas = new Dictionary<int, NotaEntrada>();
            var condicoesPagamento = new Dictionary<int, CondicaoPagamento>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sqlNotas = @"
                    SELECT 
                        N.NOTA_ENTRADA_ID, N.NOTA_ENTRADA_MODELO, N.NOTA_ENTRADA_SERIE, N.NOTA_ENTRADA_NUMERO,
                        N.NOTA_ENTRADA_DT_EMISSAO, N.NOTA_ENTRADA_DT_CHEGADA, N.NOTA_ENTRADA_VLR_FRETE,
                        N.NOTA_ENTRADA_VLR_SEGURO, N.NOTA_ENTRADA_VLR_DESPESAS, N.NOTA_ENTRADA_MOT_CANCELAMENTO,N.ATIVO,
                        N.NOTA_ENTRADA_DT_CRIACAO, N.NOTA_ENTRADA_DT_ALT,
                        F.FORNECEDOR_ID, F.FORNECEDOR_NOME_RS,
                        C.CONDPAG_ID, C.CONDPAG_DESC, C.CONDPAG_PARCELAS, C.CONDPAG_JURO, C.CONDPAG_MULTA, C.CONDPAG_DESCONTO
                    FROM NOTA_ENTRADA N
                    INNER JOIN FORNECEDOR F ON N.FORNECEDOR_ID = F.FORNECEDOR_ID
                    INNER JOIN COND_PAGAMENTO C ON N.CONDPAG_ID = C.CONDPAG_ID
                    ";

                using (SqlCommand cmd = new SqlCommand(sqlNotas, conexao))
                {
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
                                MotivoCancelamento = dr["NOTA_ENTRADA_MOT_CANCELAMENTO"].ToString(),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                DtCriacao = Convert.ToDateTime(dr["NOTA_ENTRADA_DT_CRIACAO"]),
                                DtAlt = dr["NOTA_ENTRADA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["NOTA_ENTRADA_DT_ALT"]),
                                OFornecedor = new Fornecedor
                                {
                                    Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString()
                                },
                                ACondicaoPagamento = condicoesPagamento[condPagId]
                            };
                            notas.Add(nota.Id, nota);
                        }
                    }
                }

                string sqlItens = @"
                    SELECT 
                        I.ITEM_NOTA_ID, I.NOTA_ENTRADA_ID, I.ITEM_NOTA_QTD, I.ITEM_NOTA_VLR_UNIT, I.ATIVO,
                        P.PRODUTO_ID, P.PRODUTO_NOME
                    FROM ITENS_NOTA_ENTRADA I
                    INNER JOIN PRODUTO P ON I.PRODUTO_ID = P.PRODUTO_ID";

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

                if (condicoesPagamento.Any())
                {
                    string sqlParcelas = $@"
                        SELECT 
                            P.PARCELA_ID, P.CONDPAG_ID, P.PARCELA_NUM, P.PARCELA_PRAZO, P.PARCELA_PERCT,
                            FP.FORMAPAG_ID, FP.FORMAPAG_DESC
                        FROM PARCELA_CONDPAG P
                        INNER JOIN FORMA_PAGAMENTO FP ON P.FORMAPAG_ID = FP.FORMAPAG_ID AND FP.ATIVO = 1
                        WHERE P.CONDPAG_ID IN ({string.Join(",", condicoesPagamento.Keys)}) AND P.ATIVO = 1";

                    using (SqlCommand cmd = new SqlCommand(sqlParcelas, conexao))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int condPagId = Convert.ToInt32(dr["CONDPAG_ID"]);

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
        public void SalvarCabecalho(NotaEntrada aNota, SqlConnection cnn, SqlTransaction transaction)
        {
            if (aNota.Id == 0)
            {
                string sqlInsert = @"
                    INSERT INTO NOTA_ENTRADA 
                        (NOTA_ENTRADA_MODELO, NOTA_ENTRADA_SERIE, NOTA_ENTRADA_NUMERO, NOTA_ENTRADA_DT_EMISSAO, 
                         NOTA_ENTRADA_DT_CHEGADA, NOTA_ENTRADA_VLR_FRETE, NOTA_ENTRADA_VLR_SEGURO, NOTA_ENTRADA_VLR_DESPESAS,
                         FORNECEDOR_ID, CONDPAG_ID, NOTA_ENTRADA_MOT_CANCELAMENTO, ATIVO, NOTA_ENTRADA_DT_CRIACAO)
                    OUTPUT INSERTED.NOTA_ENTRADA_ID
                    VALUES (@Modelo, @Serie, @Numero, @DtEmissao, @DtChegada, @VlrFrete, @VlrSeguro, @VlrDespesas,
                            @FornecedorId, @CondPagId, @MotivoCancelamento, @Ativo, @DtCriacao)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, cnn, transaction))
                {
                    aNota.DtCriacao = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Modelo", aNota.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", aNota.Serie);
                    cmd.Parameters.AddWithValue("@Numero", aNota.Numero);
                    cmd.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                    cmd.Parameters.AddWithValue("@DtChegada", aNota.DataChegada);
                    cmd.Parameters.AddWithValue("@VlrFrete", aNota.ValorFrete);
                    cmd.Parameters.AddWithValue("@VlrSeguro", aNota.ValorSeguro);
                    cmd.Parameters.AddWithValue("@VlrDespesas", aNota.OutrasDespesas);
                    cmd.Parameters.AddWithValue("@FornecedorId", aNota.OFornecedor.Id);
                    cmd.Parameters.AddWithValue("@CondPagId", aNota.ACondicaoPagamento.Id);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)aNota.MotivoCancelamento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", aNota.Ativo);
                    cmd.Parameters.AddWithValue("@DtCriacao", aNota.DtCriacao);
                    aNota.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            else
            {
               
                string sqlUpdate = @"
                    UPDATE NOTA_ENTRADA SET 
                        NOTA_ENTRADA_MODELO = @Modelo, NOTA_ENTRADA_SERIE = @Serie, NOTA_ENTRADA_NUMERO = @Numero, 
                        NOTA_ENTRADA_DT_EMISSAO = @DtEmissao, NOTA_ENTRADA_DT_CHEGADA = @DtChegada, 
                        NOTA_ENTRADA_VLR_FRETE = @VlrFrete, NOTA_ENTRADA_VLR_SEGURO = @VlrSeguro, NOTA_ENTRADA_VLR_DESPESAS = @VlrDespesas,
                        FORNECEDOR_ID = @FornecedorId, 
                        NOTA_ENTRADA_MOT_CANCELAMENTO = @MotivoCancelamento,
                        CONDPAG_ID = @CondPagId, ATIVO = @Ativo,
                        NOTA_ENTRADA_DT_ALT = @DtAlt
                    WHERE NOTA_ENTRADA_ID = @Id";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, cnn, transaction))
                {
                    aNota.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Modelo", aNota.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", aNota.Serie);
                    cmd.Parameters.AddWithValue("@Numero", aNota.Numero);
                    cmd.Parameters.AddWithValue("@DtEmissao", aNota.DataEmissao);
                    cmd.Parameters.AddWithValue("@DtChegada", aNota.DataChegada);
                    cmd.Parameters.AddWithValue("@VlrFrete", aNota.ValorFrete);
                    cmd.Parameters.AddWithValue("@VlrSeguro", aNota.ValorSeguro);
                    cmd.Parameters.AddWithValue("@VlrDespesas", aNota.OutrasDespesas);
                    cmd.Parameters.AddWithValue("@FornecedorId", aNota.OFornecedor.Id);
                    cmd.Parameters.AddWithValue("@CondPagId", aNota.ACondicaoPagamento.Id);
                    cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)aNota.MotivoCancelamento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", aNota.Ativo);
                    cmd.Parameters.AddWithValue("@DtAlt", aNota.DtAlt);
                    cmd.Parameters.AddWithValue("@Id", aNota.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InativarItensAntigos(int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            string sql = "UPDATE ITENS_NOTA_ENTRADA SET ATIVO = 0, ITEM_NOTA_DT_ALT = @DtAlt WHERE NOTA_ENTRADA_ID = @Id AND ATIVO = 1";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", notaId);
                cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public List<ItensNotaEntrada> ListarItensAtivos(int notaId, SqlConnection cnn, SqlTransaction transaction)
        {
            var lista = new List<ItensNotaEntrada>();
            string sql = @"
                SELECT 
                    I.ITEM_NOTA_QTD, I.PRODUTO_ID, 
                    ISNULL(PF.CUSTO_ATUAL_COMPRA, I.ITEM_NOTA_VLR_UNIT) as CustoRealUsado
                FROM ITENS_NOTA_ENTRADA I
                INNER JOIN NOTA_ENTRADA N ON I.NOTA_ENTRADA_ID = N.NOTA_ENTRADA_ID
                LEFT JOIN PRODUTO_FORNECEDOR PF ON I.PRODUTO_ID = PF.PRODUTO_ID AND N.FORNECEDOR_ID = PF.FORNECEDOR_ID
                WHERE I.NOTA_ENTRADA_ID = @NotaId AND I.ATIVO = 1";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@NotaId", notaId);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ItensNotaEntrada
                        {
                            Qtd = Convert.ToDecimal(dr["ITEM_NOTA_QTD"]),
                            OProduto = new Produto { Id = Convert.ToInt32(dr["PRODUTO_ID"]) },
                            CustoUnitarioReal = Convert.ToDecimal(dr["CustoRealUsado"])
                        });
                    }
                }
            }
            return lista;
        }

        public void InserirItem(ItensNotaEntrada item, int notaId, SqlConnection cnn, SqlTransaction transaction)
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
        public bool ExistemParcelasPagasPorNota(int notaEntradaId, SqlConnection cnn, SqlTransaction tx)
        {
            const string sql = @"
        SELECT COUNT(*)
        FROM CONTAS_A_PAGAR
        WHERE NOTA_ENTRADA_ID = @NotaId
          AND SITUACAO = 1     -- 1 = paga (baixa confirmada)
          AND ATIVO = 1";

            using (var cmd = new SqlCommand(sql, cnn, tx))
            {
                cmd.Parameters.AddWithValue("@NotaId", notaEntradaId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool ExistemParcelasPagasPorNota(int notaEntradaId)
        {
            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return false;
                return ExistemParcelasPagasPorNota(notaEntradaId, cnn, null);
            }
        }

    }
}

