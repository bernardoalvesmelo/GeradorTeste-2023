namespace GeradorTestes.Infra.Sql.Compartilhado
{
    /// <summary>
    /// Este delegate é reponsável por converter linhas de uma tabela em objetos do domínio
    /// </summary>
    /// <typeparam name="T">Classe do Domínio</typeparam>
    /// <param name="leitorRegistro"></param>
    /// <returns>Objeto do Domínio convertido</returns>
    public delegate T ConverterRegistroDelegate<T>(SqlDataReader leitorRegistro);
}
