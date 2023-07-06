using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Infra.Sql.ModuloMateria;
using System.Collections.Generic;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloMateria
{
    public class RepositorioMateriaEmSql : RepositorioEmSqlBase<Materia, MapeadorMateriaSql>, IRepositorioMateria
    {
        protected override string sqlInserir => throw new System.NotImplementedException();

        protected override string sqlEditar => throw new System.NotImplementedException();

        protected override string sqlExcluir => throw new System.NotImplementedException();

        protected override string sqlSelecionarTodos => throw new System.NotImplementedException();

        protected override string sqlSelecionarPorId => throw new System.NotImplementedException();

        public Materia SelecionarMateriaPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public List<Materia> SelecionarTodos(bool incluirDisciplina = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
