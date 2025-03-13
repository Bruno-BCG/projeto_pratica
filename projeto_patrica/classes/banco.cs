using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pratica.classes
{
	internal class banco
	{
		private static readonly string connectionString =
			"Data Source=localhost\\SQLEXPRESS;Initial Catalog=projeto_pratica;Integrated Security=True;Encrypt=False";

		/// <summary>
		/// Opens a connection to the MSSQL database and shows a message box with the status.
		/// </summary> 
		/// <returns>An open SqlConnection object.</returns>
		public static SqlConnection Abrir()
		{
			SqlConnection cnn = new SqlConnection(connectionString);
			try
			{
				cnn.Open();
				return cnn;
			}
			catch (SqlException ex)
			{
				MessageBox.Show("Erro ao conectar ao banco de dados:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// Closes the database connection.
		/// </summary>
		public static void Fechar(SqlConnection cnn)
		{
			if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
			{
				cnn.Close();
				MessageBox.Show("Conexão fechada com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}

