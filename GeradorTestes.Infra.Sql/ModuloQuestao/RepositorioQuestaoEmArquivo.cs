using GeradorTestes.Dominio.ModuloQuestao;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoEmSql : RepositorioEmSqlBase<Questao, MapeadorQuestaoSql>, IRepositorioQuestao
    {
        protected override string sqlInserir => throw new System.NotImplementedException();

        protected override string sqlEditar => throw new System.NotImplementedException();

        protected override string sqlExcluir => throw new System.NotImplementedException();

        protected override string sqlSelecionarTodos => throw new System.NotImplementedException();

        protected override string sqlSelecionarPorId => throw new System.NotImplementedException();

        public Questao SelecionarPorId(int id, bool incluirMateria = false, bool incluirAlternativas = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
