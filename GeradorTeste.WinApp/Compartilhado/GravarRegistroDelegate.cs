using GeradorTestes.Dominio;

namespace GeradorTeste.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
