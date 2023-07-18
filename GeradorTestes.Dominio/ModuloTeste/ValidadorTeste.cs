using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;

namespace GeradorTestes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Titulo)
                .NotNull().NotEmpty();

            RuleFor(x => x.Disciplina)
                .NotNull().NotEmpty();

            RuleFor(x => x.DataGeracao)
                .NotNull().NotEmpty();

            RuleFor(x => x.Titulo)
                .NotNull().NotEmpty();

            When(x => x.Provao == true, () =>
            {
                RuleFor(x => x.Materia).Null();

            }).Otherwise(() =>
            {
                RuleFor(x => x.Materia)
                    .NotNull()
                    .Custom(MateriaDeveTerQuestoes);
            });

            RuleFor(x => x.QuantidadeQuestoes)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.QuestoesSorteadas).Must(qs => qs == true)
                .WithMessage("Deve ser sorteado questões para o teste")
                .DependentRules(() => {
                    RuleFor(x => x.Questoes)
                        .Custom(NoMininoTresQuestoes);
                });
        }

        private void NoMininoTresQuestoes(List<Questao> questoes, ValidationContext<Teste> ctx)
        {
            if (questoes.Count <= 1)
                ctx.AddFailure("Deve ser sorteado questões para o teste");
        }

        private void MateriaDeveTerQuestoes(Materia materia, ValidationContext<Teste> ctx)
        {
            if (materia != null && materia.Questoes.Count < 1)
                ctx.AddFailure(new ValidationFailure("Materia", "Matéria deve ter no mínimo uma questão"));
        }

    }
}