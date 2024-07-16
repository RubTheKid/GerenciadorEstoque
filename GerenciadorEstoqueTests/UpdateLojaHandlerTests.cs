using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Core;
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

    [Fact]
    public async Task Handle_ShouldUpdateNome_WhenValidRequest()
    {
        var lojaId = Guid.NewGuid();
        var loja = new Loja("Nome Antigo", new Endereco("Rua 1", "123", "Complemento", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("12", "123456789"));
        typeof(BaseEntity).GetProperty(nameof(BaseEntity.Id)).SetValue(loja, lojaId);

        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync(loja);
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoNome = "Nome Novo"
        };

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(lojaId, response.Id);
        Assert.Equal("Nome Novo", response.Nome);
        _repositoryMock.Verify(repo => repo.Update(loja), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenLojaNotFound()
    {
        var lojaId = Guid.NewGuid();
        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync((Loja)null);
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoNome = "Nome Novo"
        };

        await Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldUpdateEndereco_WhenValidRequest()
    {
        var lojaId = Guid.NewGuid();
        var loja = new Loja("Nome Antigo", new Endereco("Rua 1", "123", "Complemento", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("12", "123456789"));
        typeof(BaseEntity).GetProperty(nameof(BaseEntity.Id)).SetValue(loja, lojaId);

        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync(loja);
        var novoEndereco = new Endereco("Rua 2", "456", "Novo Complemento", "Novo Bairro", "Nova Cidade", "Novo Estado", "98765-432");
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoEndereco = novoEndereco
        };

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(lojaId, response.Id);
        Assert.Equal(novoEndereco, response.Endereco);
        _repositoryMock.Verify(repo => repo.Update(loja), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateCodigo_WhenValidRequest()
    {
        var lojaId = Guid.NewGuid();
        var loja = new Loja("Nome Antigo", new Endereco("Rua 1", "123", "Complemento", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("12", "123456789"));
        typeof(BaseEntity).GetProperty(nameof(BaseEntity.Id)).SetValue(loja, lojaId);

        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync(loja);
        var novoCodigo = new CodigoLoja("0002");
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoCodigo = novoCodigo
        };

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(lojaId, response.Id);
        Assert.Equal(novoCodigo, response.Codigo);
        _repositoryMock.Verify(repo => repo.Update(loja), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateTelefone_WhenValidRequest()
    {
        var lojaId = Guid.NewGuid();
        var loja = new Loja("Nome Antigo", new Endereco("Rua 1", "123", "Complemento", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("12", "123456789"));
        typeof(BaseEntity).GetProperty(nameof(BaseEntity.Id)).SetValue(loja, lojaId);

        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync(loja);
        var novoTelefone = new TelefoneLoja("12", "987654321");
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoTelefone = novoTelefone
        };

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(lojaId, response.Id);
        Assert.Equal(novoTelefone, response.Telefone);
        _repositoryMock.Verify(repo => repo.Update(loja), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldUpdateMultipleFields_WhenValidRequest()
    {
        var lojaId = Guid.NewGuid();
        var loja = new Loja("Nome Antigo", new Endereco("Rua 1", "123", "Complemento", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("12", "123456789"));
        typeof(BaseEntity).GetProperty(nameof(BaseEntity.Id)).SetValue(loja, lojaId);

        _repositoryMock.Setup(repo => repo.GetById(lojaId)).ReturnsAsync(loja);
        var novoEndereco = new Endereco("Rua 2", "456", "Novo Complemento", "Novo Bairro", "Nova Cidade", "Novo Estado", "98765-432");
        var novoTelefone = new TelefoneLoja("12", "987654321");
        var request = new UpdateLojaRequest
        {
            LojaId = lojaId,
            NovoNome = "Nome Novo",
            NovoEndereco = novoEndereco,
            NovoTelefone = novoTelefone
        };

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(lojaId, response.Id);
        Assert.Equal("Nome Novo", response.Nome);
        Assert.Equal(novoEndereco, response.Endereco);
        Assert.Equal(novoTelefone, response.Telefone);
        _repositoryMock.Verify(repo => repo.Update(loja), Times.Once);
    }
}