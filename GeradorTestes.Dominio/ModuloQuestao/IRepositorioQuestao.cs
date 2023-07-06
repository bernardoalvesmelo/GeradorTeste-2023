using System;

namespace GeradorTestes.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao : IRepositorio<Questao>
    {
        Questao SelecionarPorId(int id, bool incluirMateria=false, bool incluirAlternativas = false);
    }
}
