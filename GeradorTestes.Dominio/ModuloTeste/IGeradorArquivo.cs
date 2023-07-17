namespace GeradorTestes.Dominio.ModuloTeste
{
    public interface IGeradorArquivo
    {
        void GerarGabarito(Teste testeSelecionado, string diretorio);

        void GerarTeste(Teste testeSelecionado, string diretorio);
    }
}
