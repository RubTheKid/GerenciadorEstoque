using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Request;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class UpdateProdutoHandlerTests
{
    private readonly Mock<IProdutoRepository> _mockRepository;
    private readonly UpdateProdutoHandler _handler;

    public UpdateProdutoHandlerTests()
    {
        _mockRepository = new Mock<IProdutoRepository>();
        _handler = new UpdateProdutoHandler(_mockRepository.Object);
    }

    private UpdateProdutoRequest CreateRequest(Guid produtoId)
    {
        return new UpdateProdutoRequest
        {
            Id = produtoId,
            Nome = "Produto Atualizado",
            Descricao = "Descrição Atualizada",
            Gtin = "1234567890124",
            Preco = 150.0m,
            EstoqueMinimo = 5
        };
    }

    [Fact]
    public async Task Handle_ShouldUpdateNome_WhenNomeIsUpdated()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10);
        _mockRepository.Setup(repo => repo.GetById(produtoId)).Returns(Task.FromResult(produto));
        _mockRepository.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.FromResult(produto));

        var request = CreateRequest(produtoId);
        request.Nome = "Produto Atualizado";

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Nome, result.Nome);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateDescricao_WhenDescricaoIsUpdated()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10);
        _mockRepository.Setup(repo => repo.GetById(produtoId)).Returns(Task.FromResult(produto));
        _mockRepository.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.FromResult(produto));

        var request = CreateRequest(produtoId);
        request.Descricao = "Descrição Atualizada";

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Descricao, result.Descricao);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateGtin_WhenGtinIsUpdated()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10);
        _mockRepository.Setup(repo => repo.GetById(produtoId)).Returns(Task.FromResult(produto));
        _mockRepository.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.FromResult(produto));

        var request = CreateRequest(produtoId);
        request.Gtin = "1234567890124";

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Gtin, result.Gtin);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdatePreco_WhenPrecoIsUpdated()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10);
        _mockRepository.Setup(repo => repo.GetById(produtoId)).Returns(Task.FromResult(produto));
        _mockRepository.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.FromResult(produto));

        var request = CreateRequest(produtoId);
        request.Preco = 150.0m;

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Preco, result.Preco);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateEstoqueMinimo_WhenEstoqueMinimoIsUpdated()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10);
        _mockRepository.Setup(repo => repo.GetById(produtoId)).Returns(Task.FromResult(produto));
        _mockRepository.Setup(repo => repo.Update(It.IsAny<Produto>())).Returns(Task.FromResult(produto));

        var request = CreateRequest(produtoId);
        request.EstoqueMinimo = 5;

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.EstoqueMinimo, result.EstoqueMinimo);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Update(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        UpdateProdutoRequest request = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenProdutoNotFound()
    {
        var produtoId = Guid.NewGuid();
        _mockRepository.Setup(repo => repo.GetById(produtoId)).ReturnsAsync((Produto)null);

        var request = CreateRequest(produtoId);

        await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
    }
}
