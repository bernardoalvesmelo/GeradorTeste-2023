﻿namespace GeradorTestes.Dominio.ModuloMateria
{
    public interface IRepositorioMateria : IRepositorio<Materia>
    {
        Materia SelecionarPorNome(string nome);
    }
}