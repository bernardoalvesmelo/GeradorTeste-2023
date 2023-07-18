using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Infra.MassaDados;
using GeradorTestes.Infra.Sql.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeradorTestes.ConsoleApp
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            var resultado = 12 + 09;

            Console.WriteLine( resultado.GetType() );

            var repositorioDisciplina = new RepositorioDisciplinaEmSql();

            var disciplinas = repositorioDisciplina
                .SelecionarTodos()
                .OrderBy(x => x.Nome)
                .Select(x => x.Nome);

            var x = new { id = 1, nome = "Alexandre Rech" }; //objetos anônimos

            Console.WriteLine( x.id + " - " + x.nome );

            foreach (var item in disciplinas)
            {
                Console.WriteLine( item );
            }

            foreach (var item in "ABCV")
            {

            }

            GeradorMassaDados.ConfigurarTesteMatematica();
        }

        private static void Teste()
        {
        }
    }
}