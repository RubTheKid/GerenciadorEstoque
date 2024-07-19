using GerenciadorEstoque.Domain.Aggregates.VendaAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repository;

public class VendaRepository : IVendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Venda> Create(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task<Venda> GetById(Guid id)
    {
        return await _context.Vendas
            .Include(v => v.VendaProdutos)
            .ThenInclude(vp => vp.Produto)
            .Include(v => v.Loja)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<IEnumerable<Venda>> GetAll()
    {
        return await _context.Vendas
            .Include(v => v.VendaProdutos)
            .ThenInclude(vp => vp.Produto)
            .Include(v => v.Loja)
            .ToListAsync();
    }
}