using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using GerenciadorEstoque.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Moq; // Assuming you are using Moq for mocking

namespace GerenciadorEstoqueTests;

public class ProdutoRepositoryTests
{
    private ProdutoRepository CreateRepository()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var context = new AppDbContext(options);

        var mockProdutoEstoqueRepository = new Mock<IProdutoEstoqueRepository>();

        return new ProdutoRepository(context, mockProdutoEstoqueRepository.Object);
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

    [Fact]
    public async Task GetAll_ReturnsProdutos()
    {
        var repository = CreateRepository();
        var produto = CreateProduto();
        await repository.Create(produto);

        var result = await repository.GetAll();

        Assert.Single(result);
        Assert.Equal(produto.Nome, result.First().Nome);
    }

    [Fact]
    public async Task GetByGtin_ReturnsProduto()
    {
        var repository = CreateRepository();
        var gtin = "1234567890123";
        var produto = CreateProduto();
        await repository.Create(produto);

        var result = await repository.GetByGtin(gtin);

        Assert.NotNull(result);
        Assert.Equal(produto.Nome, result.Nome);
    }

    [Fact]
    public async Task GetById_ReturnsProduto()
    {
        var repository = CreateRepository();
        var produto = CreateProduto();
        await repository.Create(produto);

        var result = await repository.GetById(produto.Id);

        Assert.NotNull(result);
        Assert.Equal(produto.Nome, result.Nome);
    }

    [Fact]
    public async Task Create_AddsProduto()
    {
        var repository = CreateRepository();
        var produto = CreateProduto();

        var result = await repository.Create(produto);

        var addedProduto = await repository.GetById(result.Id);
        Assert.NotNull(addedProduto);
        Assert.Equal(produto.Nome, addedProduto.Nome);
    }

    [Fact]
    public async Task Update_UpdatesProduto()
    {
        var repository = CreateRepository();
        var produto = CreateProduto();
        await repository.Create(produto);

        produto.AlterarPreco(200m);
        var result = await repository.Update(produto);

        var updatedProduto = await repository.GetById(result.Id);
        Assert.NotNull(updatedProduto);
        Assert.Equal(200m, updatedProduto.Preco.Valor);
    }

    [Fact]
    public async Task Delete_MarksProdutoAsDeleted()
    {
        var repository = CreateRepository();
        var produto = CreateProduto();
        await repository.Create(produto);

        await repository.Delete(produto.Id);

        var deletedProduto = await repository.GetById(produto.Id);
        Assert.NotNull(deletedProduto);
        Assert.True(deletedProduto.IsDeleted);
    }
}
