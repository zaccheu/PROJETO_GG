using AutoMapper;
using GG.Communication.Requests;
using GG.Communication.Responses;
using GG.Communication.Responses.Despesa;
using GG.Communication.Responses.Pedido;
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
        CreateMap<RequestSalvarPedidoJson, Pedido>();
        //CreateMap<RequestSalvarPedidoItemJson, PedidoItem>();
    }

    private void EntityToResponse()
    {
        CreateMap<Produto, ResponseProdutoRegistradoJson>();
        CreateMap<Produto, ResponseProdutosJson>();
        CreateMap<Categoria, ResponseCategoriaRegistradaJson>();
        CreateMap<Categoria, ResponseCategoriaJson>();
        CreateMap<Pedido, ResponsePedidoRegistradoJson>();
        CreateMap<Pedido, ResponsePedidoJson>();
        CreateMap<Despesa, ResponseDespesaJson>();
        CreateMap<Despesa, ResponseDespesaRegistradaJson>();
    }
}
