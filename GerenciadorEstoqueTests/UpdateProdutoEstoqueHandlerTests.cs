using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using Moq;

namespace GerenciadorEstoqueTests;

public class UpdateProdutoEstoqueHandlerTests
{
    private readonly Mock<IProdutoEstoqueRepository> _produtoEstoqueRepositoryMock;
    private readonly UpdateProdutoEstoqueHandler _handler;

    public UpdateProdutoEstoqueHandlerTests()
    {
        _produtoEstoqueRepositoryMock = new Mock<IProdutoEstoqueRepository>();
        _handler = new UpdateProdutoEstoqueHandler(_produtoEstoqueRepositoryMock.Object);
    }

    private ProdutoEstoque CreateProdutoEstoque()
    {
        var produto = new Produto("Produto1", "Descricao1", "Gtin1", new Preco(100), 10);
        var loja = new Loja("Loja1", new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678"), new CodigoLoja("0001"), new TelefoneLoja("11", "12345678"));
        return new ProdutoEstoque(produto, loja, 100);
    }




}
