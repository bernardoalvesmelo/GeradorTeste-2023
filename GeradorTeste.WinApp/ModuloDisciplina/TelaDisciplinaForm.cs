using GeradorTestes.Dominio.ModuloDisciplina;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;

        public TelaDisciplinaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Disciplina ObterDisciplina()
        {               
            disciplina.Id = Convert.ToInt32(txtId.Text);
            disciplina.Nome = txtNome.Text;

            return disciplina;          
        }

        public void ConfigurarDisciplina(Disciplina disciplina)
        {
            this.disciplina = disciplina;

            txtId.Text = disciplina.Id.ToString();
            txtNome.Text = disciplina.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.disciplina = ObterDisciplina();

            string[] erros = this.disciplina.Validar();

            if (erros.Count() > 0)
            {
                string erro = erros[0];

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
