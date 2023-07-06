using GeradorTestes.Dominio.ModuloQuestao;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloQuestao
{
    public class MapeadorQuestaoSql : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            throw new System.NotImplementedException();
        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}
