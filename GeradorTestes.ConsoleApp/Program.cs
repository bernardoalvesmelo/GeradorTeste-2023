using GeradorTestes.Aplicacao.ModuloTeste;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using GeradorTestes.Infra.MassaDados;
using GeradorTestes.Infra.Pdf;
using GeradorTestes.Infra.Sql.ModuloDisciplina;
using GeradorTestes.Infra.Sql.ModuloMateria;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloTeste;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GeradorTestes.ConsoleApp
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var diretorioLogs = configuracao.GetSection("DiretorioLogs:Caminho").Value;

            IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmSql(connectionString);
            IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql(connectionString);
            IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmSql(connectionString);
            IRepositorioTeste repositorioTeste = new RepositorioTesteEmSql(connectionString);

            IGeradorArquivo geradorRelatorio = new GeradorTesteEmPdf();
            ValidadorTeste validadorTeste = new ValidadorTeste();
            ServicoTeste servicoTeste = new ServicoTeste(repositorioTeste, repositorioQuestao, validadorTeste, geradorRelatorio);

            GeradorMassaDados geradorMassa = new GeradorMassaDados(repositorioDisciplina, repositorioMateria, repositorioQuestao, servicoTeste);

            geradorMassa.ConfigurarTesteMatematica();
        }     
    }
}