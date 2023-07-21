namespace GeradorTestes.Dominio.ModuloTeste
{
    public class PeriodoEmTexto
    {
        private int qtdDias;
        private int qtdMeses;
        private int qtdAnos;

        public PeriodoEmTexto(DateTime dataAtual, DateTime dataPassada)
        {
            TimeSpan diferenca = (dataAtual - dataPassada);

            qtdDias = (int)Math.Round(diferenca.TotalDays);

            qtdMeses = qtdDias / 30;

            qtdAnos = qtdMeses / 12;
        }

        public string ObterPeriodo()
        {
            if (qtdAnos >= 1)
                return PeriodoEmAnos();

            if (qtdMeses >= 1)
                return PeriodoEmMeses();

            return PeriodoEmDias();
        }

        private string PeriodoEmDias()
            => $"Teste realizado {qtdDias} {(qtdDias > 1 ? "dias" : "dia")} atrás";       

        private string PeriodoEmMeses()
            => $"Teste realizado {qtdMeses} {(qtdMeses > 1 ? "meses" : "mês")} atrás"; 

        private string PeriodoEmAnos()
            => $"Teste realizado {qtdAnos} {(qtdAnos > 1 ? "anos" : "ano")} atrás";
    }
}