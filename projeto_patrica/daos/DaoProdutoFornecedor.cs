using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
    internal class DaoProdutoFornecedor
    {
        public void SalvarCustoFornecedor(ItensNotaEntrada item, int fornecedorId, DateTime dataCompra, SqlConnection cnn, SqlTransaction trans)
        {
   
            string sql = @"
                MERGE INTO PRODUTO_FORNECEDOR AS T
                USING (SELECT @IdProduto AS PRODUTO_ID, @IdFornecedor AS FORNECEDOR_ID) AS S
                ON (T.PRODUTO_ID = S.PRODUTO_ID AND T.FORNECEDOR_ID = S.FORNECEDOR_ID)
                WHEN MATCHED THEN
                    UPDATE SET 
                        CUSTO_ULT_COMPRA = T.CUSTO_ATUAL_COMPRA,
                        DT_ULT_COMPRA = @DataCompra,
                        CUSTO_ATUAL_COMPRA = @CustoAtual,
                        ATIVO = 1
                WHEN NOT MATCHED THEN
                    INSERT (PRODUTO_ID, FORNECEDOR_ID, CUSTO_ULT_COMPRA, DT_ULT_COMPRA, CUSTO_ATUAL_COMPRA, ATIVO) 
                    VALUES (@IdProduto, @IdFornecedor, @CustoAtual, @DataCompra, @CustoAtual, 1);
            ";

            using (SqlCommand cmd = new SqlCommand(sql, cnn, trans))
            {
                cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                cmd.Parameters.AddWithValue("@IdFornecedor", fornecedorId);
                cmd.Parameters.AddWithValue("@DataCompra", dataCompra.Date);
                cmd.Parameters.AddWithValue("@CustoAtual", item.CustoUnitarioReal);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
