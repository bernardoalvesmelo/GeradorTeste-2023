using GeradorTestes.Dominio.ModuloDisciplina;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;

        private TabelaDisciplinaControl tabelaDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            TelaDisciplinaForm tela = new TelaDisciplinaForm();

            tela.ConfigurarDisciplina(new Disciplina());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Disciplina novaDisciplina = tela.ObterDisciplina();
                
                repositorioDisciplina.Inserir(novaDisciplina);

                CarregarDisciplinas();
            }
        }

        public override void Editar()
        {
            int id = tabelaDisciplina.ObtemIdSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaDisciplinaForm tela = new TelaDisciplinaForm();

            tela.ConfigurarDisciplina(disciplinaSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Disciplina disciplina = tela.ObterDisciplina();

                repositorioDisciplina.Editar(disciplina);

                CarregarDisciplinas();
            }
        }

        public override void Excluir()
        {
            int id = tabelaDisciplina.ObtemIdSelecionado();

            Disciplina disciplinaSelecionada = repositorioDisciplina.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplinas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDisciplina();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {disciplinas.Count} disciplina(s)");
        }
    }
}
