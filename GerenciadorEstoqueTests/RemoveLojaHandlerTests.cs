using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja;
using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class RemoveLojaHandlerTests
{
    private readonly Mock<ILojaRepository> _repositoryMock;
    private readonly RemoveLojaHandler _handler;

    public RemoveLojaHandlerTests()
    {
        _repositoryMock = new Mock<ILojaRepository>();
        _handler = new RemoveLojaHandler(_repositoryMock.Object);
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

    [Fact]
    public async Task Handle_GivenValidRequest_ShouldRemoveLoja()
    {
        var loja = CreateLoja();

        var command = new RemoveLojaRequest
        {
            Id = loja.Id
        };

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);
        _repositoryMock.Setup(r => r.Delete(It.IsAny<Guid>())).Callback<Guid>(id => loja.IsDeleted = true);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        _repositoryMock.Verify(r => r.Delete(It.IsAny<Guid>()), Times.Once);
        Assert.Equal(loja.Id, result.Id);
        Assert.True(result.IsDeleted);
    }

    [Fact]
    public async Task Handle_GivenNonExistentLoja_ShouldThrowException()
    {
        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Loja)null);

        var command = new RemoveLojaRequest
        {
            Id = Guid.NewGuid()
        };

        var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));

        Assert.Equal("Loja não encontrada", exception.Message);
    }

    [Fact]
    public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }
}
