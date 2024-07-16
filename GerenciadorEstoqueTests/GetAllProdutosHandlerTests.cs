using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Request;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class GetAllProdutosHandlerTests
{
    private readonly Mock<IProdutoRepository> _repositoryMock;
    private readonly GetAllProdutosHandler _handler;

    public GetAllProdutosHandlerTests()
    {
        _repositoryMock = new Mock<IProdutoRepository>();
        _handler = new GetAllProdutosHandler(_repositoryMock.Object);
    }

    private List<Produto> CreateProdutos()
    {
        return new List<Produto>
            {
                new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10),
                new Produto("Produto2", "Descricao2", "Gtin2", new Preco(200), 20)
            };
    }

    [Fact]
    public async Task Handle_ReturnsAllProdutos()
    {
        var produtos = CreateProdutos();

        _repositoryMock.Setup(r => r.GetAll()).ReturnsAsync(produtos);

        var request = new GetAllProdutosRequest();
        var result = await _handler.Handle(request, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(produtos.Count, result.Count());
        Assert.Equal(produtos[0].Id, result.ElementAt(0).Id);
        Assert.Equal(produtos[0].Nome, result.ElementAt(0).Nome);
        Assert.Equal(produtos[1].Id, result.ElementAt(1).Id);
        Assert.Equal(produtos[1].Nome, result.ElementAt(1).Nome);
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoProdutosExist()
    {
        _repositoryMock.Setup(r => r.GetAll()).ReturnsAsync(new List<Produto>());

        var request = new GetAllProdutosRequest();
        var result = await _handler.Handle(request, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
