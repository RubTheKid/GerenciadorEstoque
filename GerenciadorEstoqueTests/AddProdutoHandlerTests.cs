using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Request;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class AddProdutoHandlerTests
{
    private readonly Mock<IProdutoRepository> _mockRepository;
    private readonly AddProdutoHandler _handler;

    public AddProdutoHandlerTests()
    {
        _mockRepository = new Mock<IProdutoRepository>();
        _handler = new AddProdutoHandler(_mockRepository.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateProduto_WhenRequestIsValid()
    {
        var request = new AddProdutoRequest
        {
            Nome = "Produto Teste",
            Descricao = "Descrição Teste",
            Gtin = "1234567890123",
            Preco = 100.0m,
            EstoqueMinimo = 10
        };

        var produto = new Produto(request.Nome, request.Descricao, request.Gtin, new Preco(request.Preco), request.EstoqueMinimo);

        _mockRepository.Setup(repo => repo.Create(It.IsAny<Produto>())).ReturnsAsync(produto);

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Nome, result.Nome);
        Assert.Equal(request.Descricao, result.Descricao);
        Assert.Equal(request.Gtin, result.Gtin);
        Assert.Equal(request.Preco, result.Preco);
        Assert.Equal(request.EstoqueMinimo, result.EstoqueMinimo);

        _mockRepository.Verify(repo => repo.Create(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        AddProdutoRequest request = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_WhenPrecoIsZeroOrNegative()
    {
        var request = new AddProdutoRequest
        {
            Nome = "Produto Teste",
            Descricao = "Descrição Teste",
            Gtin = "1234567890123",
            Preco = -10.0m,
            EstoqueMinimo = 10
        };

        await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldCreateProduto_WhenPrecoIsValid()
    {
        var request = new AddProdutoRequest
        {
            Nome = "Produto Teste",
            Descricao = "Descrição Teste",
            Gtin = "1234567890123",
            Preco = 100.0m,
            EstoqueMinimo = 10
        };

        var produto = new Produto(request.Nome, request.Descricao, request.Gtin, new Preco(request.Preco), request.EstoqueMinimo);

        _mockRepository.Setup(repo => repo.Create(It.IsAny<Produto>())).ReturnsAsync(produto);

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Preco, result.Preco);
        _mockRepository.Verify(repo => repo.Create(It.IsAny<Produto>()), Times.Once);
    }
}
