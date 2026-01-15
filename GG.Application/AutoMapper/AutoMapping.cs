using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Despesa;
using GG.Communication.Responses.Pedido;
using GG.Communication.Responses.Prato;
using GG.Communication.Responses.Produto;
using GG.Domain.Entity;

namespace GG.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestSalvarProdutoJson, Produto>();
        CreateMap<RequestSalvarCategoriaJson, Categoria>();
        CreateMap<RequestSalvarPedidoJson, Pedido>()
            .ForMember(dest => dest.PedidoPratos, opt => opt.Ignore());
        CreateMap<RequestSalvarPratoJson, Prato>();
    }

    private void EntityToResponse()
    {
        CreateMap<Produto, ResponseProdutoRegistradoJson>();
        CreateMap<Produto, ResponseProdutoJson>();
        CreateMap<Categoria, ResponseCategoriaRegistradaJson>();
        CreateMap<Categoria, ResponseCategoriaJson>();
        CreateMap<Despesa, ResponseDespesaJson>();
        CreateMap<Despesa, ResponseDespesaRegistradaJson>();
        
        // Mapeamento para Prato
        CreateMap<Prato, ResponsePratoJson>();
        CreateMap<Prato, ResponsePratoRegistradoJson>();
        
        // Mapeamento para Pedido
        CreateMap<Pedido, ResponsePedidoRegistradoJson>();
        CreateMap<Pedido, ResponsePedidoJson>()
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.PedidoPratos));
        
        CreateMap<PedidoPrato, ResponseItemPedidoJson>()
            .ForMember(dest => dest.NomePrato, opt => opt.MapFrom(src => src.Prato.Nome));
    }
}
