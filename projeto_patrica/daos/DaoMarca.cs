using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projeto_pratica.classes;

namespace projeto_pratica.daos
{
    internal class DaoMarca : Dao
    {
        public DaoMarca()
        {
        }

        public override string Salvar(object obj)
        {
            Marca aMarca = (Marca)obj;
            string resultado = "";
            string sql;
            char operacao = 'I';

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (aMarca.Id == 0)
                {
                    sql = @"INSERT INTO MARCA 
                            (MARCA_NOME, MARCA_DT_CRIACAO)
                            OUTPUT INSERTED.MARCA_ID
                            VALUES (@nome, @dtCriacao)";
                }
                else
                {
                    operacao = 'U';
                    sql = @"UPDATE MARCA SET 
                            MARCA_NOME = @nome, MARCA_DT_ALT = @dtAlt
                            WHERE MARCA_ID = @id";
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", aMarca.Nome);

                if (operacao == 'I')
                {
                    aMarca.DtCriacao = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtCriacao", aMarca.DtCriacao);
                }
                else
                {
                    aMarca.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtAlt", aMarca.DtAlt);
                    cmd.Parameters.AddWithValue("@id", aMarca.Id);
                }

                try
                {
                    if (operacao == 'I')
                    {
                        aMarca.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        resultado = aMarca.Id.ToString();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        resultado = aMarca.Id.ToString();
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
            Marca aMarca = (Marca)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                string sql = "DELETE FROM MARCA WHERE MARCA_ID = @id";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", aMarca.Id);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    resultado = (rows > 0) ? "OK" : "Marca não encontrada.";
                }
                catch (SqlException ex)
                {
                    resultado = "Erro ao excluir: " + ex.Message;
                }
            }
            return resultado;
        }

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sql = "SELECT MARCA_ID, MARCA_NOME, MARCA_DT_CRIACAO, MARCA_DT_ALT FROM MARCA";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Marca
                            {
                                Id = Convert.ToInt32(dr["MARCA_ID"]),
                                Nome = dr["MARCA_NOME"].ToString(),
                                DtCriacao = Convert.ToDateTime(dr["MARCA_DT_CRIACAO"]),
                                DtAlt = dr["MARCA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["MARCA_DT_ALT"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}