using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

            Document doc = new Document();

            PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            doc.Open();

            doc.Add(new Paragraph($"Título: {testeSelecionado.Titulo}"));

            string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            doc.Add(new Paragraph($"Disciplina: {nomeDisciplina}"));

            doc.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}"));

            doc.Add(new Paragraph("\n\n"));

            Gabarito gabarito = testeSelecionado.ObterGabarito();

            for (int i = 0; i < gabarito.AlternativasCorretas.Count; i++)
            {
                Alternativa alternativaCorreta = gabarito.AlternativasCorretas[i];                
                
                doc.Add(new Paragraph($"Pergunta {i + 1}: \n"));
                
                doc.Add(new Paragraph($"{alternativaCorreta}"));
                
                if (i + 1 != gabarito.AlternativasCorretas.Count)
                    doc.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
            }

            doc.Close();
        }

        private static void GerarTeste(Teste testeSelecionado, string diretorio)
        {
            string caminhoArquivo = Path.Combine(diretorio, $"{testeSelecionado.Titulo}.pdf");

            Document doc = new Document();

            PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            doc.Open();

            doc.Add(new Paragraph($"Título: {testeSelecionado.Titulo}"));

            string nomeDisciplina = testeSelecionado.Disciplina == null ? testeSelecionado.Materia.Disciplina.Nome : testeSelecionado.Disciplina.Nome;

            doc.Add(new Paragraph($"Disciplina: {nomeDisciplina}"));

            doc.Add(new Paragraph($"Matéria: {testeSelecionado.Materia.Nome}"));

            doc.Add(new Paragraph("\n\n"));

            for (int i = 0; i < testeSelecionado.Questoes.Count; i++)
            {
                Questao questao = testeSelecionado.Questoes[i];

                doc.Add(new Paragraph($"Pergunta {i + 1}: {questao.Enunciado} \n"));

                foreach (Alternativa alternativa in questao.Alternativas)
                {
                    doc.Add(new Paragraph($"{alternativa}"));
                }

                if (i + 1 != testeSelecionado.Questoes.Count)
                    doc.Add(new Paragraph($"--------------------------------------------------------------------------------------"));
            }

            doc.Close();
        }
    }
}

