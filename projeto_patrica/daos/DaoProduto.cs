using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string sql;
            char operacao = 'I';

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (aProduto.Id == 0)
                {
                    sql = @"INSERT INTO PRODUTO 
                            (PRODUTO_NOME, PRODUTO_CODBAR, FORNECEDOR_ID, UN_MEDIDA_ID, CATEGORIA_ID, MARCA_ID, 
                             PRODUTO_CUSTO, PRODUTO_VENDA, PRODUTO_QTD, PRODUTO_DT_CRIACAO)
                            OUTPUT INSERTED.PRODUTO_ID
                            VALUES (@nome, @codbar, @fornecedorId, @unMedidaId, @categoriaId, @marcaId, 
                                    @custo, @venda, @qtd, @dtCriacao)";
                }
                else
                {
                    operacao = 'U';
                    sql = @"UPDATE PRODUTO SET 
                            PRODUTO_NOME = @nome, PRODUTO_CODBAR = @codbar, FORNECEDOR_ID = @fornecedorId, 
                            UN_MEDIDA_ID = @unMedidaId, CATEGORIA_ID = @categoriaId, MARCA_ID = @marcaId, 
                            PRODUTO_CUSTO = @custo, PRODUTO_VENDA = @venda, PRODUTO_QTD = @qtd, 
                            PRODUTO_DT_ALT = @dtAlt
                            WHERE PRODUTO_ID = @id";
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", aProduto.Nome);
                cmd.Parameters.AddWithValue("@codbar", aProduto.Codbar);
                cmd.Parameters.AddWithValue("@fornecedorId", aProduto.OFornecedor.Id);
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
                }
                else
                {
                    aProduto.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtAlt", aProduto.DtAlt);
                    cmd.Parameters.AddWithValue("@id", aProduto.Id);
                }

                try
                {
                    if (operacao == 'I')
                    {
                        aProduto.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        resultado = aProduto.Id.ToString();
                    }
                    else
                    {

                        cmd.ExecuteNonQuery();
                        resultado = aProduto.Id.ToString();
                    }
                }
                catch (SqlException ex)
                {
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
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

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
            List<Produto> lista = new List<Produto>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sql = @"
                SELECT 
                    P.PRODUTO_ID, P.PRODUTO_NOME, P.PRODUTO_CODBAR, P.PRODUTO_CUSTO, P.PRODUTO_VENDA, 
                    P.PRODUTO_QTD, P.PRODUTO_DT_CRIACAO, P.PRODUTO_DT_ALT,
                    F.FORNECEDOR_ID, F.FORNECEDOR_NOME_RS,
                    U.UN_MEDIDA_ID, U.UN_MEDIDA_NOME,
                    C.CATEGORIA_ID, C.CATEGORIA_NOME,
                    M.MARCA_ID, M.MARCA_NOME
                FROM PRODUTO P
                INNER JOIN FORNECEDOR F ON P.FORNECEDOR_ID = F.FORNECEDOR_ID
                INNER JOIN UNIDADE_MEDIDA U ON P.UN_MEDIDA_ID = U.UN_MEDIDA_ID
                INNER JOIN CATEGORIA C ON P.CATEGORIA_ID = C.CATEGORIA_ID
                INNER JOIN MARCA M ON P.MARCA_ID = M.MARCA_ID";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Produto
                            {
                                Id = Convert.ToInt32(dr["PRODUTO_ID"]),
                                Nome = dr["PRODUTO_NOME"].ToString(),
                                Codbar = dr["PRODUTO_CODBAR"].ToString(),
                                Custo = Convert.ToDouble(dr["PRODUTO_CUSTO"]),
                                Venda = Convert.ToDouble(dr["PRODUTO_VENDA"]),
                                Estoque = Convert.ToInt32(dr["PRODUTO_QTD"]),
                                DtCriacao = Convert.ToDateTime(dr["PRODUTO_DT_CRIACAO"]),
                                DtAlt = dr["PRODUTO_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["PRODUTO_DT_ALT"]),
                                OFornecedor = new Fornecedor
                                {
                                    Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                    NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString()
                                },
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
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}