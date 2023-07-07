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

        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true);

            TelaQuestaoForm tela = new TelaQuestaoForm(disciplinas);

            tela.ConfigurarQuestao(new Questao());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Questao novaQuestao = tela.ObterQuestao();

                repositorioQuestao.Inserir(novaQuestao);

                CarregarQuestoes();
            }
        }

        public override void Editar()
        {
            int id = tabelaQuestao.ObtemIdSelecionado();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorId(id, incluirAlternativas: true);

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true);

            TelaQuestaoForm tela = new TelaQuestaoForm(disciplinas);

            tela.ConfigurarQuestao(questaoSelecionada); 

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Questao questao = tela.ObterQuestao();

                repositorioQuestao.Editar(questao);

                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {
            var numero = tabelaQuestao.ObtemIdSelecionado();

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
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape(string.Format("Visualizando quest{0}", questoes.Count > 1 ? "ão" : "ões"));
        }
    }
}
