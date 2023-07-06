using GeradorTestes.Dominio.ModuloMateria;
using System;

namespace GeradorTestes.Infra.Sql.ModuloMateria
{
    public class MapeadorMateriaSql : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            throw new NotImplementedException();
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
