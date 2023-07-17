using GeradorTeste.Infra.MassaDados;
using System;
using System.IO;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using GeradorTestes.Dominio.ModuloTeste;

namespace GeradorTeste.ConsoleApp
{
    internal class Program
    {
        static void Main2(String[] args)
        {
            FileInfo file = new FileInfo(@"C:\temp\teste");
            if (!file.Directory.Exists)
                file.Directory.Create();

            CreatePdf(@"C:\temp\teste\teste.pdf");
        }

        static void CreatePdf(String dest)
        {
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(dest);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf);
            // Create a PdfFont
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            // Add a Paragraph
            document.Add(new Paragraph("iText is:").SetFont(font));
            // Create a List
            List list = new List().SetSymbolIndent(12).SetListSymbol("\u2022").SetFont(font);
            // Add ListItem objects
            list.Add(new ListItem("Never gonna give you up")).Add(new ListItem("Never gonna let you down")).Add(new ListItem
                ("Never gonna run around and desert you")).Add(new ListItem("Never gonna make you cry")).Add(new ListItem
                ("Never gonna say goodbye")).Add(new ListItem("Never gonna tell a lie and hurt you"));
            // Add the list
            document.Add(list);
            //Close document
            document.Close();
        }

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