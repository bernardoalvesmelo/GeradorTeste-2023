using FluentResults;
using GeradorTestes.Dominio.ModuloMateria;
using Microsoft.Data.SqlClient;

namespace GeradorTeste.Aplicacao.ModuloMateria
{
    public class ServicoMateria
    {
        private IRepositorioMateria repositorioMateria;

        public ServicoMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public Result Inserir(Materia disciplina)
        {
            List<string> erros = ValidarMateria(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioMateria.Inserir(disciplina);

            return Result.Ok();
        }

        public Result Editar(Materia disciplina)
        {
            List<string> erros = ValidarMateria(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioMateria.Editar(disciplina);

            return Result.Ok();
        }

        public Result Excluir(Materia disciplinaSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioMateria.Excluir(disciplinaSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBMateria_TBMateria"))
                    erros.Add("Esta disciplina está relacionada com uma matéria e não pode ser excluída");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarMateria(Materia disciplina)
        {
            List<string> erros = new List<string>(disciplina.Validar());

            if (NomeDuplicado(disciplina))
                erros.Add($"Este nome '{disciplina.Nome}' já está sendo utilizado na aplicação");

            return erros;
        }

        private bool NomeDuplicado(Materia disciplina)
        {
            List<Materia> disciplinas = repositorioMateria.SelecionarPorNome(disciplina.Nome);

            if (disciplinas.Exists(x => x.Id != disciplina.Id && x.Nome == disciplina.Nome))
                return true;

            return false;
        }

    }
