using GeradorTestes.Dominio;

namespace GeradorTestes.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
