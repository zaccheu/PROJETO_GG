/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 13/05/2024
//* Descrição: Responsável por operações de CRUD no banco de dados para a table de estoque
//* Testes: 
//* Anotações:
    - PRECISA CONFIRMAR O NOME CORRETO DOS STORED PROCEDURES E DOS CAMPOS DA BASE DE DADOS  
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CadastroClientes.Bll
{
    public class EstoqueRepository
    {
        //Crie uma instância de IConfiguration para carregar o appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        //Crie uma instância de AppConnection para carregar a string de conexão
        public AppConnection _appConfig { get; set; }

        //Construtor que recebe a string de conexão
        public EstoqueRepository()
        {
            _appConfig = new AppConnection(configuration);
        }

        //Método para inserir um novo registro na tabela de estoque
        public void Salvar(Estoque estoque)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_ESTOQUE", connection))
                    {
                        // Especifica que o comando é um stored procedure e o executa
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProduto", estoque.IdProduto);
                        cmd.Parameters.AddWithValue("@Quantidade", estoque.Quantidade);

                        cmd.ExecuteNonQuery();
                    }

                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //Método para atualizar um registro na tabela de estoque
        public void Atualizar(Estoque estoque)
        {
            try
            {
                //abre a conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_ESTOQUE", connection))
                    {
                        // Especifica que o comando é um stored procedure e o executa
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProduto", estoque.IdProduto);
                        cmd.Parameters.AddWithValue("@Quantidade", estoque.Quantidade);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //Método para deletar um registro na tabela de estoque
        public void Deletar(int idProduto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_ESTOQUE", connection))
                    {
                        // Especifica que o comando é um stored procedure e o executa
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProduto", idProduto);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
