using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace GeradorTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public Materia()
        {
        }

        public Materia(string n, SerieMateriaEnum s, Disciplina disciplina) 
        {
            Nome = n;
            Serie = s;
            Disciplina = disciplina;
        }

        public Materia(int id, string nome, SerieMateriaEnum serie, Disciplina disciplina) : this(nome, serie, disciplina)
        {
            this.Id = id;
        }

        public string Nome { get; set; }

        public SerieMateriaEnum Serie { get; set; }

        public Disciplina Disciplina { get; set; }

        public List<Questao> Questoes { get; set; }

        public void AdicionaQuestao(Questao questao)
        {
            if (Questoes == null)
                Questoes = new List<Questao>();

            if (Questoes.Contains(questao))
                return;

            Questoes.Add(questao);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Nome, Serie.GetDescription());
        }

        public void ConfigurarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
                return;

            Disciplina = disciplina;

            Disciplina.AdicionarMateria(this);
        }

        public override void Atualizar(Materia materia)
        {
            Nome = materia.Nome;
            Disciplina = materia.Disciplina;
            Serie = materia.Serie;
        }

        public override bool Equals(object obj)
        {
            return obj is Materia materia &&
                   Id == materia.Id &&
                   Nome == materia.Nome &&
                   Serie == materia.Serie;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Serie, Disciplina, Questoes);
        }

        public string[] Validar()
        {
            return new List<string>().ToArray();
        }
    }
}