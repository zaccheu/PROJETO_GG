/*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//* Autor(es): 
//* Data da última modificação: 13/05/2024
//* Descrição: Controller para a entidade Estoque
//* Testes: 
//* Anotações:
    - As "business rules" precisam ser consultadas para garantir assertividade
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

using CadastroClientes.Models;
using CadastroClientes.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Collections.Specialized;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        [HttpPost("Salvar")]
        public IActionResult Salvar(Estoque estoque)
        {
            try
            {
                EstoqueRepository estoques = new EstoqueRepository();
                estoques.Salvar(estoque);
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log it or return an appropriate error response
            }

            return Ok(estoque);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody] Estoque estoque)
        {
            try
            {
                EstoqueRepository estoques = new EstoqueRepository();
                estoques.Atualizar(estoque);
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log it or return an appropriate error response
            }

            return Ok(estoque);
        }
    }
}