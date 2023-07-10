using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using GeradorTestes.Infra.Sql.ModuloDisciplina;
using GeradorTestes.Infra.Sql.ModuloMateria;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloTeste;
using System;
using System.Collections.Generic;

namespace GeradorTeste.Infra.MassaDados
{
    public class GeradorMassaDados
    {
        static IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmSql();
        static IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql();
        static IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmSql();
        static IRepositorioTeste repositorioTeste = new RepositorioTesteEmSql();

        public static void ConfigurarAplicacao()
        {
            ConfigurarTesteMatematica();

            ConfigurarTestePortugues();
        }

        private static void ConfigurarTestePortugues()
        {
            Disciplina portugues = new Disciplina("Português");            

            repositorioDisciplina.Inserir(portugues);

            Materia consoantes = new Materia("Consoantes", SerieMateriaEnum.PrimeiraSerie, portugues);

            repositorioMateria.Inserir(consoantes);

            Questao q1 = NovaQuestaoPortugues(consoantes, 'C', 'A');
            Questao q2 = NovaQuestaoPortugues(consoantes, 'E', 'C');
            Questao q3 = NovaQuestaoPortugues(consoantes, 'G', 'E');
            Questao q4 = NovaQuestaoPortugues(consoantes, 'I', 'G');

            repositorioQuestao.Inserir(q1);
            repositorioQuestao.Inserir(q2);
            repositorioQuestao.Inserir(q3);
            repositorioQuestao.Inserir(q4);

            Teste novoTeste = new Teste();

            novoTeste.Titulo = "Revisão sobre Letras do Alfabeto";
            novoTeste.ConfigurarDisciplina(portugues);
            novoTeste.ConfigurarMateria(consoantes);
            novoTeste.Provao = false;
            novoTeste.QuantidadeQuestoes = 5;
            novoTeste.SortearQuestoes();
            novoTeste.DataGeracao = DateTime.Now;

            repositorioTeste.Inserir(novoTeste);
        }

        private static Questao NovaQuestaoPortugues(Materia materia, char letra, char resposta)
        {
            Questao questao = new Questao($"Depois da letra {letra} qual é a próxima letra no alfabeto?", materia);

            Alternativa[] alternativas = new Alternativa[4];

            for (int i = 0; i < 4; i++)
            {
                alternativas[i] = new Alternativa()
                {
                    Resposta = ((char)(resposta + (i + 1))).ToString()
                };
            }

            foreach (var item in alternativas)
            {
                item.Letra = questao.GerarLetraAlternativa();
                questao.AdicionarAlternativa(item);
            }

            questao.AtualizarAlternativaCorreta(alternativas[2]);

            return questao;
        }

        private static void ConfigurarTesteMatematica()
        {
            Disciplina matematica = new Disciplina("Matemática");

            Materia adicaoUnidades = new Materia("Adição de Unidades", SerieMateriaEnum.PrimeiraSerie, matematica);

            Materia adicaoDezenas = new Materia("Adição de Dezenas", SerieMateriaEnum.PrimeiraSerie, matematica);

            Materia adicaoCentenas = new Materia("Adição de Centenas", SerieMateriaEnum.SegundaSerie, matematica);

            Materia adicaoMilhar = new Materia("Adição de Milhar", SerieMateriaEnum.SegundaSerie, matematica);

            Materia[] materias = new Materia[] { adicaoUnidades, adicaoDezenas, adicaoCentenas, adicaoMilhar };

            int contadorAlternativa = 1;
            int resposta = 0;

            repositorioDisciplina.Inserir(matematica);

            repositorioMateria.Inserir(adicaoUnidades);
            repositorioMateria.Inserir(adicaoDezenas);
            repositorioMateria.Inserir(adicaoCentenas);
            repositorioMateria.Inserir(adicaoMilhar);

            List<Questao> questoes = new List<Questao>();

            for (int i = 1; i < 40; i++)
            {
                if (i % 10 == 0)
                {
                    resposta = 1;
                    continue;
                }

                int fator, posicaoMateria;

                if (i <= 10)
                {
                    fator = 1; posicaoMateria = 0;
                }

                else if (i <= 20)
                {
                    fator = 10; posicaoMateria = 1;
                }

                else if (i <= 30)
                {
                    fator = 100; posicaoMateria = 2;
                }

                else
                {
                    fator = 1000; posicaoMateria = 3;
                }

                Questao q = NovaQuestaoMatematica(materias[posicaoMateria], ++resposta, fator);

                contadorAlternativa += 4;

                questoes.Add(q);
            }

            foreach (var questao in questoes)
            {
                repositorioQuestao.Inserir(questao);
            }

            Teste novoTeste = new Teste();

            novoTeste.Titulo = "Revisão sobre Adição de Unidades";
            novoTeste.ConfigurarDisciplina(matematica);
            novoTeste.ConfigurarMateria(adicaoUnidades);
            novoTeste.Provao = false;
            novoTeste.QuantidadeQuestoes = 5;
            novoTeste.SortearQuestoes();
            novoTeste.DataGeracao = DateTime.Now;

            repositorioTeste.Inserir(novoTeste);
        }

        private static Questao NovaQuestaoMatematica(Materia materia, int resposta, int fator)
        {
            var questao = new Questao
            {
                Enunciado = $"Quanto é {fator * resposta} + {fator * resposta} ?"
            };

            questao.ConfigurarMateria(materia);

            Alternativa[] alternativas = new Alternativa[4];

            for (int i = 0; i < 4; i++)
            {
                alternativas[i] = new Alternativa
                {
                    Resposta = (fator * resposta * i).ToString()
                };
            }

            foreach (var item in alternativas)
            {
                item.Letra = questao.GerarLetraAlternativa();
                questao.AdicionarAlternativa(item);
            }

            alternativas[2].Resposta = ((fator * resposta) + (fator * resposta)).ToString();
            questao.AtualizarAlternativaCorreta(alternativas[2]);

            return questao;
        }
    }
}
