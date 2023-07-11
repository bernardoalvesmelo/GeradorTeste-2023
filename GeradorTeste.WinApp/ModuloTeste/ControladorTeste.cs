using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloTeste;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioTeste repositorioTeste;
        private IGeradorArquivo geradorArquivo;

        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste,
            IRepositorioDisciplina repositorioDisciplina,
            IGeradorArquivo geradorArquivo)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioTeste = repositorioTeste;
            this.geradorArquivo = geradorArquivo;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true, incluirQuestoes: true);

            TelaTesteForm tela = new TelaTesteForm(disciplinas);

            tela.ConfigurarTeste(new Teste());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Teste novoTeste = tela.ObterTeste();

                repositorioTeste.Inserir(novoTeste);

                CarregarTestes();
            }
        }

        public override void Duplicar()
        {
            int id = tabelaTeste.ObtemIdSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(id);

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um Teste primeiro",
                    "Duplicação de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true, incluirQuestoes: true);

            TelaTesteForm tela = new TelaTesteForm(disciplinas);

            testeSelecionado.RemoverQuestoes();

            tela.ConfigurarTeste(testeSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Teste novoTeste = tela.ObterTeste();

                repositorioTeste.Inserir(novoTeste);

                CarregarTestes();
            }
        }

        public override void Excluir()
        {
            int id = tabelaTeste.ObtemIdSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(id);

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um Teste primeiro",
                    "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Teste?",
               "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);

                CarregarTestes();
            }
        }

        public override void Visualizar()
        {
            int id = tabelaTeste.ObtemIdSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(id, incluirQuestoes:true);

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um Teste primeiro",
                "Visualização de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaVisualizacaoTesteForm tela = new TelaVisualizacaoTesteForm(testeSelecionado);
            tela.ShowDialog();
        }

        public override void GerarPdf()
        {
            int id = tabelaTeste.ObtemIdSelecionado();

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(id, incluirQuestoes: true, incluirAlternativas: true);

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um Teste primeiro",
                "Gerar Pdf de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaTestePdfForm tela = new TelaTestePdfForm(testeSelecionado);
            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                geradorArquivo.GravarTesteEmPdf(testeSelecionado, tela.Diretorio, tela.GerarGabarito);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTeste == null)
                tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape(string.Format("Visualizando {0} teste{1}", testes.Count, testes.Count == 1 ? "" : "s"));
        }
    }
}
