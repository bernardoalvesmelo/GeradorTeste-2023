using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace GeradorTestes.Infra.Sql.ModuloMateria
{
    public class RepositorioMateriaEmSql : 
        RepositorioEmSqlBase<Materia, MapeadorMateriaSql>, IRepositorioMateria
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBMATERIA]
                   (
                        [NOME],
                        [SERIE],
                        [DISCIPLINA_ID]
                   )
                VALUES
                   (
                        @NOME,
                        @SERIE,
                        @DISCIPLINA_ID
                   ); 

                SELECT SCOPE_IDENTITY()";

        protected override string sqlEditar =>
            @"UPDATE [TBMATERIA]

		        SET
                    [NOME] = @NOME,
			        [DISCIPLINA_ID] = @DISCIPLINA_ID,
                    [SERIE] = @SERIE

		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBMATERIA]

		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            MT.ID       MATERIA_ID
	           ,MT.NOME     MATERIA_NOME
	           ,MT.SERIE    MATERIA_SERIE

	           ,D.ID        DISCIPLINA_ID
	           ,D.NOME      DISCIPLINA_NOME

            FROM
	            TBMATERIA AS MT 
                
                INNER JOIN TBDISCIPLINA AS D                     
                    ON MT.DISCIPLINA_ID = D.ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            MT.ID       MATERIA_ID
	           ,MT.NOME     MATERIA_NOME
	           ,MT.SERIE    MATERIA_SERIE

	           ,D.ID        DISCIPLINA_ID
	           ,D.NOME      DISCIPLINA_NOME

            FROM
	            TBMATERIA AS MT 
                
                INNER JOIN TBDISCIPLINA AS D                     
                    ON MT.DISCIPLINA_ID = D.ID

            WHERE
                MT.ID = @ID";

        private string sqlSelecionarQuestoesDaMateria =>
           @"SELECT 

		            [ID]            QUESTAO_ID
		           ,[ENUNCIADO]     QUESTAO_ENUNCIADO

	            FROM 
		            [TBQUESTAO]

		        WHERE
                    [MATERIA_ID] = @MATERIA_ID";

        //public List<Materia> SelecionarTodos(bool incluirQuestoes = false)
        //{
        //    List<Materia> materias = base.SelecionarTodos();

        //    if (incluirQuestoes)
        //    {
        //        foreach (Materia materia in materias)
        //        {
        //            CarregarQuestoes(materia);
        //        }
        //    }

        //    return materias;
        //}

        //private void CarregarQuestoes(Materia materia)
        //{
        //    MapeadorQuestaoSql mapeador = new MapeadorQuestaoSql();

        //    SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("MATERIA_ID", materia.Id) };

        //    List<Questao> questoes = SelecionarRegistros(sqlSelecionarQuestoesDaMateria, mapeador.ConverterRegistro, parametros);

        //    foreach (Questao questao in questoes)
        //    {
        //        materia.AdicionaQuestao(questao);
        //    }
        //}
    }
}
