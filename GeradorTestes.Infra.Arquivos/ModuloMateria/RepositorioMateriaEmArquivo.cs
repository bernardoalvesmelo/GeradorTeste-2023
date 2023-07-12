using GeradorTestes.Dominio;
using GeradorTestes.Dominio.ModuloMateria;
using System.Collections.Generic;

namespace eAgenda.Infra.Arquivos.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        protected GeradorTesteJsonContext contextoDados;

        public RepositorioMateriaEmArquivo(IContextoPersistencia contexto)
        {
            contextoDados = contexto as GeradorTesteJsonContext;
        }

        public override List<Materia> ObterRegistros()
        {
            return contextoDados.Materias;
        }

        public List<Materia> SelecionarTodos(bool incluirDisciplina = false)
        {
            return ObterRegistros();
        }
    }
}
