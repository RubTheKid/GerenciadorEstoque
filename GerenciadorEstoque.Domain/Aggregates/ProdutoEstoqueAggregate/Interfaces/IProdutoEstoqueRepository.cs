namespace GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;

public interface IProdutoEstoqueRepository
{
    Task<IEnumerable<ProdutoEstoque>> GetByLojaId(Guid lojaId);
    Task<IEnumerable<ProdutoEstoque>> GetByProdutoId(Guid produtoId);
    Task<ProdutoEstoque> Create(ProdutoEstoque produtoEstoque);
    Task<ProdutoEstoque> Update(ProdutoEstoque produtoEstoque);
    Task Delete(Guid id);
}
