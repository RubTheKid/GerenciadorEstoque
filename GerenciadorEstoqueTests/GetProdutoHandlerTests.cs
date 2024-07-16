using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class GetProdutoHandlerTests
{
    private readonly Mock<IProdutoRepository> _repositoryMock;
    private readonly GetProdutoHandler _handler;

    public GetProdutoHandlerTests()
    {
        _repositoryMock = new Mock<IProdutoRepository>();
        _handler = new GetProdutoHandler(_repositoryMock.Object);
    }

    private Produto CreateProduto()
    {
        return new Produto("Nome", "Descricao", "Gtin", new Preco(100), 10);
    }

    [Fact]
    public async Task Handle_GetProdutoByIdRequest_ReturnsProdutoResponse()
    {
        var produto = CreateProduto();
        var command = new GetProdutoByIdRequest(produto.Id);

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(produto);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(produto.Id, result.Id);
        Assert.Equal(produto.Nome, result.Nome);
        Assert.Equal(produto.Descricao, result.Descricao);
        Assert.Equal(produto.EstoqueMinimo, result.EstoqueMinimo);
        Assert.Equal(produto.Gtin, result.Gtin);
    }

    [Fact]
    public async Task Handle_GetProdutoByIdRequest_ReturnsNullWhenNotFound()
    {
        var command = new GetProdutoByIdRequest(Guid.NewGuid());

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Produto)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_GetProdutoByGtinRequest_ReturnsProdutoResponse()
    {
        var produto = CreateProduto();
        var command = new GetProdutoByGtinRequest(produto.Gtin);

        _repositoryMock.Setup(r => r.GetByGtin(It.IsAny<string>())).ReturnsAsync(produto);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetByGtin(It.IsAny<string>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(produto.Id, result.Id);
        Assert.Equal(produto.Nome, result.Nome);
        Assert.Equal(produto.Descricao, result.Descricao);
        Assert.Equal(produto.EstoqueMinimo, result.EstoqueMinimo);
        Assert.Equal(produto.Gtin, result.Gtin);
    }

    [Fact]
    public async Task Handle_GetProdutoByGtinRequest_ReturnsNullWhenNotFound()
    {
        var command = new GetProdutoByGtinRequest("Gtin");

        _repositoryMock.Setup(r => r.GetByGtin(It.IsAny<string>())).ReturnsAsync((Produto)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetByGtin(It.IsAny<string>()), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_GetProdutoByIdRequest_NullRequest_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle((GetProdutoByIdRequest)null, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_GetProdutoByGtinRequest_NullRequest_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle((GetProdutoByGtinRequest)null, CancellationToken.None));
    }
}
