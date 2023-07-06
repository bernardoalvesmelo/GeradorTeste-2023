using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace GeradorTestes.Dominio.ModuloTeste
{
    public class Gabarito
    {
        public List<AlternativaCorreta> QuestoesCorretas;

        public void AdicionaQuestaoCorreta(int id, char letra)
        {
            QuestoesCorretas.Add(new AlternativaCorreta(id, letra));
        }

    }
}
