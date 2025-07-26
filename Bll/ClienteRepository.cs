/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 30/04/2024
//* Descrição: Responsável por operações de CRUD no banco de dados
//* Testes: 
//* Anotações:
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using GG.Dto;

namespace GG.Repository
{
    //responsável por salvar as coisas no banco de dados
    public class ClienteRepository
    {
        //Crie uma instância de IConfiguration para carregar o appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        private readonly MeuDbContext _context;

        // Injeção de dependência do DbContext
        public ClienteRepository(MeuDbContext context)
        {
            _context = context;
        }

        public RetornoAcao Salvar(Cliente cliente)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                if (cliente.IdCliente != 0)
                {
                    var clienteExiste = _context.Clientes
                                                .Where(c => c.IdCliente == cliente.IdCliente)
                                                .FirstOrDefault();

                    ConverteEntity(clienteExiste, cliente);

                    _context.Clientes.Update(clienteExiste);

                    retorno.Mensagem = "Cliente atualizado com sucesso!";
                }
                else
                {
                    _context.Clientes.Add(cliente);
                    retorno.Mensagem = "Cliente salvo com sucesso!";
                }

                _context.SaveChanges();

                retorno.Ok = true;
            }
            catch (Exception ex)
            {
                retorno.Mensagem = "ERRO!";
            }
            return retorno;
        }
        public void Atualizar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Cliente> Listar()
        {

            List<Cliente> retorno = new List<Cliente>();

            try
            {
                retorno = _context.Clientes.ToList(); // Exemplo de execução de stored procedure

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RetornoAcao Deletar(string Telefone)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                Cliente cliente = _context.Clientes.Where(c => c.Telefone == Telefone).FirstOrDefault();

                if (cliente == null)
                {
                    retorno.Mensagem = "Prato não encontrado!";
                }
                else
                {
                    _context.Remove(cliente);
                    _context.SaveChanges();
                    retorno.Mensagem = "Prato deletado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }

        public RetornoAcao Inativar(Cliente cliente)
        {
            RetornoAcao retorno = new RetornoAcao();
            try
            {
                cliente.Ativo = false;

                _context.Update(cliente);

                _context.SaveChanges();
                retorno.Mensagem = "Cliente inativado com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Mensagem = ex.Message;
            }
            return retorno;
        }

        public Cliente GetClient(string telefone)
        {
            Cliente cliente = null;

            try
            {
                cliente = _context.Clientes.Where(c => c.Telefone == telefone).FirstOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Cliente ConverteEntity(Cliente existente, Cliente alterado)
        {
            existente.Nome = alterado.Nome;
            existente.Telefone = alterado.Telefone;
            existente.Instagram = alterado.Instagram;
            existente.VIP = alterado.VIP;
            existente.SEXO = alterado.SEXO;
            existente.Ativo = alterado.Ativo;

            return existente;
        }
    }
}

