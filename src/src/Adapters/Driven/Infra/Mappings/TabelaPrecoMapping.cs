using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Mappings
{
    public class TabelaPrecoMapping : IEntityTypeConfiguration<TabelaPreco>
    {
        public void Configure(EntityTypeBuilder<TabelaPreco> builder)
        {
            builder.HasKey(p => p.Id);

            // 1 : 1 => TabelaPreco : Produto
            builder.HasOne(f => f.Produto)
                .WithOne(e => e.TabelaPreco);

            builder.ToTable("TabelaPreco");
        }
    }
}