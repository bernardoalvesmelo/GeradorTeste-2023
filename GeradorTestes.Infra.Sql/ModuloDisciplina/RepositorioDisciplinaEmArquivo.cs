using GeradorTestes.Dominio.ModuloDisciplina;
using System.Collections.Generic;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloDisciplina
{
    public class RepositorioDisciplinaEmSql :
        RepositorioEmSqlBase<Disciplina, MapeadorDisciplina>, IRepositorioDisciplina
    {
        protected override string sqlInserir => throw new System.NotImplementedException();

        protected override string sqlEditar => throw new System.NotImplementedException();

        protected override string sqlExcluir => throw new System.NotImplementedException();

        protected override string sqlSelecionarTodos => throw new System.NotImplementedException();

        protected override string sqlSelecionarPorId => throw new System.NotImplementedException();

        public Disciplina SelecionarDisciplinaPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public List<Disciplina> SelecionarTodos(bool incluirMateriasEhQuestoes)
        {
            throw new System.NotImplementedException();
        }
    }
}
