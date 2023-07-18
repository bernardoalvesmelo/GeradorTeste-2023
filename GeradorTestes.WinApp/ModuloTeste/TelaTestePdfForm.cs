using GeradorTestes.Dominio.ModuloTeste;
using System.Windows.Forms;

namespace GeradorTestes.WinApp.ModuloTeste
{
    public partial class TelaTestePdfForm : Form
    {
        public TelaTestePdfForm(Teste teste)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarTela(teste);
        }

        public string Diretorio
        {
            get { return txtDiretorio.Text; }
        }

        public bool GerarGabarito
        {
            get { return chkGabarito.Checked; }
        }

        private void ConfigurarTela(Teste teste)
        {
            labelTitulo.Text = teste.Titulo;
            labelDisciplina.Text = teste.Provao ? teste.Disciplina.Nome : teste.Materia.Disciplina.Nome;
            if (teste.Provao)
                labelMateria.Text = "Todas as Matérias";
            else
                labelMateria.Text = teste.Materia.Nome;
        }

        private void btnLocalizar_Click(object sender, System.EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtDiretorio.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
