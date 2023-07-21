using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloDisciplina;
using GeradorTestes.Infra.Sql.ModuloMateria;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorTestes.TestesIntegracao
{
    [TestClass]
    public class RepositorioDisciplinaEmSqlTest
    {        
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestao repositorioQuestao;
        public RepositorioDisciplinaEmSqlTest()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            repositorioDisciplina = new RepositorioDisciplinaEmSql(connectionString);
            repositorioMateria = new RepositorioMateriaEmSql(connectionString);
            repositorioQuestao = new RepositorioQuestaoEmSql(connectionString);

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBQUESTAO]
                DBCC CHECKIDENT ('[TBQUESTAO]', RESEED, 0);

                DELETE FROM [DBO].[TBMATERIA]
                DBCC CHECKIDENT ('[TBMATERIA]', RESEED, 0);

                DELETE FROM [DBO].[TBDISCIPLINA]
                DBCC CHECKIDENT ('[TBDISCIPLINA]', RESEED, 0);";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

        [TestMethod]
        public void Deve_inserir_disciplina()
        {
            //arrange
            Disciplina disciplina = new Disciplina("Matemática");
           
            //action
            repositorioDisciplina.Inserir(disciplina);

            //assert

            Disciplina disciplinaEncontrada = repositorioDisciplina.SelecionarPorId(disciplina.Id);
            Assert.AreEqual(disciplina, disciplinaEncontrada);
        }

        [TestMethod]
        public void Deve_editar_disciplina()
        {
            //arrange
            Disciplina disciplina = new Disciplina("Matemática");

            repositorioDisciplina.Inserir(disciplina);

            Disciplina disciplinaAtualizada = repositorioDisciplina.SelecionarPorId(disciplina.Id);

            disciplinaAtualizada.Nome = "História";

            //action
            repositorioDisciplina.Editar(disciplinaAtualizada);

            //assert

            Disciplina disciplinaEncontrada = repositorioDisciplina.SelecionarPorId(disciplinaAtualizada.Id);

            Assert.AreEqual(disciplinaAtualizada, disciplinaEncontrada);
        }

        [TestMethod]
        public void Deve_excluir_disciplina()
        {
            //arrange
            Disciplina disciplina = new Disciplina("Matemática");

            repositorioDisciplina.Inserir(disciplina);

            //action
            repositorioDisciplina.Excluir(disciplina);

            //assert

            Disciplina disciplinaEncontrada = repositorioDisciplina.SelecionarPorId(disciplina.Id);

            Assert.IsNull(disciplinaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_disciplinas()
        {
            //arrange
            var matematica = new Disciplina("Matemática");
            var portugues = new Disciplina("Português");

            repositorioDisciplina.Inserir(matematica);
            repositorioDisciplina.Inserir(portugues);

            //action
            var disciplinas = repositorioDisciplina.SelecionarTodos();

            //assert
            Assert.AreEqual(matematica, disciplinas[0]);
            Assert.AreEqual(portugues, disciplinas[1]);

            Assert.AreEqual(2, disciplinas.Count);
        }

        [TestMethod]
        public void Deve_selecionar_disciplinas_com_materias()
        {
            //arrange
            var matematica = new Disciplina("Matemática");           

            repositorioDisciplina.Inserir(matematica);

            var adiciaoUnidades = new Materia("Adição de Unidades", SerieMateriaEnum.PrimeiraSerie, matematica);
            var adiciaoDezenas = new Materia("Adição de Dezenas", SerieMateriaEnum.PrimeiraSerie, matematica);

            repositorioMateria.Inserir(adiciaoUnidades);
            repositorioMateria.Inserir(adiciaoDezenas);

            //action
            var disciplinas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true);

            //assert
            Assert.AreEqual(adiciaoUnidades, disciplinas[0].Materias[0]);
            Assert.AreEqual(adiciaoDezenas, disciplinas[0].Materias[1]);

            Assert.AreEqual(2, disciplinas[0].Materias.Count);
        }

        [TestMethod]
        public void Deve_selecionar_disciplinas_com_materias_e_questoes()
        {
            //arrange
            var matematica = new Disciplina("Matemática");

            repositorioDisciplina.Inserir(matematica);

            var adiciaoUnidades = new Materia("Adição de Unidades", SerieMateriaEnum.PrimeiraSerie, matematica);

            var questao1 = new Questao("Quanto é 2 + 2 ?", adiciaoUnidades);
            var questao2 = new Questao("Quanto é 3 + 3 ?", adiciaoUnidades);

            repositorioMateria.Inserir(adiciaoUnidades);

            repositorioQuestao.Inserir(questao1);
            repositorioQuestao.Inserir(questao2);

            //action
            var disciplinasEncontradas = repositorioDisciplina.SelecionarTodos(incluirMaterias: true, incluirQuestoes: true);

            //assert            
            Assert.AreEqual(questao1, disciplinasEncontradas[0].Materias[0].Questoes[0]);
            Assert.AreEqual(questao2, disciplinasEncontradas[0].Materias[0].Questoes[1]);

            Assert.AreEqual(2, disciplinasEncontradas[0].Materias[0].Questoes.Count);
        }

        [TestMethod]
        public void Deve_selecionar_disciplina_por_nome()
        {
            //arrange
            var matematica = new Disciplina("Matemática");

            repositorioDisciplina.Inserir(matematica);

            //action
            var disciplinasEncontrada = repositorioDisciplina.SelecionarPorNome(matematica.Nome);

            //assert            
            Assert.AreEqual(matematica, disciplinasEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_disciplina_por_id()
        {
            //arrange
            var matematica = new Disciplina("Matemática");

            repositorioDisciplina.Inserir(matematica);

            //action
            var disciplinasEncontrada = repositorioDisciplina.SelecionarPorId(matematica.Id);

            //assert            
            Assert.AreEqual(matematica, disciplinasEncontrada);
        }


    }
}