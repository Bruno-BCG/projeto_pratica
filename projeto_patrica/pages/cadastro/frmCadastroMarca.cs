using System;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroMarca : projeto_pratica.pages.cadastro.frmCadastro
    {
        private Marca oMarca;
        private CtrlMarca aCtrlMarca;
        public frmCadastroMarca()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oMarca = (Marca)obj;
            aCtrlMarca = (CtrlMarca)ctrl;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtMarca.Clear();

            this.txtDtCriacao.Clear();
            this.txtDtAlt.Clear();
        }

        public override void Salvar()
        {
            base.Salvar();

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("O nome da marca é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtCodigo.Text, out int marcaId) && marcaId > 0)
            {
                oMarca.Id = marcaId;
            }

            oMarca.Nome = txtMarca.Text;

            if (btnSave.Text == "Salvar")
            {
                string resultado = aCtrlMarca.Salvar(oMarca);

                if (int.TryParse(resultado, out int novoId))
                {
                    txtCodigo.Text = novoId.ToString();
                    MessageBox.Show($"A marca '{oMarca.Nome}' foi salva com o código {txtCodigo.Text}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Excluir")
            {
                string resultado = aCtrlMarca.Excluir(oMarca);

                if (resultado == "OK")
                {
                    MessageBox.Show("Marca excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.txtCodigo.Text = Convert.ToString(oMarca.Id);
            this.txtMarca.Text = oMarca.Nome;
            this.txtDtCriacao.Text = oMarca.DtCriacao.ToString();
            this.txtDtAlt.Text = oMarca.DtAlt.ToString();
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtMarca.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtMarca.Enabled = true;
        }
    }
}