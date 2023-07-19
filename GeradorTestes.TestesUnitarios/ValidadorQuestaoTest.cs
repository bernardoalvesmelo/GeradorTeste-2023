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
            resultado.ShouldHaveValidationErrorFor(x => x.Materia);
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
    }
}
