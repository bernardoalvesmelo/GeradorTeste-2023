using System.Collections.Generic;

namespace GeradorTestes.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        List<Disciplina> SelecionarPorNome(string nome);
        List<Disciplina> SelecionarTodos(bool incluirMaterias = false, bool incluirQuestoes = false);
    }
}
