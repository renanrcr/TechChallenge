using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}