using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class IdentificacaoPedidoRepository : Repository<IdentificacaoPedido>, IIdentificacaoPedidoRepository
    {
        public IdentificacaoPedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}