using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class GetLojaHandlerTests
{
    private readonly Mock<ILojaRepository> _repositoryMock;
    private readonly GetLojaHandler _handler;

    public GetLojaHandlerTests()
    {
        _repositoryMock = new Mock<ILojaRepository>();
        _handler = new GetLojaHandler(_repositoryMock.Object);
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
    public async Task Handle_GetLojaByIdRequest_ReturnsLoja()
    {
        var loja = CreateLoja();
        var command = new GetLojaByIdRequest(loja.Id);

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal(loja.Nome, result.Nome);
    }

    [Fact]
    public async Task Handle_GetLojaByIdRequest_ReturnsNullWhenNotFound()
    {
        var command = new GetLojaByIdRequest(Guid.NewGuid());

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Loja)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_GetLojaByCodigoRequest_ReturnsLoja()
    {
        var loja = CreateLoja();
        var command = new GetLojaByCodigoRequest(loja.Codigo.Codigo);

        _repositoryMock.Setup(r => r.GetByCode(It.IsAny<string>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetByCode(It.IsAny<string>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal(loja.Nome, result.Nome);
    }

    [Fact]
    public async Task Handle_GetLojaByCodigoRequest_ReturnsNullWhenNotFound()
    {
        var command = new GetLojaByCodigoRequest("0001");

        _repositoryMock.Setup(r => r.GetByCode(It.IsAny<string>())).ReturnsAsync((Loja)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetByCode(It.IsAny<string>()), Times.Once);
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_GivenNullRequest_ShouldThrowArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle((GetLojaByIdRequest)null, CancellationToken.None));
    }
}
