namespace GeradorTestes.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao : IRepositorio<Questao>
    {
        Questao SelecionarPorId(int id, bool incluirAlternativas = false);
    }
}
