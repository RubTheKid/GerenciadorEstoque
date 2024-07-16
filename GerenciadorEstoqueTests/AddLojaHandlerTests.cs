using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja;
using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Inferfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class AddLojaHandlerTests
{
    private Mock<ILojaRepository> _repositoryMock;
    private AddLojaHandler _handler;

    public AddLojaHandlerTests()
    {
        _repositoryMock = new Mock<ILojaRepository>();
        _handler = new AddLojaHandler(_repositoryMock.Object);
    }

    private AddLojaRequest CreateAddLojaRequest()
    {
        return new AddLojaRequest
        {
            Nome = "Loja Teste",
            Endereco = new Endereco("Rua Teste", "123", "Apto 1", "Bairro Teste", "Cidade Teste", "ST", "12345-678"),
            Codigo = new CodigoLoja("0001"),
            Telefone = new TelefoneLoja("11", "12345678")
        };
    }

    [Fact]
    public async Task Handle_GivenValidRequest_ShouldReturnAddLojaResponse()
    {
        // Arrange
        var request = CreateAddLojaRequest();
        var loja = new Loja(request.Nome, request.Endereco, request.Codigo, request.Telefone);

        _repositoryMock.Setup(r => r.Create(It.IsAny<Loja>())).ReturnsAsync(loja);

        // Act
        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert
        _repositoryMock.Verify(r => r.Create(It.IsAny<Loja>()), Times.Once);
        Assert.NotNull(response);
        Assert.Equal(request.Nome, response.Nome);
        Assert.Equal(request.Endereco, response.Endereco);
        Assert.Equal(request.Codigo, response.Codigo);
        Assert.Equal(request.Telefone, response.Telefone);
    }

    [Fact]
    public async Task Handle_GivenNullRequest_ThrowsArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }
}
