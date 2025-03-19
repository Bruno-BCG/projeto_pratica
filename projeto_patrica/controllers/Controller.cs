using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class Controller
	{
		public virtual string Salvar(object obj)
		{
			return " ";
		}

		public virtual string Excluir(object obj)
		{
			return " ";
		}
		public virtual List<object> Pesquisar(string chave)
		{
			return null;
		}

		public virtual void CarregarObj(object obj)
		{

		}
	}
}
