using GerenciadorEstoque.Domain.Aggregates.LojaAggregate;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Inferfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repository;

public class LojaRepository : ILojaRepository
{
    private readonly AppDbContext _context;

    public LojaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Loja>> GetAll()
    {
        return await _context.Lojas.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<Loja> GetByCode(string code)
    {
        return await _context.Lojas.FirstOrDefaultAsync(x => x.Codigo.Codigo == code && !x.IsDeleted);

    }

    public async Task<Loja> GetById(Guid id)
    {
        return await _context.Lojas.Where(x => x.Id == id).FirstOrDefaultAsync();
    }


    public async Task<Loja> Create(Loja loja)
    {
        loja.DateCreated = DateTime.Now;
        loja.IsDeleted = false;

        _context.Lojas.Add(loja);
        await _context.SaveChangesAsync();

        return loja;
    }

    public async Task<Loja> Update(Loja loja)
    {
        if (loja == null)
        {
            throw new ArgumentNullException(nameof(loja), "Os dados da loja não podem estar em branco");
        }
        if (string.IsNullOrWhiteSpace(loja.Nome))
        {
            throw new ArgumentException("O nome da loja não pode estar em branco.");
        }

        loja.DateModified = DateTime.Now;
        _context.Entry(loja).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return loja;
    }

    public async Task Delete(Guid id)
    {
        var loja = await _context.Set<Loja>().FirstOrDefaultAsync(x => x.Id == id);

        if (loja != null)
        {
            loja.DateDeleted = DateTime.Now;
            loja.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}