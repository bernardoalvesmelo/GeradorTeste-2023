using FluentValidation;

namespace GeradorTestes.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .Custom(ValidarCaracteresInvalidos);
        }

        private void ValidarCaracteresInvalidos(string nome, ValidationContext<Disciplina> contextoValidacao)
        {
            bool temCaracteresInvalidos = false;

            foreach (char letra in nome)
            {
                if (letra == ' ')
                    continue;

                if (char.IsLetterOrDigit(letra) == false)
                    temCaracteresInvalidos = true;
            }

            if (temCaracteresInvalidos)
                contextoValidacao.AddFailure($"'Nome' da disciplina deve ser composta por letras e números.");
        }       
    }
}
