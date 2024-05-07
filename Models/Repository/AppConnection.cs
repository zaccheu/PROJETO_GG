/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 30/04/2024
//* Descrição: Adquire a string de conexão com o banco de dados a partir do arquivo de configuração
//* Testes: 
//* Anotações:
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

namespace CadastroClientes.Models.Repository
{
    public class AppConnection
    {
        public string ConnectionString { get; set; }

        public AppConnection(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("ConnString");
        }
    }
}
