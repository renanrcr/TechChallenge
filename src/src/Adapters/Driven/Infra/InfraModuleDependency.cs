using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;
using TechChallenge.src.Adapters.Driving.Api.WebHooks;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Adapters.Driven.Infra
{
    public static class InfraModuleDependency
    {
        public static void AddInfraModule(this IServiceCollection services)
        {
            services.AddScoped<DataBaseContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITabelaPrecoRepository, TabelaPrecoRepository>();
            services.AddScoped<IIdentificacaoPedidoRepository, IdentificacaoPedidoRepository>();
            services.AddSingleton<IReceiveWebhook, ConsoleWebhookReceiver>();
        }
    }
}