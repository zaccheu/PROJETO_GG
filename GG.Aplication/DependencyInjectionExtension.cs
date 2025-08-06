using GG.Aplication.UseCases.Produtos;
using GG.Application.AutoMapper;
using GG.Application.UseCases.Produtos;
using Microsoft.Extensions.DependencyInjection;

namespace GG.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IProdutoUseCase, ProdutoUseCase>();
    }
}
