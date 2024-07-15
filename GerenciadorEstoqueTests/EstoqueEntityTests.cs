using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;

namespace GerenciadorEstoqueTests;

public class EstoqueEntityTests
{

    [Fact]
    public void CriarProdutoEstoqueValido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");
        var loja = new Loja("Loja Teste", endereco, codigo, telefone);

        var produtoEstoque = new ProdutoEstoque(produto, loja, 50);

        Assert.Equal(produto, produtoEstoque.Produto);
        Assert.Equal(loja, produtoEstoque.Loja);
        Assert.Equal(50, produtoEstoque.Estoque);
    }

    [Fact]
    public void CriarProdutoEstoqueComProdutoNulo()
    {
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");
        var loja = new Loja("Loja Teste", endereco, codigo, telefone);

        Assert.Throws<ArgumentNullException>(() => new ProdutoEstoque( null, loja, 50));
    }

    [Fact]
    public void CriarProdutoEstoqueComLojaNula()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);

        Assert.Throws<ArgumentNullException>(() => new ProdutoEstoque(produto, null, 50));
    }

    [Fact]
    public void CriarProdutoEstoqueComEstoqueNegativo()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");
        var loja = new Loja("Loja Teste", endereco, codigo, telefone);

        Assert.Throws<ArgumentException>(() => new ProdutoEstoque(produto, loja, -10));
    }

    [Fact]
    public void AlterarQuantidadeProdutoEstoqueValido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");
        var loja = new Loja("Loja Teste", endereco, codigo, telefone);
        var produtoEstoque = new ProdutoEstoque(produto, loja, 50);

        produtoEstoque.AlterarQuantidade(30);

        Assert.Equal(30, produtoEstoque.Estoque);
    }

    [Fact]
    public void AlterarQuantidadeProdutoEstoqueInvalido()
    {
        var preco = new Preco(100.0m);
        var produto = new Produto("Produto Teste", "Descrição do Produto", "1234567890123", preco, 10);
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");
        var loja = new Loja("Loja Teste", endereco, codigo, telefone);
        var produtoEstoque = new ProdutoEstoque(produto, loja, 50);

        Assert.Throws<ArgumentException>(() => produtoEstoque.AlterarQuantidade(-10));
    }

}
