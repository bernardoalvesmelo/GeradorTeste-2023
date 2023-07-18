using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace GeradorTestes.Infra.Pdf
{
    public class GeradorTesteEmPdf : IGeradorArquivo
    {                
        public void GerarGabarito(Teste testeSelecionado, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{testeSelecionado.Titulo}-gabarito.pdf");

            Document documento = CriarDocumentoPdf(caminhoArquivo);

            ConfigurarCabecalho(documento, testeSelecionado);

            Gabarito gabarito = testeSelecionado.ObterGabarito();

            EscreverConteudo(documento, gabarito);

            documento.Close();
        }

        public void GerarTeste(Teste testeSelecionado, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{testeSelecionado.Titulo}.pdf");

            Document document = CriarDocumentoPdf(caminhoArquivo);

            ConfigurarCabecalho(document, testeSelecionado);

            EscreverConteudo(document, testeSelecionado);

            document.Close();
        }

        #region métodos privados
        private Document CriarDocumentoPdf(string caminhoArquivo)
        {
            PdfWriter writer = new PdfWriter(caminhoArquivo);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf);

            return document;
        }

        private void ConfigurarCabecalho(Document document, Teste testeSelecionado)
        {
            PdfFont fontCabecalho = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.Add(new Paragraph($"Título: {testeSelecionado.Titulo}").SetFont(fontCabecalho));

            string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            document.Add(new Paragraph($"Disciplina: {nomeDisciplina}").SetFont(fontCabecalho));

            document.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}").SetFont(fontCabecalho));

            document.Add(new Paragraph("\n\n"));
        }

        private void EscreverConteudo(Document document, Gabarito gabarito)
        {
            PdfFont fontConteudo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            for (int i = 0; i < gabarito.AlternativasCorretas.Count; i++)
            {
                Alternativa alternativaCorreta = gabarito.AlternativasCorretas[i];

                Questao questao = alternativaCorreta.Questao;

                document.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n").SetFont(fontConteudo));

                document.Add(new Paragraph($"{alternativaCorreta}").SetFont(fontConteudo));

                if (i + 1 != gabarito.AlternativasCorretas.Count)
                {
                    document.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }
            }
        }

        private void EscreverConteudo(Document document, Teste testeSelecionado)
        {
            PdfFont fontConteudo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            for (int i = 0; i < testeSelecionado.Questoes.Count; i++)
            {
                Questao questao = testeSelecionado.Questoes[i];

                document.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n"));

                foreach (Alternativa alternativa in questao.Alternativas)
                {
                    document.Add(new Paragraph($"{alternativa}").SetFont(fontConteudo));
                }

                if (i + 1 != testeSelecionado.Questoes.Count)
                {
                    document.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
                }
            }
        }

        #endregion
    }
}

