using GG.Domain.Repositories;
using GG.Domain.Repositories.Despesas;
using GG.Domain.Repositories.PedidoPrato;
using GG.Domain.Repositories.Pedidos;
using GG.Domain.Repositories.Prato;
using GG.Domain.Repositories.PratoProduto;
using GG.Domain.Repositories.Produtos;
using GG.Infrastructure.DataAccess;
using GG.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GG.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPedidoRepository, PedidosRepository>();
        services.AddScoped<IPedidoPratoRepository, PedidoPratoRepository>();
        services.AddScoped<IPratoRepository, PratoRepository>();
        services.AddScoped<IPratoProdutoRepository, PratoProdutoRepository>();
        services.AddScoped<IProdutoRepository, ProdutosRepository>();
        services.AddScoped<IDespesaRepository, DespesaRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MeuDbContext");

        services.AddDbContext<GGDbContext>(config =>
            config.UseSqlServer(connectionString));
    }
}