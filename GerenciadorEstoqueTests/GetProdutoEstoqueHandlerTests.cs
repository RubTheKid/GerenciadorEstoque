using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using Moq;


namespace GerenciadorEstoqueTests;

public class ProdutoEstoqueHandlerTests
{
    private readonly Mock<IProdutoEstoqueRepository> _produtoEstoqueRepositoryMock;
    private readonly ProdutoEstoqueHandler _handler;

    public ProdutoEstoqueHandlerTests()
    {
        _produtoEstoqueRepositoryMock = new Mock<IProdutoEstoqueRepository>();
        _handler = new ProdutoEstoqueHandler(_produtoEstoqueRepositoryMock.Object);
    }

    private ProdutoEstoque CreateProdutoEstoque()
    {
        var produto = new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10);
        var loja = new Loja("Loja1", new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("11", "12345678"));
        return new ProdutoEstoque(produto, loja, 100);
    }



    [Fact]
    public async Task Handle_GetProdutoEstoqueByLojaIdRequest_ReturnsProdutoEstoqueResponses()
    {
        var produtoEstoque = CreateProdutoEstoque();
        var request = new GetProdutoEstoqueByLojaIdRequest(produtoEstoque.LojaId);

        _produtoEstoqueRepositoryMock.Setup(r => r.GetByLojaId(produtoEstoque.LojaId)).ReturnsAsync(new List<ProdutoEstoque> { produtoEstoque });

        var result = await _handler.Handle(request, CancellationToken.None);

        _produtoEstoqueRepositoryMock.Verify(r => r.GetByLojaId(produtoEstoque.LojaId), Times.Once);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(produtoEstoque.ProdutoId, result.First().ProdutoId);
        Assert.Equal(produtoEstoque.LojaId, result.First().LojaId);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
        Assert.Equal(produtoEstoque.Produto.Nome, result.First().ProdutoNome);
        Assert.Equal(produtoEstoque.Loja.Nome, result.First().LojaNome);
    }

    [Fact]
    public async Task Handle_GetProdutoEstoqueByProdutoIdRequest_ReturnsProdutoEstoqueResponses()
    {
        var produtoEstoque = CreateProdutoEstoque();
        var request = new GetProdutoEstoqueByProdutoIdRequest(produtoEstoque.ProdutoId);

        _produtoEstoqueRepositoryMock.Setup(r => r.GetByProdutoId(produtoEstoque.ProdutoId)).ReturnsAsync(new List<ProdutoEstoque> { produtoEstoque });

        var result = await _handler.Handle(request, CancellationToken.None);

        _produtoEstoqueRepositoryMock.Verify(r => r.GetByProdutoId(produtoEstoque.ProdutoId), Times.Once);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(produtoEstoque.ProdutoId, result.First().ProdutoId);
        Assert.Equal(produtoEstoque.LojaId, result.First().LojaId);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
        Assert.Equal(produtoEstoque.Produto.Nome, result.First().ProdutoNome);
        Assert.Equal(produtoEstoque.Loja.Nome, result.First().LojaNome);
    }

    [Fact]
    public async Task Handle_GetProdutoEstoqueByLojaIdAndProdutoIdRequest_ReturnsProdutoEstoqueResponses()
    {
        var produtoEstoque = CreateProdutoEstoque();
        var request = new GetProdutoEstoqueByLojaIdAndProdutoIdRequest(produtoEstoque.LojaId, produtoEstoque.ProdutoId);

        _produtoEstoqueRepositoryMock.Setup(r => r.GetByLojaIdAndProdutoId(produtoEstoque.LojaId, produtoEstoque.ProdutoId)).ReturnsAsync(new List<ProdutoEstoque> { produtoEstoque });

        var result = await _handler.Handle(request, CancellationToken.None);

        _produtoEstoqueRepositoryMock.Verify(r => r.GetByLojaIdAndProdutoId(produtoEstoque.LojaId, produtoEstoque.ProdutoId), Times.Once);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(produtoEstoque.ProdutoId, result.First().ProdutoId);
        Assert.Equal(produtoEstoque.LojaId, result.First().LojaId);
        Assert.Equal(produtoEstoque.Estoque, result.First().Estoque);
        Assert.Equal(produtoEstoque.Produto.Nome, result.First().ProdutoNome);
        Assert.Equal(produtoEstoque.Loja.Nome, result.First().LojaNome);
    }
}
