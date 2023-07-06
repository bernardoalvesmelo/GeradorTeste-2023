using GeradorTestes.Dominio.ModuloDisciplina;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloDisciplina
{
    public class MapeadorDisciplina : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina registro)
        {
            throw new System.NotImplementedException();
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}
