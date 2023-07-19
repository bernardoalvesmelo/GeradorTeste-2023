using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class MateriaTest
    {
        Disciplina matematica;
        Materia geometria;
        Questao questao1;

        public MateriaTest()
        {
            matematica = new Disciplina("Matemática");
            geometria = new Materia("Geometria", SerieMateriaEnum.QuartaSerie, matematica);
            questao1 = new Questao("Quantos lados formam um triângulo?", geometria);
        }

        [TestMethod]
        public void Questoes_Devem_ser_diferentes_de_null()
        {
            Assert.IsNotNull(geometria.Questoes);
        }

        [TestMethod]
        public void Deve_permitir_adicionar_questoes_na_Materia()
        {
            geometria.AdicionaQuestao(questao1);

            Assert.AreEqual(1, geometria.Questoes.Count);
        }

        [TestMethod]
        public void Nao_deve_adicionar_questoes_iguais_na_Materia()
        {
            Questao questao2 = new Questao("Quantos lados formam um círculo?", geometria);

            geometria.AdicionaQuestao(questao1);
            geometria.AdicionaQuestao(questao2);
            geometria.AdicionaQuestao(questao2);

            Assert.AreEqual(2, geometria.Questoes.Count);
        }
    }
}