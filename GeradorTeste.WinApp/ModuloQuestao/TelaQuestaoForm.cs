using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private Questao questao;

        public TelaQuestaoForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarDisciplinas(disciplinas);
        }

        public Questao ObterQuestao()
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Materia = (Materia)cmbMaterias.SelectedItem;
            
            return questao;
        }

        public void ConfigurarQuestao(Questao questao)
        {
            this.questao = questao;

            txtEnunciado.Text = questao.Enunciado;
            cmbDisciplinas.SelectedItem = questao.Materia?.Disciplina;
            cmbMaterias.SelectedItem = questao.Materia;            
        }      

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.questao = ObterQuestao();

            string[] erros = questao.Validar();

            if (erros.Count() > 0)
            {
                string erro = erros[0];

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = new Alternativa();

            alternativa.Letra = questao.GerarLetraAlternativa();
            alternativa.Resposta = txtResposta.Text;

            questao.AdicionarAlternativa(alternativa);

            RecarregarAlternativas();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var alternativa = listAlternativas.SelectedItem as Alternativa;

            if (alternativa != null)
            {
                questao.RemoverAlternativa(alternativa);

                listAlternativas.Items.Remove(alternativa);

                RecarregarAlternativas();
            }
        }

        private void RecarregarAlternativas()
        {
            listAlternativas.Items.Clear();

            int i = 0;
            foreach (var item in questao.Alternativas)
            {
                listAlternativas.Items.Add(item);

                if (item.Correta)
                    listAlternativas.SetItemChecked(i, true);

                i++;
            }
        }

        private void cmbDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var disciplina = cmbDisciplinas.SelectedItem as Disciplina;

            if (disciplina != null)
                CarregarMaterias(disciplina.Materias);
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            cmbMaterias.Items.Clear();

            foreach (var item in materias)
            {
                cmbMaterias.Items.Add(item);
            }
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
        }

    }
}