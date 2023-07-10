using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(p => p.Id);

            // 1 : 1 => ItemPedido : Pedido
            builder.HasOne(f => f.Pedido)
                .WithOne(e => e.ItemPedido);

            // 1 : 1 => ItemPedido : Produto
            builder.HasOne(f => f.Produto)
                .WithOne(p => p.ItemPedido);

            builder.ToTable("ItemPedido");
        }
    }
}
