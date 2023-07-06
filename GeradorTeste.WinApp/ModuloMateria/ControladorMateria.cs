using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;

        private TabelaMateriasControl tabelaMaterias;

        public ControladorMateria(
            IRepositorioMateria repositorioMateria,
            IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            TelaMateriaForm tela = new TelaMateriaForm(disciplinas);

            tela.ConfigurarMateria(new Materia());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Materia novaMateria = tela.ObterMateria();

                this.repositorioMateria.Inserir(novaMateria);

                CarregarMaterias();
            }
        }

        public override void Editar()
        {
            int id = tabelaMaterias.ObtemIdSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(id);

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Edição de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Disciplina> materias = repositorioDisciplina.SelecionarTodos();

            TelaMateriaForm tela = new TelaMateriaForm(materias);

            tela.ConfigurarMateria(materiaSelecionada); 

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Materia materia = tela.ObterMateria();

                this.repositorioMateria.Editar(materia);

                CarregarMaterias();
            }
        }

        public override void Excluir()
        {
            int id = tabelaMaterias.ObtemIdSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorId(id);

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a matéria?",
               "Exclusão de Materias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMaterias();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriasControl();

            CarregarMaterias();

            return tabelaMaterias;
        }

        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {materias.Count} materias(s)");
        }
    }
}
