using GeradorTestes.Dominio.ModuloTeste;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class PeriodoEmTextoTest
    {
        //classes de equivalência
        /**
         * Caso o Teste tenha mais de 24 horas uma mensagem deve aparecer:
            -Teste realizado 1 dia atrás
         */
        [TestMethod] 
        public void Deve_retornar_teste_realizado_1_dia_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddDays(-1));           

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 1 dia atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_2_dias_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddDays(-2));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 2 dias atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_3_dias_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddDays(-3));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 3 dias atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_4_dias_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddDays(-4));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 4 dias atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_29_dias_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddDays(-29));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 29 dias atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_1_mes_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddMonths(-1));
           

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 1 mês atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_2_meses_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddMonths(-2));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 2 meses atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_3_meses_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddMonths(-3));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 3 meses atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_1_ano_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddYears(-1));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 1 ano atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_2_anos_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddYears(-2));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 2 anos atrás", resultado);
        }

        [TestMethod]
        public void Deve_retornar_teste_realizado_3_anos_atras()
        {
            //arrange
            PeriodoEmTexto periodo = new PeriodoEmTexto(DateTime.Now, DateTime.Now.AddYears(-3));

            //action
            string resultado = periodo.ObterPeriodo();

            //assert
            Assert.AreEqual("Teste realizado 3 anos atrás", resultado);
        }
    }
}
