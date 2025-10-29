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
                    // --- PASSO 2: REVERTER ESTOQUE (Se for Atualização ou Cancelamento) ---
                    List<ItensNotaEntrada> itensAntigos = new List<ItensNotaEntrada>();
                    if (aNota.Id > 0)
                    {
                        itensAntigos = _daoNotaEntrada.ListarItensAtivos(aNota.Id, cnn, transaction);

                        foreach (var itemAntigo in itensAntigos)
                        {
                            // ESTA É A LÓGICA DE ROLLBACK DO PRODUTO QUE VOCÊ PEDIU
                            _daoProduto.ReverterEstoqueCusto(itemAntigo, cnn, transaction);
                        }
                    }

                    _daoNotaEntrada.SalvarCabecalho(aNota, cnn, transaction);

                    // --- PASSO 4: INATIVAR ITENS ANTIGOS (Soft Delete) ---
                    if (aNota.Id > 0)
                    {
                        _daoNotaEntrada.InativarItensAntigos(aNota.Id, cnn, transaction);
                    }

                    if (aNota.Id > 0)
                    {
                        daoContasPagar.InativarParcelas(aNota.Id, aNota.MotivoCancelamento, cnn, transaction);
                    }
                    // ======================================================================

                    // --- PASSO 5: SE NOTA FOI CANCELADA, PARA AQUI ---
                    if (!aNota.Ativo)
                    {
                        transaction.Commit(); // Comita a reversão do estoque e inativação
                        return aNota.Id.ToString();
                    }

                    // --- PASSO 6: LÓGICA DE NEGÓCIO (Rateio de Custo) ---
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

                    // --- PASSO 7: SALVAR NOVOS ITENS E ATUALIZAR ESTOQUE ---
                    foreach (var item in aNota.ItensDaNota)
                    {
                        item.Id = 0;
                        _daoNotaEntrada.InserirItem(item, aNota.Id, cnn, transaction);
                        _daoProduto.AtualizarEstoqueCusto(item, cnn, transaction);
                        _daoProdForn.SalvarCustoFornecedor(item, aNota.OFornecedor.Id, aNota.DataEmissao, cnn, transaction);
                    }

                    // ======================================================================
                    // --- PASSO 8: GERAR NOVAS CONTAS A PAGAR ---
                    if (aNota.ACondicaoPagamento != null && aNota.ACondicaoPagamento.ParcelasCondPag.Count > 0)
                    {
                        daoContasPagar.GerarParcelas(aNota, cnn, transaction);
                    }
                    // ======================================================================

                    // --- PASSO 9: SUCESSO! ---
                    transaction.Commit();
                    return aNota.Id.ToString();
                }
                catch (Exception ex)
                {
                    // --- FALHA: REVERTE TUDO ---
                    transaction.Rollback();
                    return "Erro ao salvar a nota: " + ex.Message;
                }
            }
        }

        // O Service também pode chamar o Listar do DAO
        public List<NotaEntrada> Listar()
        {
            return _daoNotaEntrada.Listar();
        }
    }
}
   