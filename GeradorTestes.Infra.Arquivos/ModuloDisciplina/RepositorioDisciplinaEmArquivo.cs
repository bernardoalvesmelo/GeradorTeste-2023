using GeradorTestes.Dominio;
using GeradorTestes.Dominio.ModuloDisciplina;
using System.Collections.Generic;

namespace eAgenda.Infra.Arquivos.ModuloDisciplina
{
    public class RepositorioDisciplinaEmArquivo : 
        RepositorioEmArquivoBase<Disciplina>, IRepositorioDisciplina
    {
        protected GeradorTesteJsonContext contextoDados;

        public RepositorioDisciplinaEmArquivo(IContextoPersistencia contexto)
        {
            contextoDados = contexto as GeradorTesteJsonContext;
        }

        public override List<Disciplina> ObterRegistros()
        {
            return contextoDados.Disciplinas;
        }

        public List<Disciplina> SelecionarTodos(bool incluirMaterias = false, bool incluirQuestoes = false)
        {
            return ObterRegistros();
        }
    }
}
