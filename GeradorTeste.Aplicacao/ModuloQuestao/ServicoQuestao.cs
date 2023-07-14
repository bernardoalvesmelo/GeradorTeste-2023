using FluentResults;
using GeradorTestes.Dominio.ModuloQuestao;
using Microsoft.Data.SqlClient;

namespace GeradorTeste.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao
    {
        private IRepositorioQuestao repositorioQuestao;

        public ServicoQuestao(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public Result Inserir(Questao questao)
        {
            List<string> erros = ValidarQuestao(questao);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioQuestao.Inserir(questao);

            return Result.Ok();
        }

        public Result Editar(Questao questao)
        {
            List<string> erros = ValidarQuestao(questao);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioQuestao.Editar(questao);

            return Result.Ok();
        }

        public Result Excluir(Questao questaoSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioQuestao.Excluir(questaoSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBTesteTBQuestao_TBQuestao"))
                    erros.Add("Esta questao está relacionada com um teste e não pode ser excluída");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarQuestao(Questao questao)
        {
            List<string> erros = new List<string>(questao.Validar());
            
            return erros;
        }
    }
}