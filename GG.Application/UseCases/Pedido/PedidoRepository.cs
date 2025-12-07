//using GG.Dto;
//using GG.Models;

//namespace GG.Application.UseCases.Pedido;

//public class PedidoRepository
//{
//    IConfiguration configuration = new ConfigurationBuilder()
//        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//        .AddJsonFile("appsettings.json")
//        .Build();

//    private readonly MeuDbContext _context;

//    // Injeção de dependência do DbContext
//    public PedidoRepository(MeuDbContext context)
//    {
//        _context = context;
//    }

//    [HttpGet("PagarPedido")]
//    public RetornoAcao PagarPedido(int IdPedido)
//    {
//        RetornoAcao retorno = new RetornoAcao();

//        try
//        {
//            Pedido pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == IdPedido);

//            if (pedido == null)
//            {
//                retorno.Mensagem = "Pedido não encontrado!";
//                return retorno;
//            }
//            else if (pedido.Pago)
//            {
//                retorno.Mensagem = "Pedido já foi pago!";
//                return retorno;
//            }
//            else if (pedido.Pago == false)
//            {
//                pedido.Pago = true;
//                _context.SaveChanges();
//                retorno.Ok = true;
//                retorno.Mensagem = "Pedido pago com sucesso!";
//            }
//        }
//        catch (Exception ex)
//        {
//            retorno.Ok = false;
//            throw new Exception(ex.Message);
//        }
//        return retorno;
//    }
//}
