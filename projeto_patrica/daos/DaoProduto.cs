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

                        // --- INSERÇÃO DE NOVOS FORNECEDORES (para novo produto) ---
                        if (aProduto.OFornecedor != null && aProduto.OFornecedor.Count > 0)
                        {
                            // SQL de INSERT atualizado com as novas colunas
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
                                    // NOTA: Se o 'forn' tivesse os custos, eles seriam adicionados aqui
                                    fornCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else // 'U' (Operação de Update)
                    {
                        aProduto.DtAlt = DateTime.Now;
                        cmd.Parameters.AddWithValue("@dtAlt", aProduto.DtAlt);
                        cmd.Parameters.AddWithValue("@id", aProduto.Id);
                        cmd.ExecuteNonQuery();

                        // --- LÓGICA DE SINCRONIZAÇÃO (ATIVA/DESATIVA) ---
                        // Substitui o bloco "DELETE FROM PRODUTO_FORNECEDOR"

                        // 1. Desativa TODOS os fornecedores associados a este produto.
                        string deactivateSql = "UPDATE PRODUTO_FORNECEDOR SET ATIVO = 0 WHERE PRODUTO_ID = @produtoId";
                        using (SqlCommand deactivateCmd = new SqlCommand(deactivateSql, cnn, transaction))
                        {
                            deactivateCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                            deactivateCmd.ExecuteNonQuery();
                        }

                        // 2. Agora, "Upsert" (Update/Insert) os fornecedores da lista desejada,
                        //    marcando-os (ou inserindo-os) como ATIVO = 1.
                        if (aProduto.OFornecedor != null && aProduto.OFornecedor.Count > 0)
                        {
                            // SQL para reativar um fornecedor existente
                            string updateSql = @"
                            UPDATE PRODUTO_FORNECEDOR 
                            SET ATIVO = 1
                            WHERE PRODUTO_ID = @produtoId AND FORNECEDOR_ID = @fornecedorId";

                            // SQL para inserir um novo fornecedor (com valores padrão)
                            string insertSql = @"
                            INSERT INTO PRODUTO_FORNECEDOR 
                                (PRODUTO_ID, FORNECEDOR_ID, CUSTO_ULT_COMPRA, DT_ULT_COMPRA, CUSTO_ATUAL_COMPRA, ATIVO) 
                            VALUES 
                                (@produtoId, @fornecedorId, 0, GETDATE(), 0, 1)"; // ATIVO = 1

                            foreach (Fornecedor forn in aProduto.OFornecedor)
                            {
                                int rowsAffected = 0;

                                // Tenta ATUALIZAR (reativar) primeiro
                                using (SqlCommand updateCmd = new SqlCommand(updateSql, cnn, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                                    updateCmd.Parameters.AddWithValue("@fornecedorId", forn.Id);
                                    // Se 'forn' tivesse o custo:
                                    // updateCmd.Parameters.AddWithValue("@custoAtual", forn.CustoAtual); 
                                    rowsAffected = updateCmd.ExecuteNonQuery();
                                }

                                // Se 0 linhas foram afetadas, o relacionamento não existe. INSERE.
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

                    transaction.Commit(); // Confirma a transação
                    resultado = aProduto.Id.ToString();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); // Desfaz a transação em caso de erro
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

                // A exclusão em cascata (ON DELETE CASCADE) na FK da tabela PRODUTO_FORNECEDOR
                // já remove as associações. Se não tivesse, seria necessário um DELETE manual aqui.
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

                // 1. Busca todos os produtos com suas associações diretas (Marca, Categoria, etc.)
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
                                CustoAnterior= Convert.ToDouble(dr["PRODUTO_CUSTO_ANTERIOR"]),
                                Custo = Convert.ToDouble(dr["PRODUTO_CUSTO"]),
                                PercentLucro= Convert.ToDouble(dr["PRODUTO_PERCENT_LUCRO"]),
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

                // 2. Busca todos os fornecedores associados aos produtos
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
            // Retorna a lista de valores do dicionário
            return produtos.Values.ToList();
        }

        public void AtualizarEstoqueCusto(ItensNotaEntrada item, SqlConnection cnn, SqlTransaction trans)
        {
            // Lógica do 'AtualizarProduto' do Dao_compra.cs, traduzida para T-SQL
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
                    PRODUTO_PERCENT_LUCRO = 
                        CASE 
                            WHEN ((PRODUTO_CUSTO * PRODUTO_QTD) + (@CustoReal * @QtdAdicionada)) / (PRODUTO_QTD + @QtdAdicionada) <= 0 THEN 0
                            ELSE ((PRODUTO_VENDA / (((PRODUTO_CUSTO * PRODUTO_QTD) + (@CustoReal * @QtdAdicionada)) / (PRODUTO_QTD + @QtdAdicionada))) - 1) * 100
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
            // Lógica de 'ReverterAtualizacaoProduto' do Dao_compra.cs, traduzida para T-SQL
            string sql = @"
                DECLARE @CustoMedioAtual DECIMAL(18,2);
                DECLARE @EstoqueAtual INT;
                DECLARE @NovoCustoMedio DECIMAL(18,2);
                DECLARE @CustoAnteriorNaCompra DECIMAL(18,2);

                SELECT 
                    @CustoMedioAtual = PRODUTO_CUSTO, 
                    @EstoqueAtual = PRODUTO_QTD,
                    @CustoAnteriorNaCompra = PRODUTO_CUSTO_ANTERIOR
                FROM PRODUTO WITH (UPDLOCK) 
                WHERE PRODUTO_ID = @IdProduto;

                DECLARE @NovoEstoque INT = @EstoqueAtual - @QtdRemovida;

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
                    PRODUTO_CUSTO = @NovoCustoMedio
                WHERE PRODUTO_ID = @IdProduto";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@QtdRemovida", item.Qtd);
                cmd.Parameters.AddWithValue("@CustoRealItem", item.CustoUnitarioReal);
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

                // 1. Busca o produto principal
                string sqlProduto = @"
                SELECT 
                    P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_CODBAR, P.PRODUTO_CUSTO_ANTERIOR, P.PRODUTO_CUSTO, P.PRODUTO_PERCENT_LUCRO, P.PRODUTO_VENDA, 
                    P.PRODUTO_QTD, P.ATIVO, P.PRODUTO_DT_CRIACAO, P.PRODUTO_DT_ALT,
                    U.UN_MEDIDA_ID, U.UN_MEDIDA_NOME,
                    C.CATEGORIA_ID, C.CATEGORIA_NOME,
                    M.MARCA_ID, M.MARCA_NOME
                FROM PRODUTO P
                INNER JOIN UNIDADE_MEDIDA U ON P.UN_MEDIDA_ID = U.UN_MEDIDA_ID
                INNER JOIN CATEGORIA C ON P.CATEGORIA_ID = C.CATEGORIA_ID
                INNER JOIN MARCA M ON P.MARCA_ID = M.MARCA_ID
                WHERE P.PRODUTO_ID = @Id AND P.ATIVO = 1";

                using (SqlCommand cmd = new SqlCommand(sqlProduto, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Usa IF em vez de WHILE
                        {
                            prod = new Produto
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
                                AUnidadeMedida = new UnidadeMedida { /* Preencher se necessário */ },
                                ACategoria = new Categoria { /* Preencher se necessário */ },
                                AMarca = new Marca { /* Preencher se necessário */ }
                            };
                        }
                    }
                }

                // 2. Se o produto foi encontrado, busca seus fornecedores (opcional, mas bom)
                if (prod != null)
                {
                    string sqlFornecedores = @"
                    SELECT F.FORNECEDOR_ID, F.FORNECEDOR_NOME_RS
                    FROM PRODUTO_FORNECEDOR PF
                    INNER JOIN FORNECEDOR F ON PF.FORNECEDOR_ID = F.FORNECEDOR_ID
                    WHERE PF.PRODUTO_ID = @Id AND PF.ATIVO = 1";

                    using (SqlCommand cmd = new SqlCommand(sqlFornecedores, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                prod.OFornecedor.Add(new Fornecedor
                                {
                                    Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return prod;
        }
    }
}