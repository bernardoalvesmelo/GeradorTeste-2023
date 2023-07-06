using GeradorTestes.Dominio.ModuloTeste;
using System;

namespace GeradorTeste.Infra.Pdf
{
    public class GeradorRelatorioPdf : IGeradorRelatorio
    {
        public void GerarRelatorioEmPdf(Teste teste)
        {
            Console.WriteLine("Gerando o pdf...");
        }
    }
}
