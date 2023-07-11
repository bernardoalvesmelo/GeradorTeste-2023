using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeradorTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public Disciplina()
        {
            Materias = new List<Materia>();
        }

        public Disciplina(string nome) : this()
        {
            Nome = nome;
        }

        public Disciplina(int id, string nome) : this(nome)        
        {
            Id = id;
        }

        public string Nome { get; set; }

        public List<Materia> Materias { get; set; }


        public List<Questao> ObterTodasQuestoes()
        {
            var todasQuestoes = new List<Questao>();

            if (Materias.Any())
            {
                foreach (var m in Materias)
                {
                    if (m.Questoes != null)
                        todasQuestoes.AddRange(m.Questoes);
                }
            }

            return todasQuestoes;
        }       

        public bool AdicionarMateria(Materia materia)
        {
            if (Materias.Contains(materia))
                return false;

            Materias.Add(materia);

            return true;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(Disciplina disciplina)
        {
            Nome = disciplina.Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is Disciplina disciplina &&
                   Id == disciplina.Id &&
                   Nome == disciplina.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Materias, Nome);
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add($"O 'nome' da disciplina deve estar preenchido");

            if (Nome.Length <= 2)
                erros.Add($"O 'nome' da disciplina deve ter mais de 3 letras");

            bool temCaracteresInvalidos = false;
            
            foreach (char letra in Nome)
            {
                if (letra == ' ')
                    continue;

                if (char.IsLetterOrDigit(letra) == false)
                    temCaracteresInvalidos = true;
            }

            if (temCaracteresInvalidos)
                erros.Add($"O 'nome' da disciplina deve ser composta por letras e números");

            return erros.ToArray();
        }
    }
}