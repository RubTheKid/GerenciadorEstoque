using GerenciadorEstoque.Domain.Aggregates.VendaAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorEstoque.Infra.Mapping;

public class VendaProdutoMapping : IEntityTypeConfiguration<VendaProduto>
{
    public void Configure(EntityTypeBuilder<VendaProduto> builder)
    {
        builder.HasKey(x => new { x.ProdutoId, x.VendaId });

        builder.Property(x => x.Quantidade)
               .IsRequired();

        builder.HasOne(x => x.Produto)
               .WithMany()
               .HasForeignKey(x => x.ProdutoId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Venda>()
               .WithMany(v => v.VendaProdutos)
               .HasForeignKey(x => x.VendaId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}