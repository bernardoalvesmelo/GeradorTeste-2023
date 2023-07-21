namespace GeradorTestes.Dominio
{
    public class Triangulo
    {
        public int LadoA { get; set; }
        public int LadoB { get; set; }
        public int LadoC { get; set; }

        public string ObterTipo()
        {
            if (LadoA != LadoB && LadoB != LadoC && LadoA != LadoC)
                return "Escaleno";

            if (LadoA == LadoB && LadoB == LadoC)
                return "Equilátero";

            return "";
        }
    }
}
