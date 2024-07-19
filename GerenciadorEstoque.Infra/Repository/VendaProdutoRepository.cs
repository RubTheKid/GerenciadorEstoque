using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repository;

public class VendaProdutoRepository : IVendaProdutoRepository
{
    private readonly AppDbContext _context;

    public VendaProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VendaProduto> Create(VendaProduto vendaProduto)
    {
        _context.VendaProdutos.Add(vendaProduto);
        await _context.SaveChangesAsync();
        return vendaProduto;
    }

    public async Task<IEnumerable<VendaProduto>> GetByVendaId(Guid vendaId)
    {
        return await _context.VendaProdutos
            .Include(x => x.Produto)
            .Where(x => x.VendaId == vendaId)
            .ToListAsync();
    }

    public async Task<VendaProduto> GetById(Guid vendaId, Guid produtoId)
    {
        return await _context.VendaProdutos
            .Include(x => x.Produto)
            .FirstOrDefaultAsync(x => x.VendaId == vendaId && x.ProdutoId == produtoId);
    }

    public async Task Delete(Guid vendaId, Guid produtoId)
    {
        var vendaProduto = await GetById(vendaId, produtoId);
        if (vendaProduto != null)
        {
            _context.VendaProdutos.Remove(vendaProduto);
            await _context.SaveChangesAsync();
        }
    }
}
