using GeradorTestes.Dominio.ModuloTeste;

namespace GeradorTestes.Infra.BancoDados.Sql.ModuloTeste
{
    public class MapeadorTesteSql : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            throw new System.NotImplementedException();
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}
