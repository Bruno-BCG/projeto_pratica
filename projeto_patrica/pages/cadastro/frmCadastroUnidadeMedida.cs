using System;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroUnidadeMedida : projeto_pratica.pages.cadastro.frmCadastro
    {
        private UnidadeMedida oUnidadeMedida;
        private CtrlUniMedida aCtrlUniMedida;
        public frmCadastroUnidadeMedida()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oUnidadeMedida = (UnidadeMedida)obj;
            aCtrlUniMedida = (CtrlUniMedida)ctrl;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtUniMedida.Clear();
            this.txtDtCriacao.Clear();
            this.txtDtAlt.Clear();
        }

        public override void Salvar()
        {
            base.Salvar();

            if (string.IsNullOrWhiteSpace(txtUniMedida.Text))
            {
                MessageBox.Show("O nome da unidade de medida é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtCodigo.Text, out int unidadeMedidaId) && unidadeMedidaId > 0)
            {
                oUnidadeMedida.Id = unidadeMedidaId;
            }

            oUnidadeMedida.Nome = txtUniMedida.Text;

            if (btnSave.Text == "Salvar")
            {
                string resultado = aCtrlUniMedida.Salvar(oUnidadeMedida);

                if (int.TryParse(resultado, out int novoId))
                {
                    txtCodigo.Text = novoId.ToString();
                    MessageBox.Show($"A unidade de medida '{oUnidadeMedida.Nome}' foi salva com o código {txtCodigo.Text}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Excluir")
            {
                string resultado = aCtrlUniMedida.Excluir(oUnidadeMedida);

                if (resultado == "OK")
                {
                    MessageBox.Show("Unidade de Medida excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao excluir: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void CarregarTxt()
        {
            base.CarregarTxt();
            this.txtCodigo.Text = Convert.ToString(oUnidadeMedida.Id);
            this.txtUniMedida.Text = oUnidadeMedida.Nome;
            this.txtDtCriacao.Text = oUnidadeMedida.DtCriacao.ToString();
            this.txtDtAlt.Text = oUnidadeMedida.DtAlt.ToString();
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtUniMedida.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtUniMedida.Enabled = true;
        }
    }
}