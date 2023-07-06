using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloQuestao;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioQuestao repositorioQuestao;

        private TabelaQuestaoControl tabelaQuestoes;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            TelaQuestaoForm tela = new TelaQuestaoForm(disciplinas);

            //tela.Questao = new Questao();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }

        public override void Editar()
        {
            var numero = tabelaQuestoes.ObtemIdSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(numero);

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var disciplinas = repositorioDisciplina.SelecionarTodos();

            var tela = new TelaQuestaoForm(disciplinas);

            //tela.Questao = questaoSelecionada; 

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {
            var numero = tabelaQuestoes.ObtemIdSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(numero);

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a questão?",
               "Exclusão de Questões", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);
                CarregarQuestoes();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxQuestao();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaQuestoes == null)
                tabelaQuestoes = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestoes;
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestoes.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {questoes.Count} questão(ões)");
        }
    }
}
