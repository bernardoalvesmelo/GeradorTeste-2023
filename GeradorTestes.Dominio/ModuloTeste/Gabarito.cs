using GeradorTestes.Dominio.ModuloQuestao;

namespace GeradorTestes.Dominio.ModuloTeste
{
    public class Gabarito
    {
        public List<Alternativa> AlternativasCorretas;

        public void AdicionaQuestaoCorreta(Alternativa alternativa)
        {
            AlternativasCorretas.Add(alternativa);
        }

    }
}
