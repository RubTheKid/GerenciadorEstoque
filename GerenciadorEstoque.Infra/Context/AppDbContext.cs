using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;
using GerenciadorEstoque.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Loja> Lojas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<VendaProduto> VendaProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LojaMapping());
        modelBuilder.ApplyConfiguration(new ProdutoMapping());
        modelBuilder.ApplyConfiguration(new ProdutoEstoqueMapping());
        modelBuilder.ApplyConfiguration(new VendaMapping());
        modelBuilder.ApplyConfiguration(new VendaProdutoMapping());
        base.OnModelCreating(modelBuilder);
    }

}
