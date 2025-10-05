using System;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroCategoria : projeto_pratica.pages.cadastro.frmCadastro
    {
        private Categoria oCategoria;
        private CtrlCategoria aCtrlCategoria;
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCategoria = (Categoria)obj;
            aCtrlCategoria = (CtrlCategoria)ctrl;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtCategoria.Clear();
            this.txtDtCriacao.Clear();
            this.txtDtAlt.Clear();
        }

        public override void Salvar()
        {
            base.Salvar();

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("O nome da categoria é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtCodigo.Text, out int categoriaId) && categoriaId > 0)
            {
                oCategoria.Id = categoriaId;
            }

            oCategoria.Nome = txtCategoria.Text;

            if (btnSave.Text == "Salvar")
            {
                string resultado = aCtrlCategoria.Salvar(oCategoria);

                if (int.TryParse(resultado, out int novoId))
                {
                    txtCodigo.Text = novoId.ToString();
                    MessageBox.Show($"A categoria '{oCategoria.Nome}' foi salva com o código {txtCodigo.Text}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Excluir")
            {
                string resultado = aCtrlCategoria.Excluir(oCategoria);

                if (resultado == "OK")
                {
                    MessageBox.Show("Categoria excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.txtCodigo.Text = Convert.ToString(oCategoria.Id);
            this.txtCategoria.Text = oCategoria.Nome;
            this.txtDtCriacao.Text = oCategoria.DtCriacao.ToString();
            this.txtDtAlt.Text = oCategoria.DtAlt.ToString();
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtCategoria.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtCategoria.Enabled = true;
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}