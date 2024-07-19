using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repository
{
    public class ProdutoEstoqueRepository : IProdutoEstoqueRepository
    {
        private readonly AppDbContext _context;

        public ProdutoEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoEstoque>> GetByLojaId(Guid lojaId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                 .Include(x => x.Loja)
                                                 .Where(x => x.LojaId == lojaId)
                                                 .ToListAsync();
        }

        public async Task<IEnumerable<ProdutoEstoque>> GetByProdutoId(Guid produtoId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                 .Include(x => x.Loja)
                                                 .Where(x => x.ProdutoId == produtoId)
                                                 .ToListAsync();
        }

        public async Task<ProdutoEstoque> GetById(Guid lojaId, Guid produtoId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                 .Include(x => x.Loja)
                                                 .FirstOrDefaultAsync(x => x.ProdutoId == produtoId && x.LojaId == lojaId);
        }

        public async Task<IEnumerable<ProdutoEstoque>> GetByLojaIdAndProdutoId(Guid lojaId, Guid produtoId)
        {
            return await _context.ProdutoEstoques.Include(x => x.Produto)
                                                 .Include(x => x.Loja)
                                                 .Where(x => x.ProdutoId == produtoId && x.LojaId == lojaId)
                                                 .ToListAsync();
        }

        public async Task<ProdutoEstoque> Create(ProdutoEstoque produtoEstoque)
        {
            _context.ProdutoEstoques.Add(produtoEstoque);
            await _context.SaveChangesAsync();
            return produtoEstoque;
        }

        public async Task<ProdutoEstoque> Update(ProdutoEstoque produtoEstoque)
        {
            var existingProdutoEstoque = await GetById(produtoEstoque.LojaId, produtoEstoque.ProdutoId);
            if (existingProdutoEstoque == null)
            {
                return null;
            }

            _context.Entry(existingProdutoEstoque).CurrentValues.SetValues(produtoEstoque);
            await _context.SaveChangesAsync();
            return produtoEstoque;
        }

        public async Task Delete(Guid lojaId, Guid produtoId)
        {
            var produtoEstoque = await GetById(lojaId, produtoId);
            if (produtoEstoque != null)
            {
                _context.ProdutoEstoques.Remove(produtoEstoque);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByProdutoId(Guid produtoId)
        {
            var produtoEstoques = await _context.ProdutoEstoques.Where(x => x.ProdutoId == produtoId).ToListAsync();
            _context.ProdutoEstoques.RemoveRange(produtoEstoques);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> AtualizarQuantidadeEstoque(Guid lojaId, Guid produtoId, int quantidade)
        {
            var produtoEstoque = await GetById(lojaId, produtoId);
            if (produtoEstoque == null)
            {
                return false;
            }

            produtoEstoque.AlterarQuantidade(quantidade);
            _context.ProdutoEstoques.Update(produtoEstoque);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
