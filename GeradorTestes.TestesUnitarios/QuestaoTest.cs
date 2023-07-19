using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class QuestaoTest
    {
        Disciplina matematica;
        Materia geometria;
        Questao questao1;
        Alternativa alternativaA;

        public QuestaoTest()
        {
            matematica = new Disciplina("Matemática");
            geometria = new Materia("Geometria", SerieMateriaEnum.QuartaSerie, matematica);
            questao1 = new Questao("Quantos lados formam um triângulo?", geometria);
            alternativaA = new Alternativa('A', "3", false);
        }

        [TestMethod]
        public void Alternativas_Devem_ser_diferentes_de_null()
        {
            Assert.IsNotNull(questao1.Alternativas);
        }

        [TestMethod]
        public void Deve_permitir_adicionar_alternativas_na_Questao()
        {
            questao1.AdicionarAlternativa(alternativaA);

            Assert.AreEqual(1, questao1.Alternativas.Count);
        }

        [TestMethod]
        public void Nao_deve_adicionar_alternativas_iguais_na_Questao()
        {
            Alternativa alternativaB = new Alternativa('B',"2",false);

            questao1.AdicionarAlternativa(alternativaA);
            questao1.AdicionarAlternativa(alternativaB);
            questao1.AdicionarAlternativa(alternativaB);

            Assert.AreEqual(2, questao1.Alternativas.Count);
        }

        [TestMethod]
        public void Deve_atualizar_alternativa_correta()
        {
            questao1.AdicionarAlternativa(alternativaA);

            questao1.AtualizarAlternativaCorreta(alternativaA);

            Assert.AreEqual(true, alternativaA.Correta);
        }

        [TestMethod]
        public void Deve_permitir_remover_alternativa_na_Questao()
        {
            Alternativa alternativaC = new Alternativa('C', "0", false);
            Alternativa alternativaB = new Alternativa('B', "2", false);

            questao1.AdicionarAlternativa(alternativaA);
            questao1.AdicionarAlternativa(alternativaB);

            questao1.AdicionarAlternativa(alternativaC);

            questao1.RemoverAlternativa(alternativaC);

            Assert.AreEqual(2, questao1.Alternativas.Count);
        }

        [TestMethod]
        public void Deve_permitir_obter_alternativa_Correta()
        {
            questao1.AdicionarAlternativa(alternativaA);
            questao1.AtualizarAlternativaCorreta(alternativaA);

            questao1.AtualizarAlternativaCorreta(alternativaA);

            Assert.AreEqual(alternativaA, questao1.ObtemAlternativaCorreta());
        }

        [TestMethod]
        public void Deve_permitir_obter_proxima_letra_de_alternativa()
        {
            Alternativa alternativaB = new Alternativa('B', "2", false);

            questao1.AdicionarAlternativa(alternativaA);
            questao1.AdicionarAlternativa(alternativaB);

            Assert.AreEqual('C', questao1.GerarLetraAlternativa());
        }

        [TestMethod]
        public void Deve_permitir_adicionar_materia_na_questao()
        {
            questao1.ConfigurarMateria(geometria);

            Assert.AreEqual(geometria, questao1.Materia);
        }

    }
}