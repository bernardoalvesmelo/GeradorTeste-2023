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

        [TestMethod]
        public void Tipo_triangulo_deve_ser_isosceles()
        {
            Triangulo triangulo = new Triangulo();

            triangulo.LadoA = 15;
            triangulo.LadoB = 10;
            triangulo.LadoC = 10;

            Assert.AreEqual("Isósceles", triangulo.ObterTipo());
        }

        [TestMethod]
        public void Tipo_trinagulo_invalido()
        {
            Triangulo triangulo = new Triangulo();

            triangulo.LadoA = 21;
            triangulo.LadoB = 10;
            triangulo.LadoC = 10;

            string tipo = triangulo.ObterTipo();

            Assert.AreEqual("Tipo Inválido", tipo);
        }

     
    }
}
