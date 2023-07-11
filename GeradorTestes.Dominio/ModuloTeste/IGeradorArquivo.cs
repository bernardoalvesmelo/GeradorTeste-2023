namespace GeradorTestes.Dominio.ModuloTeste
{
    public interface IGeradorArquivo
    {        
        void GravarTesteEmPdf(Teste teste, string diretorio, bool gerarGabarito);
    }
}
