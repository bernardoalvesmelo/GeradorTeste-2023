namespace GeradorTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Disciplina)
                .NotNull();

            RuleFor(x => x.Serie)
                .Must(x => x != SerieMateriaEnum.Nenhum);
        }

            
    }
}