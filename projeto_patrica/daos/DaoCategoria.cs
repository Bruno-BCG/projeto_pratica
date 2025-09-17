using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projeto_pratica.classes;

namespace projeto_pratica.daos
{
    internal class DaoCategoria : Dao
    {
        public DaoCategoria()
        {
        }

        public override string Salvar(object obj)
        {
            Categoria aCategoria = (Categoria)obj;
            string resultado = "";
            string sql;
            char operacao = 'I';

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (aCategoria.Id == 0)
                {
                    sql = @"INSERT INTO CATEGORIA 
                            (CATEGORIA_NOME, CATEGORIA_DT_CRIACAO)
                            OUTPUT INSERTED.CATEGORIA_ID
                            VALUES (@nome, @dtCriacao)";
                }
                else
                {
                    operacao = 'U';
                    sql = @"UPDATE CATEGORIA SET 
                            CATEGORIA_NOME = @nome, CATEGORIA_DT_ALT = @dtAlt
                            WHERE CATEGORIA_ID = @id";
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", aCategoria.Nome);

                if (operacao == 'I')
                {
                    aCategoria.DtCriacao = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtCriacao", aCategoria.DtCriacao);
                }
                else
                {
                    aCategoria.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtAlt", aCategoria.DtAlt);
                    cmd.Parameters.AddWithValue("@id", aCategoria.Id);
                }

                try
                {
                    if (operacao == 'I')
                    {
                        aCategoria.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        resultado = aCategoria.Id.ToString();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        resultado = aCategoria.Id.ToString();
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
            Categoria aCategoria = (Categoria)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                string sql = "DELETE FROM CATEGORIA WHERE CATEGORIA_ID = @id";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", aCategoria.Id);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    resultado = (rows > 0) ? "OK" : "Categoria não encontrada.";
                }
                catch (SqlException ex)
                {
                    resultado = "Erro ao excluir: " + ex.Message;
                }
            }
            return resultado;
        }

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sql = "SELECT CATEGORIA_ID, CATEGORIA_NOME, CATEGORIA_DT_CRIACAO, CATEGORIA_DT_ALT FROM CATEGORIA";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria
                            {
                                Id = Convert.ToInt32(dr["CATEGORIA_ID"]),
                                Nome = dr["CATEGORIA_NOME"].ToString(),
                                DtCriacao = Convert.ToDateTime(dr["CATEGORIA_DT_CRIACAO"]),
                                DtAlt = dr["CATEGORIA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CATEGORIA_DT_ALT"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}