using GeradorTestes.Dominio.ModuloTeste;
using System.Collections.Generic;

namespace GeradorTestes.Infra.Sql.ModuloTeste
{
    public class RepositorioTesteEmSql : RepositorioEmSqlBase<Teste, MapeadorTesteSql>, IRepositorioTeste
    {
        protected override string sqlInserir => throw new System.NotImplementedException();

        protected override string sqlEditar => throw new System.NotImplementedException();

        protected override string sqlExcluir => throw new System.NotImplementedException();

        protected override string sqlSelecionarTodos => throw new System.NotImplementedException();

        protected override string sqlSelecionarPorId => throw new System.NotImplementedException();

        public List<Teste> SelecionarTodos(bool incluirDisciplinaEhMateria)
        {
            throw new System.NotImplementedException();
        }
    }
}
