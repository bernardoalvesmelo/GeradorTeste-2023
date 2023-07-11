namespace GeradorTestes.Dominio.ModuloTeste
{
    public interface IGeradorRelatorio
    {        
        void GerarRelatorioEmPdf(Teste teste, string diretorio, bool gerarGabarito);
    }
}
