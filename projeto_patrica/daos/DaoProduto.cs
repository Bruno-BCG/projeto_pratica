using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using projeto_pratica.classes;

namespace projeto_pratica.daos
{
    internal class DaoProduto : Dao
    {
        public DaoProduto()
        {
        }

        public override string Salvar(object obj)
        {
            Produto aProduto = (Produto)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                // Usaremos uma transação para garantir que o produto e seus fornecedores sejam salvos juntos
                SqlTransaction transaction = cnn.BeginTransaction();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    string sql;
                    char operacao = 'I';

                    if (aProduto.Id == 0)
                    {
                        // SQL de Inserção sem o FORNECEDOR_ID
                        sql = @"INSERT INTO PRODUTO 
                                (PRODUTO_NOME, PRODUTO_CODBAR, UN_MEDIDA_ID, CATEGORIA_ID, MARCA_ID, 
                                 PRODUTO_VENDA, PRODUTO_PERCENT_LUCRO, PRODUTO_DT_CRIACAO)
                                OUTPUT INSERTED.PRODUTO_ID
                                VALUES (@nome, @codbar, @unMedidaId, @categoriaId, @marcaId, 
                                       @venda, @percent, @dtCriacao)";
                    }
                    else
                    {
                        operacao = 'U';
                        // SQL de Atualização sem o FORNECEDOR_ID
                        sql = @"UPDATE PRODUTO SET 
                                PRODUTO_NOME = @nome, PRODUTO_CODBAR = @codbar, 
                                UN_MEDIDA_ID = @unMedidaId, CATEGORIA_ID = @categoriaId, MARCA_ID = @marcaId, 
                                PRODUTO_VENDA = @venda, PRODUTO_PERCENT_LUCRO = @percent,
                                PRODUTO_DT_ALT = @dtAlt
                                WHERE PRODUTO_ID = @id";
                    }

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@nome", aProduto.Nome);
                    cmd.Parameters.AddWithValue("@codbar", aProduto.Codbar);
                    cmd.Parameters.AddWithValue("@unMedidaId", aProduto.AUnidadeMedida.Id);
                    cmd.Parameters.AddWithValue("@categoriaId", aProduto.ACategoria.Id);
                    cmd.Parameters.AddWithValue("@marcaId", aProduto.AMarca.Id);
                    cmd.Parameters.AddWithValue("@venda", aProduto.Venda);
                    cmd.Parameters.AddWithValue("@percent", aProduto.PercentLucro);

                    if (operacao == 'I')
                    {
                        aProduto.DtCriacao = DateTime.Now;
                        cmd.Parameters.AddWithValue("@dtCriacao", aProduto.DtCriacao);
                        aProduto.Id = Convert.ToInt32(cmd.ExecuteScalar());

                        if (aProduto.OFornecedor != null && aProduto.OFornecedor.Count > 0)
                        {
                            string insertFornSql = @"
                            INSERT INTO PRODUTO_FORNECEDOR 
                                (PRODUTO_ID, FORNECEDOR_ID, CUSTO_ULT_COMPRA, DT_ULT_COMPRA, CUSTO_ATUAL_COMPRA, ATIVO) 
                            VALUES 
                                (@produtoId, @fornecedorId, 0, GETDATE(), 0, 1)"; // ATIVO = 1

                            foreach (Fornecedor forn in aProduto.OFornecedor)
                            {
                                using (SqlCommand fornCmd = new SqlCommand(insertFornSql, cnn, transaction))
                                {
                                    fornCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                                    fornCmd.Parameters.AddWithValue("@fornecedorId", forn.Id);
                                    fornCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        aProduto.DtAlt = DateTime.Now;
                        cmd.Parameters.AddWithValue("@dtAlt", aProduto.DtAlt);
                        cmd.Parameters.AddWithValue("@id", aProduto.Id);
                        cmd.ExecuteNonQuery();

                        string deactivateSql = "UPDATE PRODUTO_FORNECEDOR SET ATIVO = 0 WHERE PRODUTO_ID = @produtoId";
                        using (SqlCommand deactivateCmd = new SqlCommand(deactivateSql, cnn, transaction))
                        {
                            deactivateCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                            deactivateCmd.ExecuteNonQuery();
                        }

                        if (aProduto.OFornecedor != null && aProduto.OFornecedor.Count > 0)
                        {
                            string updateSql = @"
                            UPDATE PRODUTO_FORNECEDOR 
                            SET ATIVO = 1
                            WHERE PRODUTO_ID = @produtoId AND FORNECEDOR_ID = @fornecedorId";

                            string insertSql = @"
                            INSERT INTO PRODUTO_FORNECEDOR 
                                (PRODUTO_ID, FORNECEDOR_ID, CUSTO_ULT_COMPRA, DT_ULT_COMPRA, CUSTO_ATUAL_COMPRA, ATIVO) 
                            VALUES 
                                (@produtoId, @fornecedorId, 0, GETDATE(), 0, 1)"; // ATIVO = 1

                            foreach (Fornecedor forn in aProduto.OFornecedor)
                            {
                                int rowsAffected = 0;

                                using (SqlCommand updateCmd = new SqlCommand(updateSql, cnn, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                                    updateCmd.Parameters.AddWithValue("@fornecedorId", forn.Id);

                                    rowsAffected = updateCmd.ExecuteNonQuery();
                                }

                                if (rowsAffected == 0)
                                {
                                    using (SqlCommand insertCmd = new SqlCommand(insertSql, cnn, transaction))
                                    {
                                        insertCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                                        insertCmd.Parameters.AddWithValue("@fornecedorId", forn.Id);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    resultado = aProduto.Id.ToString();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    resultado = "Erro ao salvar: " + ex.Message;
                }
            }
            return resultado;
        }

        public override string Excluir(object obj)
        {
            Produto aProduto = (Produto)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return "Erro ao conectar ao banco de dados.";

                string sql = "DELETE FROM PRODUTO WHERE PRODUTO_ID = @id";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", aProduto.Id);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    resultado = (rows > 0) ? "OK" : "Produto não encontrado.";
                }
                catch (SqlException ex)
                {
                    resultado = "Erro ao excluir: " + ex.Message;
                }
            }
            return resultado;
        }

        public List<Produto> Listar()
        {
            var produtos = new Dictionary<int, Produto>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sqlProdutos = @"
                    SELECT 
                        P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_CODBAR, P.PRODUTO_CUSTO_ANTERIOR, P.PRODUTO_CUSTO, P.PRODUTO_PERCENT_LUCRO, P.PRODUTO_VENDA, 
                        P.PRODUTO_QTD, P.ATIVO, P.PRODUTO_DT_CRIACAO, P.PRODUTO_DT_ALT,
                        U.UN_MEDIDA_ID, U.UN_MEDIDA_NOME,
                        C.CATEGORIA_ID, C.CATEGORIA_NOME,
                        M.MARCA_ID, M.MARCA_NOME
                    FROM PRODUTO P
                    INNER JOIN UNIDADE_MEDIDA U ON P.UN_MEDIDA_ID = U.UN_MEDIDA_ID
                    INNER JOIN CATEGORIA C ON P.CATEGORIA_ID = C.CATEGORIA_ID
                    INNER JOIN MARCA M ON P.MARCA_ID = M.MARCA_ID";

                using (SqlCommand cmd = new SqlCommand(sqlProdutos, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Produto prod = new Produto
                            {
                                Id = Convert.ToInt32(dr["PRODUTO_ID"]),
                                Nome = dr["PRODUTO_NOME"].ToString(),
                                Codbar = dr["PRODUTO_CODBAR"].ToString(),
                                CustoAnterior = Convert.ToDouble(dr["PRODUTO_CUSTO_ANTERIOR"]),
                                Custo = Convert.ToDouble(dr["PRODUTO_CUSTO"]),
                                PercentLucro = Convert.ToDouble(dr["PRODUTO_PERCENT_LUCRO"]),
                                Venda = Convert.ToDouble(dr["PRODUTO_VENDA"]),
                                Estoque = Convert.ToInt32(dr["PRODUTO_QTD"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"]),
                                DtCriacao = Convert.ToDateTime(dr["PRODUTO_DT_CRIACAO"]),
                                DtAlt = dr["PRODUTO_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["PRODUTO_DT_ALT"]),
                                AUnidadeMedida = new UnidadeMedida
                                {
                                    Id = Convert.ToInt32(dr["UN_MEDIDA_ID"]),
                                    Nome = dr["UN_MEDIDA_NOME"].ToString()
                                },
                                ACategoria = new Categoria
                                {
                                    Id = Convert.ToInt32(dr["CATEGORIA_ID"]),
                                    Nome = dr["CATEGORIA_NOME"].ToString()
                                },
                                AMarca = new Marca
                                {
                                    Id = Convert.ToInt32(dr["MARCA_ID"]),
                                    Nome = dr["MARCA_NOME"].ToString()
                                }
                            };
                            produtos.Add(prod.Id, prod);
                        }
                    }
                }

                string sqlFornecedores = @"
                SELECT 
                    PF.PRODUTO_ID,
                    F.FORNECEDOR_ID, 
                    F.FORNECEDOR_NOME_RS,
                    F.FORNECEDOR_CPF_CNPJ
                FROM PRODUTO_FORNECEDOR PF
                INNER JOIN FORNECEDOR F ON PF.FORNECEDOR_ID = F.FORNECEDOR_ID";

                using (SqlCommand cmd = new SqlCommand(sqlFornecedores, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int produtoId = Convert.ToInt32(dr["PRODUTO_ID"]);

                            // Se o dicionário de produtos contiver este ID, adiciona o fornecedor à sua lista
                            if (produtos.ContainsKey(produtoId))
                            {
                                Fornecedor forn = new Fornecedor
                                {
                                    Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString(),
                                    CpfCnpj = dr["FORNECEDOR_CPF_CNPJ"].ToString()
                                };
                                produtos[produtoId].OFornecedor.Add(forn);
                            }
                        }
                    }
                }
            }
            return produtos.Values.ToList();
        }

        public void AtualizarEstoqueCusto(ItensNotaEntrada item, SqlConnection cnn, SqlTransaction trans)
        {
            string sql = @"
                UPDATE PRODUTO
                SET 
                    PRODUTO_QTD = PRODUTO_QTD + @QtdAdicionada,
                    PRODUTO_CUSTO_ANTERIOR = PRODUTO_CUSTO,
                    PRODUTO_CUSTO = 
                        CASE 
                            WHEN (PRODUTO_QTD + @QtdAdicionada) <= 0 THEN 0
                            ELSE ((PRODUTO_CUSTO * PRODUTO_QTD) + (@CustoReal * @QtdAdicionada)) / (PRODUTO_QTD + @QtdAdicionada)
                        END,
                    PRODUTO_VENDA =
                        CASE 
                            WHEN (PRODUTO_QTD + @QtdAdicionada) <= 0 THEN 0
                            ELSE 
                                -- venda = novo_custo * (1 + percent/100)
                                ROUND(
                                    (
                                        ((PRODUTO_CUSTO * PRODUTO_QTD) + (@CustoReal * @QtdAdicionada)) 
                                        / NULLIF((PRODUTO_QTD + @QtdAdicionada), 0)
                                    ) * (1 + (PRODUTO_PERCENT_LUCRO / 100.0)), 2
                                )
                        END
                WHERE PRODUTO_ID = @IdProduto";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@QtdAdicionada", item.Qtd);
                cmd.Parameters.AddWithValue("@CustoReal", item.CustoUnitarioReal);
                cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void ReverterEstoqueCusto(ItensNotaEntrada item, SqlConnection cnn, SqlTransaction trans)
        {
            string sql = @"
                DECLARE @CustoMedioAtual DECIMAL(18,6);
                DECLARE @EstoqueAtual INT;
                DECLARE @NovoCustoMedio DECIMAL(18,6);
                DECLARE @CustoAnteriorNaCompra DECIMAL(18,6);
                DECLARE @NovoEstoque INT;

                SELECT 
                    @CustoMedioAtual = PRODUTO_CUSTO, 
                    @EstoqueAtual = PRODUTO_QTD,
                    @CustoAnteriorNaCompra = PRODUTO_CUSTO_ANTERIOR
                FROM PRODUTO WITH (UPDLOCK) 
                WHERE PRODUTO_ID = @IdProduto;

                SET @NovoEstoque = @EstoqueAtual - @QtdRemovida;

                IF (@NovoEstoque > 0)
                BEGIN
                    SET @NovoCustoMedio = ((@CustoMedioAtual * @EstoqueAtual) - (@CustoRealItem * @QtdRemovida)) / @NovoEstoque;
                END
                ELSE
                BEGIN
                    SET @NovoCustoMedio = @CustoAnteriorNaCompra;
                END

                UPDATE PRODUTO
                SET 
                    PRODUTO_QTD = @NovoEstoque,
                    PRODUTO_CUSTO = @NovoCustoMedio,
                    PRODUTO_VENDA = 
                        ROUND(@NovoCustoMedio * (1 + (PRODUTO_PERCENT_LUCRO / 100.0)), 2)
                WHERE PRODUTO_ID = @IdProduto";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@QtdRemovida", item.Qtd);
                cmd.Parameters.AddWithValue("@CustoRealItem", item.CustoUnitarioReal);
                cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void BaixarEstoqueSaida(ItensNotaSaida item, SqlConnection cnn, SqlTransaction trans)
        {
            const string sql = @"UPDATE PRODUTO 
                         SET PRODUTO_QTD = PRODUTO_QTD - @Qtd
                         WHERE PRODUTO_ID = @IdProduto";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@Qtd", item.Qtd);
                cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void ReporEstoqueSaida(ItensNotaSaida item, SqlConnection cnn, SqlTransaction trans)
        {
            const string sql = @"UPDATE PRODUTO 
                         SET PRODUTO_QTD = PRODUTO_QTD + @Qtd
                         WHERE PRODUTO_ID = @IdProduto";
            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@Qtd", item.Qtd);
                cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                cmd.ExecuteNonQuery();
            }
        }


        public Produto BuscarPorId(int id)
        {
            Produto prod = null;
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return null;

                // 1) Produto + todas as infos das classes aninhadas (UM, Categoria, Marca)
                string sqlProduto = @"
                SELECT 
                    -- PRODUTO
                    P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_CODBAR, P.PRODUTO_CUSTO_ANTERIOR, P.PRODUTO_CUSTO, 
                    P.PRODUTO_PERCENT_LUCRO, P.PRODUTO_VENDA, P.PRODUTO_QTD, P.ATIVO AS P_ATIVO, 
                    P.PRODUTO_DT_CRIACAO AS P_DT_CRIACAO, P.PRODUTO_DT_ALT AS P_DT_ALT,

                    -- UNIDADE_MEDIDA
                    U.UN_MEDIDA_ID AS UM_ID, U.UN_MEDIDA_NOME AS UM_NOME,
                    U.ATIVO AS UM_ATIVO, U.UN_MEDIDA_DT_CRIACAO AS UM_DT_CRIACAO, U.UN_MEDIDA_DT_ALT AS UM_DT_ALT,

                    -- CATEGORIA
                    C.CATEGORIA_ID AS CAT_ID, C.CATEGORIA_NOME AS CAT_NOME,
                    C.ATIVO AS CAT_ATIVO, C.CATEGORIA_DT_CRIACAO AS CAT_DT_CRIACAO, C.CATEGORIA_DT_ALT AS CAT_DT_ALT,

                    -- MARCA
                    M.MARCA_ID AS MARCA_ID, M.MARCA_NOME AS MARCA_NOME,
                    M.ATIVO AS MARCA_ATIVO, M.MARCA_DT_CRIACAO AS MARCA_DT_CRIACAO, M.MARCA_DT_ALT AS MARCA_DT_ALT

                FROM PRODUTO P
                INNER JOIN UNIDADE_MEDIDA U ON P.UN_MEDIDA_ID = U.UN_MEDIDA_ID
                INNER JOIN CATEGORIA      C ON P.CATEGORIA_ID = C.CATEGORIA_ID
                INNER JOIN MARCA         M ON P.MARCA_ID = M.MARCA_ID
                WHERE P.PRODUTO_ID = @Id AND P.ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sqlProduto, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            prod = new Produto
                            {
                                // PRODUTO
                                Id = Convert.ToInt32(dr["PRODUTO_ID"]),
                                Nome = dr["PRODUTO_NOME"].ToString(),
                                Codbar = dr["PRODUTO_CODBAR"].ToString(),
                                CustoAnterior = Convert.ToDouble(dr["PRODUTO_CUSTO_ANTERIOR"]),
                                Custo = Convert.ToDouble(dr["PRODUTO_CUSTO"]),
                                PercentLucro = Convert.ToDouble(dr["PRODUTO_PERCENT_LUCRO"]),
                                Venda = Convert.ToDouble(dr["PRODUTO_VENDA"]),
                                Estoque = Convert.ToInt32(dr["PRODUTO_QTD"]),
                                Ativo = Convert.ToBoolean(dr["P_ATIVO"]),
                                DtCriacao = Convert.ToDateTime(dr["P_DT_CRIACAO"]),
                                DtAlt = dr["P_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["P_DT_ALT"]),

                                // UNIDADE_MEDIDA (classe aninhada completa)
                                AUnidadeMedida = new UnidadeMedida
                                {
                                    Id = Convert.ToInt32(dr["UM_ID"]),
                                    Nome = dr["UM_NOME"].ToString(),
                                    Ativo = dr["UM_ATIVO"] == DBNull.Value ? true : Convert.ToBoolean(dr["UM_ATIVO"]),
                                    DtCriacao = dr["UM_DT_CRIACAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["UM_DT_CRIACAO"]),
                                    DtAlt = dr["UM_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["UM_DT_ALT"])
                                },

                                // CATEGORIA (classe aninhada completa)
                                ACategoria = new Categoria
                                {
                                    Id = Convert.ToInt32(dr["CAT_ID"]),
                                    Nome = dr["CAT_NOME"].ToString(),
                                    Ativo = dr["CAT_ATIVO"] == DBNull.Value ? true : Convert.ToBoolean(dr["CAT_ATIVO"]),
                                    DtCriacao = dr["CAT_DT_CRIACAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CAT_DT_CRIACAO"]),
                                    DtAlt = dr["CAT_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CAT_DT_ALT"])
                                },

                                // MARCA (classe aninhada completa)
                                AMarca = new Marca
                                {
                                    Id = Convert.ToInt32(dr["MARCA_ID"]),
                                    Nome = dr["MARCA_NOME"].ToString(),
                                    Ativo = dr["MARCA_ATIVO"] == DBNull.Value ? true : Convert.ToBoolean(dr["MARCA_ATIVO"]),
                                    DtCriacao = dr["MARCA_DT_CRIACAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["MARCA_DT_CRIACAO"]),
                                    DtAlt = dr["MARCA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["MARCA_DT_ALT"])
                                }
                            };
                        }
                    }
                }
            }
            return prod;
        }
    }
}