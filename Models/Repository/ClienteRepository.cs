/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 30/04/2024
//* Descrição: Responsável por operações de CRUD no banco de dados para a table de clientes
//* Testes: 
//* Anotações:
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CadastroClientes.Models.Repository
{
    //responsável por salvar as coisas no banco de dados
    public class ClienteRepository
    {
        //Crie uma instância de IConfiguration para carregar o appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        public AppConnection _appConfig { get; set; }
        public ClienteRepository()
        {
            _appConfig = new AppConnection(configuration);
        }
        public void Salvar(Cliente clientes)
        {
            try
            {
                // Cria uma nova instância de SqlConnection (para connectar com a base de dados) usando a string de conexão do appsettings.json, utlizando "using" para garantir que a conexão será fechada após o uso
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    // Cria uma nova instância de SqlCommand (para executar comandos SQL) com o nome da procedure (o qual é definido na base de dados) e a conexão
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_CLIENT", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nome", clientes.Nome);
                        cmd.Parameters.AddWithValue("@Telefone", clientes.Telefone);
                        cmd.Parameters.AddWithValue("@Instagram", clientes.Instagram);
                        cmd.Parameters.AddWithValue("@Sexo", clientes.Sexo);
                        cmd.Parameters.AddWithValue("@VIP", clientes.VIP);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.ToString());
            }
            /*//LISTAMOS TODOS OS ITENS CADASTRO
            var listaClientes = Listar();

            //ENCONTRAMOS O ITEM A SER EXCLUÍDO
            var item = listaClientes.Where(t => t.Documento == clientes.Documento).FirstOrDefault();

            //SE EXISTIR, ELE DELETA
            if (item != null)
            {
                Deletar(clientes.Documento);
            }
            
            //INSERE DE QUALQUER JEITOO
            var clientesTexto = JsonConvert.SerializeObject(clientes) + "," + Environment.NewLine;
        

            string backupFile = JsonConvert.SerializeObject(clientes) + "," + Environment.NewLine;
            File.AppendAllText(@"C:\\Users\\Guzac\\OneDrive\\Documentos\\GitHub\\CursoRafaelPT2\\CadastroBaseClientes\\CadastroBaseClientes\\DB\\fileDB.text", backupFile);
            */
        }
        public void Atualizar(Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_CLIENT", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        cmd.Parameters.AddWithValue("@Instagram", cliente.Instagram);
                        cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                        cmd.Parameters.AddWithValue("@VIP", cliente.VIP);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
        }
        public List<Cliente> Listar()
        {

            List<Cliente> retorno = new List<Cliente>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_LIST_CLIENT", connection))
                    {
                        //(?) executa o cmd (que é uma procedure) e retorna um SqlDataReader (stream com rows do result set da query)
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //loop para ler cada linha do result set
                            while (reader.Read())
                            {
                                //para cada row returnada, adiciona um novo objeto Cliente na lista de retorno
                                Cliente cliente = new Cliente();

                                cliente.Nome = reader["Nome"].ToString();
                                cliente.Telefone = reader["Telefone"].ToString();
                                cliente.Instagram = reader["Instagram"].ToString();
                                cliente.Sexo = reader["Sexo"].ToString();
                                cliente.VIP = Convert.ToBoolean(reader["VIP"]);

                                retorno.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return retorno;
            /*
            string clientes = File.ReadAllText("C:\\Users\\Guzac\\OneDrive\\Documentos\\GitHub\\CursoRafaelPT2\\CadastroBaseClientes\\CadastroBaseClientes\\DB\\fileDB.text");

            List<Clientes> clientesLista = JsonConvert.DeserializeObject<List<Clientes>>("["+clientes+"]");

            return clientesLista.OrderByDescending(k=>k.Nome).ToList();
            */
        }

        public bool Deletar(string Telefone)
        {
            bool retorno = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_CLIENT", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Telefone", Telefone);

                        int linhas = cmd.ExecuteNonQuery();
                        if (linhas > 0)
                        {
                            retorno = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return true;
            /*// Listou os itens cadastrados 
            var listaClientes = Listar();

            //encontrou o que excluir
            var item = listaClientes.Where(t => t.Documento == Documento).FirstOrDefault();
            if (item != null)
            {   // removeu da lista
                listaClientes.Remove(item);

                //limpou o banco de dados
                File.WriteAllText("C:\\Users\\Guzac\\OneDrive\\Documentos\\GitHub\\CursoRafaelPT2\\CadastroBaseClientes\\CadastroBaseClientes\\DB\\fileDB.text", string.Empty);

                //escreveu no banco de dados nossa lista sem o item excluído
                foreach(var I in listaClientes)
                {
                    Salvar(I);
                }

                return true;
            }
            if (Documento == "string")
            {   
                // removeu da lista
                listaClientes.Remove(item);

                //limpou o banco de dados
                File.WriteAllText("C:\\Users\\Guzac\\OneDrive\\Documentos\\GitHub\\CursoRafaelPT2\\CadastroBaseClientes\\CadastroBaseClientes\\DB\\fileDB.text", string.Empty);

                //escreveu no banco de dados nossa lista sem o item excluído
                foreach (var I in listaClientes)
                {
                    Salvar(I);
                }

                return true;
            }

            return false; */
        }

        public Cliente? GetClient(string telefone)
        {
            Cliente cliente = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_appConfig.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_GET_CLIENT", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Telefone", telefone);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Cliente();

                                cliente.Nome = reader["Nome"].ToString();
                                cliente.Telefone = reader["Telefone"].ToString();
                                cliente.Instagram = reader["Instagram"].ToString();
                                cliente.Sexo = reader["Sexo"].ToString();
                                cliente.VIP = Convert.ToBoolean(reader["VIP"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            /*//GETCLIENT
            try
            {
                var ClienteLista = Listar();
                var item = ClienteLista.Where(t => t.Documento == Documento).FirstOrDefault();

                return item;
            } 
            catch (Exception ex) { return null; } */
            return cliente;
        }
    }
}

