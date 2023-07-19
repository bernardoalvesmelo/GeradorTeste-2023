using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class TesteTest
    {
        Disciplina matematica;
        Materia geometria;
        Questao questao1;
        Teste teste;

        public TesteTest()
        {
            matematica = new Disciplina("Matemática");
            geometria = new Materia("Geometria", SerieMateriaEnum.QuartaSerie, matematica);
            questao1 = new Questao("Quantos lados formam um triângulo?", geometria);
            teste = new Teste("Teste de Geometria", false, Convert.ToDateTime("01/01/2023"), 1);
        }

        [TestMethod]
        public void Questoes_devem_ser_diferentes_de_null()
        {
            Assert.IsNotNull(teste.Questoes);
        }

        [TestMethod]
        public void Deve_permitir_excluir_todas_as_questoes_no_teste()
        {
            List<Questao> questoes = new List<Questao> { questao1 };

            teste.Questoes = questoes;
            teste.RemoverQuestoes();

            Assert.AreEqual(0, teste.Questoes.Count);
        }
    }
}