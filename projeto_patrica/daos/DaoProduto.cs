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
                                 PRODUTO_CUSTO, PRODUTO_VENDA, PRODUTO_QTD, PRODUTO_DT_CRIACAO)
                                OUTPUT INSERTED.PRODUTO_ID
                                VALUES (@nome, @codbar, @unMedidaId, @categoriaId, @marcaId, 
                                        @custo, @venda, @qtd, @dtCriacao)";
                    }
                    else
                    {
                        operacao = 'U';
                        // SQL de Atualização sem o FORNECEDOR_ID
                        sql = @"UPDATE PRODUTO SET 
                                PRODUTO_NOME = @nome, PRODUTO_CODBAR = @codbar, 
                                UN_MEDIDA_ID = @unMedidaId, CATEGORIA_ID = @categoriaId, MARCA_ID = @marcaId, 
                                PRODUTO_CUSTO = @custo, PRODUTO_VENDA = @venda, PRODUTO_QTD = @qtd, 
                                PRODUTO_DT_ALT = @dtAlt
                                WHERE PRODUTO_ID = @id";
                    }

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@nome", aProduto.Nome);
                    cmd.Parameters.AddWithValue("@codbar", aProduto.Codbar);
                    cmd.Parameters.AddWithValue("@unMedidaId", aProduto.AUnidadeMedida.Id);
                    cmd.Parameters.AddWithValue("@categoriaId", aProduto.ACategoria.Id);
                    cmd.Parameters.AddWithValue("@marcaId", aProduto.AMarca.Id);
                    cmd.Parameters.AddWithValue("@custo", aProduto.Custo);
                    cmd.Parameters.AddWithValue("@venda", aProduto.Venda);
                    cmd.Parameters.AddWithValue("@qtd", aProduto.Estoque);

                    if (operacao == 'I')
                    {
                        aProduto.DtCriacao = DateTime.Now;
                        cmd.Parameters.AddWithValue("@dtCriacao", aProduto.DtCriacao);
                        // Executa e obtém o novo ID do produto
                        aProduto.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        aProduto.DtAlt = DateTime.Now;
                        cmd.Parameters.AddWithValue("@dtAlt", aProduto.DtAlt);
                        cmd.Parameters.AddWithValue("@id", aProduto.Id);
                        cmd.ExecuteNonQuery();

                        // Para atualização, primeiro removemos os fornecedores antigos para depois inserir os novos
                        string deleteFornSql = "DELETE FROM PRODUTO_FORNECEDOR WHERE PRODUTO_ID = @produtoId";
                        SqlCommand deleteCmd = new SqlCommand(deleteFornSql, cnn, transaction);
                        deleteCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Agora, insere os fornecedores da lista na tabela de associação
                    if (aProduto.OFornecedor != null && aProduto.OFornecedor.Count > 0)
                    {
                        string insertFornSql = "INSERT INTO PRODUTO_FORNECEDOR (PRODUTO_ID, FORNECEDOR_ID) VALUES (@produtoId, @fornecedorId)";
                        foreach (Fornecedor forn in aProduto.OFornecedor)
                        {
                            SqlCommand fornCmd = new SqlCommand(insertFornSql, cnn, transaction);
                            fornCmd.Parameters.AddWithValue("@produtoId", aProduto.Id);
                            fornCmd.Parameters.AddWithValue("@fornecedorId", forn.Id);
                            fornCmd.ExecuteNonQuery();
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
                    P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_CODBAR, P.PRODUTO_CUSTO, P.PRODUTO_VENDA, 
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
                                Custo = Convert.ToDouble(dr["PRODUTO_CUSTO"]),
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
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString(), // A classe Fornecedor herda "Nome" de Pessoa
                                    CpfCnpj = dr["FORNECEDOR_CPF_CNPJ"].ToString() // Exemplo, pode popular outros campos
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
    }
}