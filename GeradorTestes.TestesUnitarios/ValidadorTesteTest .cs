using FluentValidation.TestHelper;

using GeradorTestes.Dominio.ModuloMateria;
using System.Runtime.ConstrainedExecution;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class ValidadorMateriaTest
    {
        private Materia materia;
        private ValidadorMateria validador;

        public ValidadorMateriaTest()
        {
            materia = new Materia();

            validador = new ValidadorMateria();
        }

        [TestMethod]
        public void Nome_materia_nao_deve_ser_nulo_ou_vazio()
        {            
            //action
            var resultado = validador.TestValidate(materia);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_materia_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            materia.Nome = "ab";

            //action
            var resultado = validador.TestValidate(materia);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_materia_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            materia.Nome = "-Erro-";

            //action
            var resultado = validador.TestValidate(materia);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
