using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;
using GerenciadorEstoque.Infra.Context;
using GerenciadorEstoque.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoqueTests;

public class LojaRepositoryTests
{
    private readonly LojaRepository _repository;
    private readonly AppDbContext _context;

    public LojaRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        _context = new AppDbContext(options);
        _repository = new LojaRepository(_context);
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
    public async Task GetAll_ReturnsLojas()
    {
        var loja = CreateLoja();
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAll();

        Assert.Single(result);
        Assert.Equal(loja.Nome, result.First().Nome);
    }

    [Fact]
    public async Task GetByCode_ReturnsLoja()
    {
        var codigo = "0001";
        var loja = CreateLoja();
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByCode(codigo);

        Assert.NotNull(result);
        Assert.Equal(loja.Nome, result.Nome);
    }

    [Fact]
    public async Task GetById_ReturnsLoja()
    {
        var loja = CreateLoja();
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        var result = await _repository.GetById(loja.Id);

        Assert.NotNull(result);
        Assert.Equal(loja.Nome, result.Nome);
    }

    [Fact]
    public async Task Create()
    {
        var loja = CreateLoja();

        var result = await _repository.Create(loja);

        var addedLoja = await _context.Lojas.FindAsync(result.Id);
        Assert.NotNull(addedLoja);
        Assert.Equal(loja.Nome, addedLoja.Nome);
    }

    [Fact]
    public async Task Update()
    {
        var loja = CreateLoja();
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        loja.AlterarNome("Novo Nome");
        var result = await _repository.Update(loja);

        var updatedLoja = await _context.Lojas.FindAsync(result.Id);
        Assert.NotNull(updatedLoja);
        Assert.Equal("Novo Nome", updatedLoja.Nome);
    }

    [Fact]
    public async Task Delete()
    {
        var loja = CreateLoja();
        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        await _repository.Delete(loja.Id);

        var deletedLoja = await _context.Lojas.FindAsync(loja.Id);
        Assert.NotNull(deletedLoja);
        Assert.True(deletedLoja.IsDeleted);
    }
}
