using GG.Communication.Responses;
using GG.Dto;

namespace GG.Application.UseCases.Categorias;

public interface ICategoriaUseCase
{
    Task <ResponseCategoriaRegistradaJson> Salvar(RequestSalvarCategoriaJson categoria);
    Task <List<ResponseCategoriaJson>> Listar();
    Task<bool> Deletar(int idCategoria);
}
