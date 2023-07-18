using GeradorTestes.Dominio;

namespace GeradorTestes.TestesUnitarios
{
    [TestClass]
    public class TrianguloTest
    {
        [TestMethod]
        public void Tipo_triangulo_deve_ser_escaleno()
        {
            Triangulo triangulo = new Triangulo();

            triangulo.LadoA = 10;
            triangulo.LadoB = 11;
            triangulo.LadoC = 12;

            string tipo = triangulo.ObterTipo();

            Assert.AreEqual("Escaleno", tipo);
        }

        [TestMethod]
        public void Tipo_triangulo_deve_ser_equilatero()
        {
            Triangulo triangulo = new Triangulo();

            triangulo.LadoA = 10;
            triangulo.LadoB = 10;
            triangulo.LadoC = 10;

            string tipo = triangulo.ObterTipo();

            Assert.AreEqual("Equilátero", tipo);            
        }
    }
}
