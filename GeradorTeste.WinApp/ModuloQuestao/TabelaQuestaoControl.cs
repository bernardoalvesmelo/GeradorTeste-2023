using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorTeste.WinApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=35F },

                new DataGridViewTextBoxColumn { Name = "Materia.Nome", HeaderText = "Matéria", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "Disciplina.Nome", HeaderText = "Disciplina", FillWeight=25F }

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (var questao in questoes)
            {
                grid.Rows.Add(questao.Id, questao.Enunciado, questao?.Materia?.Nome, questao.Materia?.Disciplina?.Nome);
            }
        }

        public int ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
