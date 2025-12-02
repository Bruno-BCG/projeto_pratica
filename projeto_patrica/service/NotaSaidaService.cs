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
    internal class NotaSaidaService
    {
        private readonly DaoNotaSaida _daoNotaSaida;
        private readonly DaoContasReceber _daoContasReceber;
        private readonly DaoProduto _daoProduto;

        public NotaSaidaService()
        {
            _daoNotaSaida = new DaoNotaSaida();             
            _daoContasReceber = new DaoContasReceber();  
            _daoProduto = new DaoProduto();             
        }

        public string Salvar(NotaSaida aNota)
        {
            using (SqlConnection cnn = Banco.Abrir())
            {
                if (cnn == null) return "Erro ao conectar ao banco de dados.";

                SqlTransaction transaction = cnn.BeginTransaction();

                try
                {
                   
                    if (aNota.Id > 0 && !aNota.Ativo)
                    {
                        if (_daoNotaSaida.ExistemParcelasPagasPorNota(aNota.Id, cnn, transaction))
                        {
                            transaction.Rollback();
                            return "Cancelamento bloqueado: existem parcelas de Contas a Receber já baixadas para esta nota.";
                        }
                    }

                    
                    List<ItensNotaSaida> itensAntigos = new List<ItensNotaSaida>();
                    if (aNota.Id > 0)
                    {
                        itensAntigos = _daoNotaSaida.ListarItensAtivos(aNota.Id, cnn, transaction);
                        foreach (var itemAntigo in itensAntigos)
                        {
                            _daoProduto.ReporEstoqueSaida(itemAntigo, cnn, transaction); 
                        }
                    }

                    _daoNotaSaida.SalvarCabecalho(aNota, cnn, transaction);

                   
                    if (aNota.Id > 0)
                    {
                        _daoNotaSaida.InativarItensAntigos(aNota.Id, cnn, transaction);
                        _daoContasReceber.InativarParcelas(aNota.Id, aNota.MotivoCancelamento, cnn, transaction);
                    }

                    if (!aNota.Ativo)
                    {
                        transaction.Commit();
                        return aNota.Id.ToString();
                    }

                    foreach (var item in aNota.ItensDaNota)
                    {
                        item.Id = 0;
                        item.Ativo = true;
                        _daoNotaSaida.InserirItem(item, aNota.Id, cnn, transaction);
                        _daoProduto.BaixarEstoqueSaida(item, cnn, transaction); 
                    }

                    if (aNota.ACondicaoPagamento != null && aNota.ACondicaoPagamento.ParcelasCondPag.Count > 0)
                    {
                        _daoContasReceber.GerarParcelas(aNota, cnn, transaction);
                    }

                    transaction.Commit();
                    return aNota.Id.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Erro ao salvar a nota de saída: " + ex.Message;
                }
            }
        }

        public List<NotaSaida> Listar()
        {
            return _daoNotaSaida.Listar();
        }
    }
}


