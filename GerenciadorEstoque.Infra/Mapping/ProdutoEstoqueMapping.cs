using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorEstoque.Infra.Mapping;

public class ProdutoEstoqueMapping : IEntityTypeConfiguration<ProdutoEstoque>
{
    public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Produto)
               .WithOne()
               .HasForeignKey<ProdutoEstoque>(x => x.ProdutoId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Loja)
               .WithOne()
               .HasForeignKey<ProdutoEstoque>(x => x.LojaId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Estoque)
               .IsRequired()
               .HasColumnName("Estoque")
               .HasColumnType("int")
               .HasPrecision(7);

        builder.ToTable("ProdutoEstoques");
    }
}

