namespace GeradorTestes.Dominio
{
    public class Triangulo
    {
        public int LadoA { get; set; }
        public int LadoB { get; set; }
        public int LadoC { get; set; }

        public string ObterTipo()
        {
            if (TemLadosInvalidos())
                return "Tipo Inválido";

            else if (LadoA != LadoB && LadoB != LadoC)
                return "Escaleno";

            else if (LadoA == LadoB && LadoB == LadoC)
                return "Equilátero";

            else
                return "Isósceles";
        }

        private bool TemLadosInvalidos()
        {
            bool ladoA_Invalido = LadoA > LadoB + LadoC;
            bool ladoB_Invalido = LadoB > LadoA + LadoC;
            bool ladoC_Invalido = LadoC > LadoA + LadoB;

            if (ladoA_Invalido || ladoB_Invalido || ladoC_Invalido)
                return true;

            return false;
        }
    }
}
