namespace GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate.Interfaces;

public interface IVendaProdutoRepository
{
    Task<VendaProduto> Create(VendaProduto vendaProduto);
    Task<IEnumerable<VendaProduto>> GetByVendaId(Guid vendaId);
    Task<VendaProduto> GetById(Guid vendaId, Guid produtoId);
    Task Delete(Guid vendaId, Guid produtoId);
}
