using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repository
{
    public class ProdutoEstoqueRepository : IProdutoEstoqueRepository
    {
        public readonly AppDbContext _context;

        public ProdutoEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoEstoque>> GetByLojaId(Guid lojaId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                    .Include(x => x.Loja)
                                                    .Where(x => x.LojaId == lojaId && !x.IsDeleted)
                                                    .ToListAsync();
        }

        public async Task<IEnumerable<ProdutoEstoque>> GetByProdutoId(Guid produtoId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                    .Include(x => x.Loja)
                                                    .Where(x => x.ProdutoId == produtoId && !x.IsDeleted)
                                                    .ToListAsync();
        }
        public async Task<IEnumerable<ProdutoEstoque>> GetByLojaIdAndProdutoId(Guid lojaId, Guid ProdutoId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                    .Include(x => x.Loja)
                                                    .Where(x => x.ProdutoId == ProdutoId && x.LojaId == lojaId && !x.IsDeleted)
                                                    .ToListAsync();
        }

        public async Task<ProdutoEstoque> Create(ProdutoEstoque produtoEstoque)
        {
            produtoEstoque.DateCreated = DateTime.Now;
            produtoEstoque.IsDeleted = false;

            _context.ProdutoEstoques.Add(produtoEstoque);
            await _context.SaveChangesAsync();
            return produtoEstoque;
        }

        public async Task<ProdutoEstoque> Update(ProdutoEstoque produtoEstoque)
        {
            var existingProdutoEstoque = await _context.ProdutoEstoques.FindAsync(produtoEstoque.Id);
            if (existingProdutoEstoque == null)
            {
                return null;
            }

            produtoEstoque.DateModified = DateTime.Now;
            _context.Entry(existingProdutoEstoque).CurrentValues.SetValues(produtoEstoque);


            await _context.SaveChangesAsync();
            return produtoEstoque;
        }

        public async Task Delete(Guid id)
        {
            var produtoEstoque = await _context.Set<ProdutoEstoque>().FirstOrDefaultAsync();

            if (produtoEstoque != null)
            {
                produtoEstoque.IsDeleted = true;
                produtoEstoque.DateDeleted = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }



    }
}
