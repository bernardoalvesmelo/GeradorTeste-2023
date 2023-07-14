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

        public Result Inserir(Materia materia)
        {
            List<string> erros = ValidarMateria(materia);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioMateria.Inserir(materia);

            return Result.Ok();
        }

        public Result Editar(Materia materia)
        {
            List<string> erros = ValidarMateria(materia);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioMateria.Editar(materia);

            return Result.Ok();
        }

        public Result Excluir(Materia materiaSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioMateria.Excluir(materiaSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBQuestao_TBMateria"))
                    erros.Add("Esta materia está relacionada com uma questão e não pode ser excluída");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarMateria(Materia materia)
        {
            List<string> erros = new List<string>(materia.Validar());

            if (NomeDuplicado(materia))
                erros.Add($"Este nome '{materia.Nome}' já está sendo utilizado na aplicação");

            return erros;
        }

        private bool NomeDuplicado(Materia materia)
        {
            Materia materiaEncontrada = repositorioMateria.SelecionarPorNome(materia.Nome);

            if (materiaEncontrada != null &&
                materiaEncontrada.Id != materia.Id &&
                materiaEncontrada.Nome == materia.Nome)
            {
                return true;
            }

            return false;
        }
    }
}