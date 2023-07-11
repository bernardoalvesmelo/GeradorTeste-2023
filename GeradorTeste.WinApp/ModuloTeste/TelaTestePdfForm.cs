using GeradorTestes.Dominio.ModuloTeste;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloTeste
{
    public partial class TelaTestePdfForm : Form
    {
        public TelaTestePdfForm(Teste teste)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarTela(teste);
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
    }
}
