using GeradorTeste.Infra.MassaDados;
using System;
using System.Windows.Forms;

namespace GeradorTeste.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GeradorMassaDados.ConfigurarTesteMatematica();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm());
        }
    }
}
