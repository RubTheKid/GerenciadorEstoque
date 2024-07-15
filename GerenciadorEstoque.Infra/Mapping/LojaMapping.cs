using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorEstoque.Infra.Mapping
{
    public class LojaMapping : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.OwnsOne(x => x.Codigo, cb =>
            {
                cb.Property(x => x.Codigo)
                    .IsRequired()
                    .HasColumnName("Codigo")
                    .HasColumnType("varchar(4)");
            });

            builder.OwnsOne(x => x.Endereco, eb =>
            {
                eb.Property(x => x.Logradouro)
                    .IsRequired()
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar(100)");

                eb.Property(x => x.EnderecoNumero)
                    .IsRequired()
                    .HasColumnName("EnderecoNumero")
                    .HasColumnType("varchar(5)");

                eb.Property(x => x.Complemento)
                    .HasColumnName("Complemento")
                    .HasColumnType("varchar(50)");

                eb.Property(x => x.Bairro)
                    .IsRequired()
                    .HasColumnName("Bairro")
                    .HasColumnType("varchar(50)");

                eb.Property(x => x.Cidade)
                    .IsRequired()
                    .HasColumnName("Cidade")
                    .HasColumnType("varchar(50)");

                eb.Property(x => x.Estado)
                    .IsRequired()
                    .HasColumnName("Estado")
                    .HasColumnType("varchar(2)");

                eb.Property(x => x.Cep)
                    .IsRequired()
                    .HasColumnName("Cep")
                    .HasColumnType("varchar(9)");
            });

            builder.OwnsOne(x => x.Telefone, tb =>
            {
                tb.Property(x => x.CodigoArea)
                    .IsRequired()
                    .HasColumnName("CodigoArea")
                    .HasColumnType("varchar(2)");

                tb.Property(x => x.Numero)
                    .IsRequired()
                    .HasColumnName("Numero")
                    .HasColumnType("varchar(9)");
            });

            builder.ToTable("Lojas");
        }
    }
}
