namespace GeradorTestes.Dominio.ModuloTeste
{
    public interface IGeradorRelatorio
    {
        /// <summary>
        /// o Cliente exige que deve ser gerador um relatorio do teste
        /// </summary>
        /// <param name="teste"></param>
        void GerarRelatorioEmPdf(Teste teste);
    }
}
