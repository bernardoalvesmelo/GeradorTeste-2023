﻿namespace GeradorTestes.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public Alternativa()
        {
        }

        public Alternativa(char letra, string resposta, bool correta) : this()
        {
            Letra = letra;
            Resposta = resposta;
            Correta = correta;
        }

        public Alternativa(int id, char letra, string resposta, bool correta) : this(letra, resposta, correta)
        {
            Id = id;
        }

        public bool Correta { get; set; }

        public char Letra { get; set; }

        public Questao Questao { get; set; }

        public string Resposta { get; set; }

        public override void Atualizar(Alternativa registro)
        {
            Correta = registro.Correta;
            Letra = registro.Letra;
            Resposta = registro.Resposta;
        }

        public override bool Equals(object obj)
        {
            return obj is Alternativa alternativa &&
                   Correta == alternativa.Correta &&
                   Letra == alternativa.Letra &&
                   Resposta == alternativa.Resposta;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Correta, Letra, Questao, Resposta);
        }

        public override string ToString()
        {
            return string.Format($"({Letra}) -> {Resposta}");
        }


    }
}