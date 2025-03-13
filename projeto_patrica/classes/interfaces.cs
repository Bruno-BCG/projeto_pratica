using projeto_pratica.classes;
using projeto_pratica.pages.cadastro;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
	internal class interfaces
	{
		frmConsultaCondPag aFrmConsCondPag;

		frmCadastroCondpag aFrmCadCondPag;

		public interfaces()
		{
			aFrmConsCondPag = new frmConsultaCondPag();

			aFrmCadCondPag = new frmCadastroCondpag(); 

			aFrmConsCondPag.setFrmCadastro(aFrmCadCondPag);
		}

		public void PecaCondPag (condicaoPagamento aCondPag)
		{
			aFrmConsCondPag.ConhecaObj(aCondPag); 
			aFrmConsCondPag.ShowDialog();

		}
	}
}
