/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 13/05/2024
//* Descrição: Operações CRUD para a entidade Prato
//* Testes: 
//* Anotações:
    - "Pratos" ou "Produtos"?
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CadastroClientes.Models.Repository
{
    public class PratosRepository
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        public AppConnection _appConfig { get; set; }

        public PratosRepository()
        {
            _appConfig = new AppConnection(configuration);
        }

        public void Inserir(Produtos prato)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_PRATO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nome", prato.Nome);
                        cmd.Parameters.AddWithValue("@IdProduto", prato.IdProduto);
                        cmd.Parameters.AddWithValue("@Preco", prato.Preco);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void Atualizar(Produtos prato)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_PRATO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nome", prato.Nome);
                        cmd.Parameters.AddWithValue("@IdProduto", prato.IdProduto);
                        cmd.Parameters.AddWithValue("@Preco", prato.Preco);
                        cmd.Parameters.AddWithValue("@IdProdutoExistente", prato.IdProduto);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
        }

        public List<Produtos> ListarTodos()
        {
            List<Produtos> pratos = new List<Produtos>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_GET_ALL_PRATOS", connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Produtos prato = new Produtos();

                                prato.Nome = reader["Nome"].ToString();
                                prato.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                                prato.Preco = Convert.ToDouble(reader["Preco"]);

                                pratos.Add(prato);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return pratos;
        }

        public Produtos ObterPorId(int idProduto)
        {
            Produtos prato = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_GET_PRATO_BY_ID", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProduto", idProduto);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prato = new Produtos();

                                prato.Nome = reader["Nome"].ToString();
                                prato.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                                prato.Preco = Convert.ToDouble(reader["Preco"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return prato;
        }

        public bool Deletar(int idProduto)
        {
            bool retorno = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_PRATO", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdProduto", idProduto);

                        int linhas = cmd.ExecuteNonQuery();
                        if (linhas > 0)
                        {
                            retorno = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return retorno;
        }
    }
}