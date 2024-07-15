using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;

namespace GerenciadorEstoqueTests;

public class ProdutoEntityTests
{
    [Fact]
    public void CriarProdutoValido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);

        Assert.Equal("Produto Teste", produto.Nome);
        Assert.Equal("Descrição do Produto", produto.Descricao);
        Assert.Equal("1234567890123", produto.Gtin);
        Assert.Equal(100.0m, produto.Preco.Valor);
        Assert.Equal(10, produto.EstoqueMinimo);
    }

    [Fact]
    public void CriarProdutoNomeNulo()
    {
        var preco = new Preco(100.0m);

        Assert.Throws<ArgumentNullException>(() => new Produto(null, "Descrição do Produto", "1234567890123", preco, 10));
    }

    [Fact]
    public void CriarProdutoPrecoInvalido()
    {
        Assert.Throws<ArgumentException>(() => new Preco(-10.0m));
        Assert.Throws<ArgumentException>(() => new Preco(0.0m));
    }

    [Fact]
    public void AlterarPrecoProdutoValido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);

        produto.AlterarPreco(150.0m);

        Assert.Equal(150.0m, produto.Preco.Valor);
    }

    [Fact]
    public void AlterarPrecoProdutoInvalido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);

        Assert.Throws<ArgumentException>(() => produto.AlterarPreco(-50.0m));
        Assert.Throws<ArgumentException>(() => produto.AlterarPreco(0.0m));
    }
}
