using FluentResults;
using GeradorTestes.Dominio.ModuloDisciplina;
using Microsoft.Data.SqlClient;

namespace GeradorTeste.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina
    {
        private IRepositorioDisciplina repositorioDisciplina;

        public ServicoDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }
       
        public Result Inserir(Disciplina disciplina)
        {
            List<string> erros = ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioDisciplina.Inserir(disciplina);

            return Result.Ok();
        }

        public Result Editar(Disciplina disciplina)
        {
            List<string> erros = ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioDisciplina.Editar(disciplina);

            return Result.Ok();
        }

        public Result Excluir(Disciplina disciplinaSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBMateria_TBDisciplina"))
                    erros.Add("Esta disciplina está relacionada com uma matéria e não pode ser excluída");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarDisciplina(Disciplina disciplina)
        {
            List<string> erros = new List<string>(disciplina.Validar());

            if (NomeDuplicado(disciplina))
                erros.Add($"Este nome '{disciplina.Nome}' já está sendo utilizado na aplicação");

            return erros;
        }

        private bool NomeDuplicado(Disciplina disciplina)
        {
            Disciplina disciplinaEncontrada = repositorioDisciplina.SelecionarPorNome(disciplina.Nome);

            if (disciplinaEncontrada != null &&
                disciplinaEncontrada.Id != disciplina.Id &&
                disciplinaEncontrada.Nome == disciplina.Nome)
            {
                return true;
            }

            return false;
        }

       
    }
}
