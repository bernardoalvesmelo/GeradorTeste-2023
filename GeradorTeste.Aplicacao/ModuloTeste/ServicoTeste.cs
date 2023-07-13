using FluentResults;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using Microsoft.Data.SqlClient;

namespace GeradorTeste.Aplicacao.ModuloTeste
{
    public class ServicoTeste
    {
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioTeste repositorioTeste;

        public ServicoTeste(IRepositorioTeste repositorioTeste, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioQuestao = repositorioQuestao;
        }

        public Result Inserir(Teste teste)
        {
            List<string> erros = ValidarTeste(teste);

            if (erros.Count() > 0)
                return Result.Fail(erros);           

            repositorioTeste.Inserir(teste);

            foreach (Questao questao in teste.Questoes)
            {
                questao.JaUtilizada = true;
                repositorioQuestao.Editar(questao);
            }

            return Result.Ok();
        }

        public Result Excluir(Teste teste)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioTeste.Excluir(teste);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                //if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                    //erros.Add("Esta disciplina está relacionada com uma matéria e não pode ser excluída");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTeste(Teste teste)
        {
            List<string> erros = new List<string>(teste.Validar());
            
            return erros;
        }

    }
}