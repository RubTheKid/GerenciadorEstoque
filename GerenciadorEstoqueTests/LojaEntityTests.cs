using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

namespace GerenciadorEstoqueTests;

public class LojaEntityTests
{
    [Fact]
    public void CriarLojaCodigoValido()
    {
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var codigo = new CodigoLoja("1234");
        var telefone = new TelefoneLoja("24", "99999999");

        var loja = new Loja("Loja teste", endereco, codigo, telefone);

        Assert.Equal("Loja teste", loja.Nome);
        Assert.Equal(endereco, loja.Endereco);
        Assert.Equal("1234", loja.Codigo.Codigo);
        Assert.Equal("2499999999", loja.Telefone.Telefone);

    }

    [Fact]
    public void CriarLojaCodigoInvalido()
    {
        var endereco = new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123");
        var telefone = new TelefoneLoja("24", "99999999");

        Assert.Throws<ArgumentException>(() => new CodigoLoja("123"));
        Assert.Throws<ArgumentException>(() => new CodigoLoja("12345"));
        Assert.Throws<ArgumentException>(() => new CodigoLoja("abcd"));
    }


    [Fact]
    public void CriarLojaEnderecoInvalido()
    {
        Assert.Throws<ArgumentException>(() => new Endereco("", "123", "", "Aterrado", "Volta Redonda", "RJ", "12312-123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "", "", "Aterrado", "Volta Redonda", "RJ", "12312-123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "", "Volta Redonda", "RJ", "12312-123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "", "RJ", "12312-123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "", "12312-123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", ""));
    }

    [Fact]
    public void CriarLojaComCepInvalido()
    {
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "123"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "123456789"));
        Assert.Throws<ArgumentException>(() => new Endereco("Rua A", "123", "", "Aterrado", "Volta Redonda", "RJ", "abcd-efgh"));
    }

    [Fact]
    public void CriarLojaTelefoneInvalido()
    {
        Assert.Throws<ArgumentException>(() => new TelefoneLoja("", "99999999"));
        Assert.Throws<ArgumentException>(() => new TelefoneLoja("24", ""));
        Assert.Throws<ArgumentException>(() => new TelefoneLoja("2", "99999999"));
        Assert.Throws<ArgumentException>(() => new TelefoneLoja("24", "99999"));
        Assert.Throws<ArgumentException>(() => new TelefoneLoja("24", "9999999999"));
    }


}
