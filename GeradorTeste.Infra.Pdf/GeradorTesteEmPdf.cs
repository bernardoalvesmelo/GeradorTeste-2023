using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace GeradorTeste.Infra.Pdf
{
    public class GeradorTesteEmPdf : IGeradorArquivo
    {
        public void GravarTesteEmPdf(Teste testeSelecionado, string diretorio, bool gerarGabarito)
        {
            GerarTeste(testeSelecionado, diretorio);

            if (gerarGabarito)
            {                
                GerarGabarito(testeSelecionado, diretorio);
            }
        }

        private void GerarGabarito(Teste testeSelecionado, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{testeSelecionado.Titulo}-gabarito.pdf");

            PdfWriter writer = new PdfWriter(caminhoArquivo);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.Add(new Paragraph($"Título: {testeSelecionado.Titulo}").SetFont(bold));

            string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            document.Add(new Paragraph($"Disciplina: {nomeDisciplina}").SetFont(bold));

            document.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}").SetFont(bold));

            document.Add(new Paragraph("\n\n"));

            Gabarito gabarito = testeSelecionado.ObterGabarito();

            for (int i = 0; i < gabarito.AlternativasCorretas.Count; i++)
            {
                Alternativa alternativaCorreta = gabarito.AlternativasCorretas[i];

                Questao questao = alternativaCorreta.Questao;

                document.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n").SetFont(font));

                document.Add(new Paragraph($"{alternativaCorreta}").SetFont(font));
                
                if (i + 1 != gabarito.AlternativasCorretas.Count)
                {
                    document.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }                    
            }

            document.Close();
        }

        private static void GerarTeste(Teste testeSelecionado, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{testeSelecionado.Titulo}.pdf");

            PdfWriter writer = new PdfWriter(caminhoArquivo);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.Add(new Paragraph($"Título: {testeSelecionado.Titulo}").SetFont(bold));

            string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            document.Add(new Paragraph($"Disciplina: {nomeDisciplina}").SetFont(bold));

            document.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}").SetFont(bold));

            document.Add(new Paragraph("\n\n"));

            //PdfCanvas canvas = new PdfCanvas(pdf.GetFirstPage());

            for (int i = 0; i < testeSelecionado.Questoes.Count; i++)
            {
                Questao questao = testeSelecionado.Questoes[i];

                document.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n"));

                foreach (Alternativa alternativa in questao.Alternativas)
                {
                    document.Add(new Paragraph($"{alternativa}").SetFont(font));
                }

                if (i + 1 != testeSelecionado.Questoes.Count)
                {
                    document.Add(new Paragraph($"--------------------------------------------------------------------------------------"));

                    // Initial point of the line       
                    // canvas.MoveTo(100, 300);

                    // Drawing the line       
                    // canvas.LineTo(500, 300);

                    // canvas.ClosePathStroke();
                }
            }

            document.Close();
        }
    }
}

