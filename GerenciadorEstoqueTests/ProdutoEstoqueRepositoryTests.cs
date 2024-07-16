using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Infra.Context;
using GerenciadorEstoque.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoqueTests;

public class ProdutoEstoqueRepositoryTests
{
    private ProdutoEstoqueRepository CreateRepository()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        var context = new AppDbContext(options);
        return new ProdutoEstoqueRepository(context);
    }

    private Produto CreateProduto()
    {
        return new Produto(
            "Produto Teste",
            "Descrição Teste",
            "1234567890123",
            new Preco(100m),
            10
        );
    }

    private Loja CreateLoja()
    {
        return new Loja(
            "Loja Teste",
            new Endereco("Rua Teste", "123", "Apto 1", "Bairro Teste", "Cidade Teste", "ST", "12345-678"),
            new CodigoLoja("0001"),
            new TelefoneLoja("11", "12345678")
        );
    }

    private ProdutoEstoque CreateProdutoEstoque()
    {
        var produto = CreateProduto();
        var loja = CreateLoja();
        return new ProdutoEstoque(produto, loja, 100);
    }

    [Fact]
    public async Task GetByLojaId_ReturnsProdutoEstoques()
    {
        var repository = CreateRepository();
        var produtoEstoque = CreateProdutoEstoque();
        await repository.Create(produtoEstoque);

        var result = await repository.GetByLojaId(produtoEstoque.LojaId);

        Assert.Single(result);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
    }

    [Fact]
    public async Task GetByProdutoId_ReturnsProdutoEstoques()
    {
        var repository = CreateRepository();
        var produtoEstoque = CreateProdutoEstoque();
        await repository.Create(produtoEstoque);

        var result = await repository.GetByProdutoId(produtoEstoque.ProdutoId);

        Assert.Single(result);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
    }

    [Fact]
    public async Task GetByLojaIdAndProdutoId_ReturnsProdutoEstoque()
    {
        var repository = CreateRepository();
        var produtoEstoque = CreateProdutoEstoque();
        await repository.Create(produtoEstoque);

        var result = await repository.GetByLojaIdAndProdutoId(produtoEstoque.LojaId, produtoEstoque.ProdutoId);

        Assert.Single(result);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
    }

    [Fact]
    public async Task Create_AddsProdutoEstoque()
    {
        var repository = CreateRepository();
        var produtoEstoque = CreateProdutoEstoque();

        var result = await repository.Create(produtoEstoque);

        var addedProdutoEstoque = await repository.GetByLojaIdAndProdutoId(result.LojaId, result.ProdutoId);
        Assert.NotNull(addedProdutoEstoque);
        Assert.Equal(produtoEstoque.Estoque, addedProdutoEstoque.First().Estoque);
    }

    [Fact]
    public async Task Update_UpdatesProdutoEstoque()
    {
        var repository = CreateRepository();
        var produtoEstoque = CreateProdutoEstoque();
        await repository.Create(produtoEstoque);

        produtoEstoque.AlterarQuantidade(200);
        var result = await repository.Update(produtoEstoque);

        var updatedProdutoEstoque = await repository.GetByLojaIdAndProdutoId(result.LojaId, result.ProdutoId);
        Assert.NotNull(updatedProdutoEstoque);
        Assert.Equal(200, updatedProdutoEstoque.First().Estoque);
    }

}
