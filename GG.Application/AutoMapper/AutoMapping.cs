using AutoMapper;
using GG.Communication.Responses;
using GG.Domain.Entity;
using GG.Dto;

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
    }

    private void EntityToResponse()
    {
        CreateMap<Produto, ResponseProdutosRegistradosJson>();
        CreateMap<Produto, ResponseProdutosJson>();
        CreateMap<Categoria, ResponseCategoriaRegistradaJson>();
        CreateMap<Categoria, ResponseCategoriaJson>();
    }
}
