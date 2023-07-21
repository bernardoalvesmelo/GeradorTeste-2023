using FluentValidation.TestHelper;

using GeradorTestes.Dominio.ModuloQuestao;
using System.Runtime.ConstrainedExecution;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class ValidadorQuestaoTest
    {
        private Questao questao;
        private ValidadorQuestao validador;

        public ValidadorQuestaoTest()
        {
            questao = new Questao();

            validador = new ValidadorQuestao();
        }

        [TestMethod]
        public void Materia_questao_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveAnyValidationError()
                .WithErrorMessage("Disciplina e Matéria não podem estar em branco");
        }

        [TestMethod]
        public void Enunciado_questao_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Enunciado);
        }

        [TestMethod]
        public void Enunciado_questao_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            questao.Enunciado = "abcd";

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Enunciado);
        }

        [TestMethod]
        public void Alternativas_questao_deve_ter_no_minimo_3_alternativas()
        {
            //arrange

            Alternativa alternativaA = new Alternativa('A', "1", false);
            Alternativa alternativaB = new Alternativa('B', "2", false);

            List<Alternativa> alternativas = 
                new List<Alternativa>() { alternativaA, alternativaB };

            questao.Alternativas = alternativas;

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Alternativas)
                .WithErrorMessage("No mínimo 3 alternativas precisa ser informada"); 
        }

        [TestMethod]
        public void Alternativas_questao_deve_ter_no_maximo_5_alternativas()
        {
            //arrange
            Alternativa alternativaA = new Alternativa('A', "1", true);
            Alternativa alternativaB = new Alternativa('B', "2", false);
            Alternativa alternativaC = new Alternativa('C', "3", false);
            Alternativa alternativaD = new Alternativa('D', "4", false);
            Alternativa alternativaE = new Alternativa('E', "5", false);
            Alternativa alternativaF = new Alternativa('F', "6", false);

            List<Alternativa> alternativas =
                new List<Alternativa>() { 
                    alternativaA, 
                    alternativaB,
                    alternativaC,
                    alternativaD,
                    alternativaE,
                    alternativaF,
                };

            questao.Alternativas = alternativas;

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Alternativas)
                .WithErrorMessage("No máximo 5 alternativas pode ser informada"); 
        }

        public void Alternativas_questao_deve_ter_uma_alternativa_correta()
        {
            //arrange
            Alternativa alternativaA = new Alternativa('A', "1", false);
            Alternativa alternativaB = new Alternativa('B', "2", false);
            Alternativa alternativaC = new Alternativa('C', "3", false);

            List<Alternativa> alternativas =
                new List<Alternativa>() { alternativaA, alternativaB, alternativaC };

            questao.Alternativas = alternativas;

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Alternativas)
                .WithErrorMessage("Nenhuma alternativa correta foi informada");
        }

        public void Alternativas_questao_deve_ter_apenas_uma_alternativa_correta()
        {
            //arrange
            Alternativa alternativaA = new Alternativa('A', "1", true);
            Alternativa alternativaB = new Alternativa('B', "2", true);
            Alternativa alternativaC = new Alternativa('C', "3", false);

            List<Alternativa> alternativas =
                new List<Alternativa>() { alternativaA, alternativaB, alternativaC };

            questao.Alternativas = alternativas;

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Alternativas)
                .WithErrorMessage("Apenas uma alternativa pode ser correta");
        }

        public void Alternativas_questao_nao_deve_ter_valores_repetidos()
        {
            //arrange
            Alternativa alternativaA = new Alternativa('A', "1", true);
            Alternativa alternativaB = new Alternativa('B', "1", false);
            Alternativa alternativaC = new Alternativa('C', "3", false);

            List<Alternativa> alternativas =
                new List<Alternativa>() { alternativaA, alternativaB, alternativaC };

            questao.Alternativas = alternativas;

            //action
            var resultado = validador.TestValidate(questao);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Alternativas)
                .WithErrorMessage("Respostas iguais foram informadas nas alternativas");
        }

    }
}
