using FluentValidation.TestHelper;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using System.Runtime.ConstrainedExecution;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class ValidadorTesteTest
    {
        private Teste teste;
        private ValidadorTeste validador;

        public ValidadorTesteTest()
        {
            teste = new Teste();

            validador = new ValidadorTeste();
        }

        [TestMethod]
        public void Titulo_teste_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Titulo);
        }


        [TestMethod]
        public void Disciplina_teste_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Disciplina);
        }

        [TestMethod]
        public void Data_teste_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.DataGeracao);
        }

        [TestMethod]
        public void Materia_teste_deve_ser_nulo_em_provao()
        {
            //arrange
            teste.Provao = true;
            teste.Materia = new Materia();
            teste.Materia.Questoes.Add(new Questao());

            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Materia);
        }

        [TestMethod]
        public void Materia_teste_deve_ter_questoes()
        {
            //arrange
            teste.Materia = new Materia();

            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Materia)
                .WithErrorMessage("Matéria deve ter no mínimo uma questão");
        }

        [TestMethod]
        public void QuantidadeQuestoes_teste_deve_ser_maior_que_zero()
        {
            //arrange
            teste.QuantidadeQuestoes = 0;

            //action
            var resultado = validador.TestValidate(teste);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.QuantidadeQuestoes);
        }
    }
}
