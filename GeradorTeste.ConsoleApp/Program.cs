using GeradorTeste.Infra.MassaDados;
using GeradorTestes.Dominio.ModuloDisciplina;
using System.Collections.Generic;

namespace GeradorTeste.ConsoleApp
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            //Dictionary<int, Disciplina> dicionario = new Dictionary<int, Disciplina>();

            //dicionario.Add(1, new Disciplina("MAtemática"));

            //dicionario.Add(2, new Disciplina("Português"));

            //dicionario.Add(3, new Disciplina("História"));

            //Disciplina d = dicionario[2];

            //Disciplina outraDisciplina = null;

            //bool conseguiuEncontrar = dicionario.TryGetValue(4, out outraDisciplina);            

            //dicionario.Remove(2);

            GeradorMassaDados.ConfigurarTesteMatematica();
        }
    }
}