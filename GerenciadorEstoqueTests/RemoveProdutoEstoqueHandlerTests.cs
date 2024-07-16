using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using Moq;


namespace GerenciadorEstoqueTests;

public class DeleteProdutoEstoqueHandlerTests
{
    private readonly Mock<IProdutoEstoqueRepository> _produtoEstoqueRepositoryMock;
    private readonly DeleteProdutoEstoqueHandler _handler;

    public DeleteProdutoEstoqueHandlerTests()
    {
        _produtoEstoqueRepositoryMock = new Mock<IProdutoEstoqueRepository>();
        _handler = new DeleteProdutoEstoqueHandler(_produtoEstoqueRepositoryMock.Object);
    }

    private ProdutoEstoque CreateProdutoEstoque()
    {
        var produto = new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10);
        var loja = new Loja("Loja1", new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("11", "12345678"));
        return new ProdutoEstoque(produto, loja, 100);
    }





    [Fact]
    public async Task Handle_NullRequest_ThrowsArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }
}
