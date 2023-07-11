using GeradorTestes.Dominio;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Infra.Sql.ModuloQuestao;
using System;
using System.Collections.Generic;

namespace GeradorTestes.Infra.Sql.Compartilhado
{
    public abstract class RepositorioEmSqlBase<TEntidade, TMapeador>
     where TEntidade : EntidadeBase<TEntidade>
     where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected static string enderecoBanco =
           @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GeradorTesteSql;Integrated Security=True";

        protected abstract string sqlInserir { get; }
        protected abstract string sqlEditar { get; }
        protected abstract string sqlExcluir { get; }
        protected abstract string sqlSelecionarTodos { get; }
        protected abstract string sqlSelecionarPorId { get; }

        public virtual void Inserir(TEntidade novoRegistro)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            TMapeador mapeador = new TMapeador();

            //adiciona os parâmetros no comando
            mapeador.ConfigurarParametros(comandoInserir, novoRegistro);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoRegistro.Id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public virtual void Editar(TEntidade registro)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            TMapeador mapeador = new TMapeador();
            //adiciona os parâmetros no comando
            mapeador.ConfigurarParametros(comandoEditar, registro);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", registroSelecionado.Id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorItems = comandoSelecionarPorId.ExecuteReader();

            TEntidade registro = null;

            TMapeador mapeador = new TMapeador();

            if (leitorItems.Read())
                registro = mapeador.ConverterRegistro(leitorItems);

            //encerra a conexão
            conexaoComBanco.Close();

            return registro;
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<TEntidade> registros = new List<TEntidade>();

            TMapeador mapeador = new TMapeador();

            while (leitorItens.Read())
            {
                TEntidade registro = mapeador.ConverterRegistro(leitorItens);

                if (registro != null)
                    registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }

        protected static List<T> SelecionarRegistros<T>(string sql, ConverterRegistroDelegate<T> ConverterRegistro, SqlParameter[] parametros)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sql, conexaoComBanco);

            foreach (SqlParameter parametro in parametros)
            {
                comandoSelecao.Parameters.Add(parametro);
            }

            conexaoComBanco.Open();
            SqlDataReader leitorRegistros = comandoSelecao.ExecuteReader();

            List<T> registros = new List<T>();

            while (leitorRegistros.Read())
            {
                T registro = ConverterRegistro(leitorRegistros);

                registros.Add(registro);
            }

            conexaoComBanco.Close();

            return registros;
        }

        protected static void ExecutarComando(string sql, SqlParameter[] parametros)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            foreach (SqlParameter parametro in parametros)
            {
                comando.Parameters.Add(parametro);
            }

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
    }
}
