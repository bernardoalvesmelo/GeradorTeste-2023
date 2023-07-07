using GeradorTestes.Dominio.ModuloQuestao;
using System;

namespace GeradorTestes.Infra.Sql.ModuloQuestao
{
    public class MapeadorAlternativa 
    {
        public SqlParameter[] ObterParametros(Alternativa alternativa)
        {
            SqlParameter[] parametros = new SqlParameter[5];

            parametros[0] = new SqlParameter("ID", alternativa.Id);

            parametros[1] = new SqlParameter("LETRA", alternativa.Letra);

            parametros[2] = new SqlParameter("RESPOSTA", alternativa.Resposta);

            parametros[3] = new SqlParameter("CORRETA", alternativa.Correta);

            parametros[4] = new SqlParameter("QUESTAO_ID", alternativa.Questao.Id);

            return parametros;
        }

        public Alternativa ConverterRegistro(SqlDataReader leitorAlternativa)
        {
            if (leitorAlternativa["ALTERNATIVA_ID"] == DBNull.Value)
                return null;

            int id = Convert.ToInt32(leitorAlternativa["ALTERNATIVA_ID"]);

            char letra = Convert.ToChar(leitorAlternativa["ALTERNATIVA_LETRA"]);

            string resposta = Convert.ToString(leitorAlternativa["ALTERNATIVA_RESPOSTA"]);

            bool correta = Convert.ToBoolean(leitorAlternativa["ALTERNATIVA_CORRETA"]);

            Alternativa alternativa = new Alternativa(id, letra, resposta, correta);

            return alternativa;
        }
    }
}
