using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projeto_pratica.classes;

namespace projeto_pratica.daos
{
    internal class DaoUniMedida : Dao
    {
        public DaoUniMedida()
        {
        }

        public override string Salvar(object obj)
        {
            UnidadeMedida aUniMedida = (UnidadeMedida)obj;
            string resultado = "";
            string sql;
            char operacao = 'I';

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (aUniMedida.Id == 0)
                {
                    sql = @"INSERT INTO UNIDADE_MEDIDA 
                    (UN_MEDIDA_NOME, UN_MEDIDA_DT_CRIACAO)
                    OUTPUT INSERTED.UN_MEDIDA_ID
                    VALUES (@nome, @dtCriacao)";
                }
                else
                {
                    operacao = 'U';
                    sql = @"UPDATE UNIDADE_MEDIDA SET 
                    UN_MEDIDA_NOME = @nome, UN_MEDIDA_DT_ALT = @dtAlt
                    WHERE UN_MEDIDA_ID = @id";
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", aUniMedida.Nome);

                if (operacao == 'I')
                {
                    // SOLUÇÃO: Define a data de criação com a data/hora atual
                    aUniMedida.DtCriacao = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtCriacao", aUniMedida.DtCriacao);
                }
                else
                {
                    // SOLUÇÃO: Define a data de alteração com a data/hora atual
                    aUniMedida.DtAlt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@dtAlt", aUniMedida.DtAlt);
                    cmd.Parameters.AddWithValue("@id", aUniMedida.Id);
                }

                try
                {
                    if (operacao == 'I')
                    {
                        aUniMedida.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        resultado = aUniMedida.Id.ToString();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        resultado = aUniMedida.Id.ToString();
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
            UnidadeMedida aUniMedida = (UnidadeMedida)obj;
            string resultado = "";

            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null)
                    return "Erro ao conectar ao banco de dados.";

                string sql = "DELETE FROM UNIDADE_MEDIDA WHERE UN_MEDIDA_ID = @id";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", aUniMedida.Id);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    resultado = (rows > 0) ? "OK" : "Unidade de Medida não encontrada.";
                }
                catch (SqlException ex)
                {
                    resultado = "Erro ao excluir: " + ex.Message;
                }
            }
            return resultado;
        }

        public List<UnidadeMedida> Listar()
        {
            List<UnidadeMedida> lista = new List<UnidadeMedida>();

            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null)
                    throw new Exception("Erro ao conectar ao Banco de dados.");

                string sql = "SELECT UN_MEDIDA_ID, UN_MEDIDA_NOME, UN_MEDIDA_DT_CRIACAO, UN_MEDIDA_DT_ALT FROM UNIDADE_MEDIDA";

                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new UnidadeMedida
                            {
                                Id = Convert.ToInt32(dr["UN_MEDIDA_ID"]),
                                Nome = dr["UN_MEDIDA_NOME"].ToString(),
                                DtCriacao = Convert.ToDateTime(dr["UN_MEDIDA_DT_CRIACAO"]),
                                DtAlt = dr["UN_MEDIDA_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["UN_MEDIDA_DT_ALT"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}