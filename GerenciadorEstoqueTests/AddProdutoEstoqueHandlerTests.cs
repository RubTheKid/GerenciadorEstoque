using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using Moq;

namespace GerenciadorEstoqueTests;

public class AddProdutoEstoqueHandlerTests
{
    private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
    private readonly Mock<ILojaRepository> _lojaRepositoryMock;
    private readonly Mock<IProdutoEstoqueRepository> _produtoEstoqueRepositoryMock;
    private readonly AddProdutoEstoqueHandler _handler;

    public AddProdutoEstoqueHandlerTests()
    {
        _produtoRepositoryMock = new Mock<IProdutoRepository>();
        _lojaRepositoryMock = new Mock<ILojaRepository>();
        _produtoEstoqueRepositoryMock = new Mock<IProdutoEstoqueRepository>();
        _handler = new AddProdutoEstoqueHandler(_produtoRepositoryMock.Object, _lojaRepositoryMock.Object, _produtoEstoqueRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ValidRequest_AddsProdutoEstoque()
    {
        var produto = new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10);
        var loja = new Loja("Loja1", new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("11", "12345678"));
        var request = new AddProdutoEstoqueRequest(produto.Id, loja.Id, 100);

        _produtoRepositoryMock.Setup(r => r.GetById(produto.Id)).ReturnsAsync(produto);
        _lojaRepositoryMock.Setup(r => r.GetById(loja.Id)).ReturnsAsync(loja);
        _produtoEstoqueRepositoryMock.Setup(r => r.Create(It.IsAny<ProdutoEstoque>())).ReturnsAsync((ProdutoEstoque pe) => pe);

        var result = await _handler.Handle(request, CancellationToken.None);

        _produtoRepositoryMock.Verify(r => r.GetById(produto.Id), Times.Once);
        _lojaRepositoryMock.Verify(r => r.GetById(loja.Id), Times.Once);
        _produtoEstoqueRepositoryMock.Verify(r => r.Create(It.IsAny<ProdutoEstoque>()), Times.Once);

        Assert.NotNull(result);
        Assert.Equal(produto.Id, result.ProdutoId);
        Assert.Equal(loja.Id, result.LojaId);
        Assert.Equal(100, result.Estoque);
    }

    [Fact]
    public async Task Handle_InvalidProdutoId_ThrowsArgumentNullException()
    {
        var loja = new Loja("Loja1", new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("11", "12345678"));
        var request = new AddProdutoEstoqueRequest(Guid.NewGuid(), loja.Id, 100);

        _produtoRepositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Produto)null);
        _lojaRepositoryMock.Setup(r => r.GetById(loja.Id)).ReturnsAsync(loja);

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_InvalidLojaId_ThrowsArgumentNullException()
    {
        var produto = new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10);
        var request = new AddProdutoEstoqueRequest(produto.Id, Guid.NewGuid(), 100);

        _produtoRepositoryMock.Setup(r => r.GetById(produto.Id)).ReturnsAsync(produto);
        _lojaRepositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Loja)null);

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }
}
