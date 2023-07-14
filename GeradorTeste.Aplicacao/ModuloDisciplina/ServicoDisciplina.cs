using FluentResults;
using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloDisciplina;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Serilog;

namespace GeradorTeste.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private ValidadorDisciplina validadorDisciplina;

        public ServicoDisciplina(
            IRepositorioDisciplina repositorioDisciplina,
            ValidadorDisciplina validadorDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.validadorDisciplina = validadorDisciplina;
        }

        public Result Inserir(Disciplina disciplina)
        {
            Log.Debug("Tentando inserir disciplina...{@d}", disciplina);

            List<string> erros = ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioDisciplina.Inserir(disciplina);

                Log.Debug("Disciplina {DisciplinaId} inserida com sucesso", disciplina.Id);
            }
            catch (SqlException exc)
            {
                string msgErro = "Falha ao tentar inserir disciplina.";

                Log.Error(exc, msgErro + "{d}", disciplina);

                return Result.Fail(msgErro);
            }

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
            List<string> erros = validadorDisciplina.Validate(disciplina)
                .Errors.Select(x => x.ErrorMessage).ToList();

            if (NomeDuplicado(disciplina))
                erros.Add($"Este nome '{disciplina.Nome}' já está sendo utilizado na aplicação");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

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
