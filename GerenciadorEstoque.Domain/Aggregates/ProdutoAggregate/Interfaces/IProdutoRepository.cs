namespace GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto> GetById(Guid id);
    Task<Produto> GetByGtin(string gtin);
    Task<Produto> Create(Produto produto);
    Task<Produto> Update(Produto produto);
    Task Delete(Guid id);
}
