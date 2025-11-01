using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.service
{
    internal class NotaEntradaService
    {
        private DaoNotaEntrada _daoNotaEntrada;
        private DaoProduto _daoProduto;
        private DaoProdutoFornecedor _daoProdForn;
        private DaoContasPagar daoContasPagar; 
        public NotaEntradaService()
        {
            _daoNotaEntrada = new DaoNotaEntrada();
            _daoProduto = new DaoProduto();
            _daoProdForn = new DaoProdutoFornecedor();
            daoContasPagar = new DaoContasPagar(); 
        }

        public string Salvar(NotaEntrada aNota)
        {
            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return "Erro ao conectar ao banco de dados.";

                SqlTransaction transaction = cnn.BeginTransaction();

                try
                {
                    List<ItensNotaEntrada> itensAntigos = new List<ItensNotaEntrada>();
                    if (aNota.Id > 0)
                    {
                        itensAntigos = _daoNotaEntrada.ListarItensAtivos(aNota.Id, cnn, transaction);

                        foreach (var itemAntigo in itensAntigos)
                        {
                            _daoProduto.ReverterEstoqueCusto(itemAntigo, cnn, transaction);
                        }
                    }

                    _daoNotaEntrada.SalvarCabecalho(aNota, cnn, transaction);

                    if (aNota.Id > 0)
                    {
                        _daoNotaEntrada.InativarItensAntigos(aNota.Id, cnn, transaction);
                    }

                    if (aNota.Id > 0)
                    {
                        daoContasPagar.InativarParcelas(aNota.Id, aNota.MotivoCancelamento, cnn, transaction);
                    }
                    
                    // caso a nota esteja sendo deletada
                    if (!aNota.Ativo)
                    {
                        transaction.Commit(); 
                        return aNota.Id.ToString();
                    }

                    decimal totalCustosAdicionais = aNota.ValorFrete + aNota.ValorSeguro + aNota.OutrasDespesas;
                    decimal valorTotalItens = aNota.ItensDaNota.Sum(i => i.ValorTotal);

                    foreach (var item in aNota.ItensDaNota)
                    {
                        decimal custoUnitarioReal = item.ValorUnitario;
                        if (valorTotalItens > 0 && item.Qtd > 0)
                        {
                            custoUnitarioReal += (totalCustosAdicionais * (item.ValorTotal / valorTotalItens)) / item.Qtd;
                        }
                        item.CustoUnitarioReal = custoUnitarioReal;
                        item.Ativo = true;
                    }

                    foreach (var item in aNota.ItensDaNota)
                    {
                        item.Id = 0;
                        _daoNotaEntrada.InserirItem(item, aNota.Id, cnn, transaction);
                        _daoProduto.AtualizarEstoqueCusto(item, cnn, transaction);
                        _daoProdForn.SalvarCustoFornecedor(item, aNota.OFornecedor.Id, aNota.DataEmissao, cnn, transaction);
                    }

                    if (aNota.ACondicaoPagamento != null && aNota.ACondicaoPagamento.ParcelasCondPag.Count > 0)
                    {
                        daoContasPagar.GerarParcelas(aNota, cnn, transaction);
                    }

                    transaction.Commit();
                    return aNota.Id.ToString();
                }
                catch (Exception ex)
                {
                    // REVERTE TUDO
                    transaction.Rollback();
                    return "Erro ao salvar a nota: " + ex.Message;
                }
            }
        }

        public List<NotaEntrada> Listar()
        {
            return _daoNotaEntrada.Listar();
        }
    }
}
   