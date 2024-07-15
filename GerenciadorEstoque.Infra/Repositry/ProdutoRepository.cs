using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEstoque.Infra.Repositry
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Produto> GetByGtin(string gtin)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Gtin == gtin && !x.IsDeleted);
        }

        public async Task<Produto> GetById(Guid id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Produto> Create(Produto produto)
        {
            produto.DateCreated = DateTime.Now;
            produto.IsDeleted = false;

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


        public async Task<Produto> Update(Produto produto)
        {
            var existingProduto = await _context.Produtos.FindAsync(produto.Id);
            if (existingProduto == null)
            {
                return null;
            }

            produto.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();
            return produto;


        }

        public async Task Delete(Guid id)
        {
            var produto = await _context.Set<Produto>().FirstOrDefaultAsync(x => x.Id == id);

            if (produto != null)
            {
                produto.IsDeleted = true;
                produto.DateDeleted = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }



    }
}
