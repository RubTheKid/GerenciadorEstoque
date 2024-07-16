using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Inferfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using Moq;

namespace GerenciadorEstoqueTests;

public class UpdateLojaHandlerTests
{
    private readonly Mock<ILojaRepository> _repositoryMock;
    private readonly UpdateLojaHandler _handler;

    public UpdateLojaHandlerTests()
    {
        _repositoryMock = new Mock<ILojaRepository>();
        _handler = new UpdateLojaHandler(_repositoryMock.Object);
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
    public async Task Handle_UpdateNomeRequest_ShouldUpdateNome()
    {
        var loja = CreateLoja();
        var command = new UpdateNomeRequest
        {
            LojaId = loja.Id,
            NovoNome = "Novo Nome"
        };

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<Loja>()), Times.Once);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal("Novo Nome", result.Nome);
    }

    [Fact]
    public async Task Handle_UpdateEnderecoRequest_ShouldUpdateEndereco()
    {
        var loja = CreateLoja();
        var novoEndereco = new Endereco("Nova Rua", "456", "Apto 2", "Novo Bairro", "Nova Cidade", "NT", "87654-321");
        var command = new UpdateEnderecoRequest
        {
            LojaId = loja.Id,
            NovoEndereco = novoEndereco
        };

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<Loja>()), Times.Once);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal(novoEndereco, result.Endereco);
    }

    [Fact]
    public async Task Handle_UpdateCodigoRequest_ShouldUpdateCodigo()
    {
        var loja = CreateLoja();
        var novoCodigo = new CodigoLoja("0002");
        var command = new UpdateCodigoRequest
        {
            LojaId = loja.Id,
            NovoCodigo = novoCodigo
        };

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<Loja>()), Times.Once);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal(novoCodigo, result.Codigo);
    }

    [Fact]
    public async Task Handle_UpdateTelefoneRequest_ShouldUpdateTelefone()
    {
        var loja = CreateLoja();
        var novoTelefone = new TelefoneLoja("22", "987654321");
        var command = new UpdateTelefoneRequest
        {
            LojaId = loja.Id,
            NovoTelefone = novoTelefone
        };

        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(loja);

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.GetById(It.IsAny<Guid>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<Loja>()), Times.Once);
        Assert.Equal(loja.Id, result.Id);
        Assert.Equal(novoTelefone, result.Telefone);
    }

    [Fact]
    public async Task Handle_GivenNullRequest_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle((UpdateNomeRequest)null, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_GivenNonExistentLoja_ThrowsException()
    {
        _repositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync((Loja)null);

        var command = new UpdateNomeRequest
        {
            LojaId = Guid.NewGuid(),
            NovoNome = "Novo Nome"
        };

        var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));

        Assert.Equal("Loja não encontrada", exception.Message);
    }
}
