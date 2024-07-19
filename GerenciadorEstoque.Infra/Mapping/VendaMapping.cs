using GerenciadorEstoque.Domain.Aggregates.VendaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorEstoque.Infra.Mapping;

public class VendaMapping : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataVenda)
               .IsRequired();

        builder.Property(x => x.Codigo)
               .IsRequired();

        builder.HasOne(x => x.Loja)
               .WithMany()
               .HasForeignKey(x => x.LojaId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.VendaProdutos)
               .WithOne()
               .HasForeignKey(vp => vp.VendaId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
