using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Infra.Mapping;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Nome")
            .HasColumnType("varchar(100)");

        builder.Property(x => x.Descricao)
            .HasMaxLength(500)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(500)");

        builder.Property(x => x.Gtin)
            .IsRequired()
            .HasMaxLength(13)
            .HasColumnName("Gtin")
            .HasColumnType("varchar(13)");

        builder.OwnsOne(x => x.Preco, eb =>
        {
            eb.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)");
        });

        builder.Property(x => x.EstoqueMinimo)
            .IsRequired()
            .HasColumnName("EstoqueMinimo")
            .HasColumnType("int");

        builder.ToTable("Produtos");
    }
}
