using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Request;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class RemoveProdutoHandlerTests
{
    private readonly Mock<IProdutoRepository> _mockRepository;
    private readonly RemoveProdutoHandler _handler;

    public RemoveProdutoHandlerTests()
    {
        _mockRepository = new Mock<IProdutoRepository>();
        _handler = new RemoveProdutoHandler(_mockRepository.Object);
    }

    [Fact]
    public async Task Handle_ShouldRemoveProduto_WhenRequestIsValid()
    {
        var produtoId = Guid.NewGuid();
        var produto = new Produto("Produto Teste", "Descrição Teste", "1234567890123", new Preco(100.0m), 10)
        {
            Id = produtoId,
            IsDeleted = true,
            DateDeleted = DateTime.Now
        };

        _mockRepository.Setup(repo => repo.GetById(produtoId)).ReturnsAsync(produto);
        _mockRepository.Setup(repo => repo.Delete(produtoId)).Returns(Task.CompletedTask);

        var request = new RemoveProdutoRequest { Id = produtoId };

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(produto.Id, result.Id);
        Assert.True(result.isDeleted);
        Assert.Equal(produto.DateDeleted.Value, result.DateDeleted);

        _mockRepository.Verify(repo => repo.GetById(produtoId), Times.Once);
        _mockRepository.Verify(repo => repo.Delete(produtoId), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        RemoveProdutoRequest request = null;

        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenProdutoNotFound()
    {
        var produtoId = Guid.NewGuid();

        _mockRepository.Setup(repo => repo.GetById(produtoId)).ReturnsAsync((Produto)null);

        var request = new RemoveProdutoRequest { Id = produtoId };

        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
    }
}
