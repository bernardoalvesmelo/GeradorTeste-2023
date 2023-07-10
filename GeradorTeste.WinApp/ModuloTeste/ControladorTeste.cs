using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloTeste;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioMateria repositorioMateria;

        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, 
            IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioTeste = repositorioTeste;
            this.repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true, incluirQuestoes: true);

            //List<Materia> materias = repositorioMateria.SelecionarTodos(incluirQuestoes: true);

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

            //List<Materia> materias = repositorioMateria.SelecionarTodos(incluirQuestoes: true);

            TelaTesteForm tela = new TelaTesteForm(disciplinas);

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

            Teste testeSelecionado = repositorioTeste.SelecionarPorId(id);

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um Teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaVisualizacaoTesteForm tela = new TelaVisualizacaoTesteForm(testeSelecionado);
            tela.ShowDialog();
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

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {testes.Count} teste(s)");
        }        
    }
}
