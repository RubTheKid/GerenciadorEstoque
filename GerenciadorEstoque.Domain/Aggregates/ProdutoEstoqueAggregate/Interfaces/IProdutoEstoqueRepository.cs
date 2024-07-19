namespace GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;

public interface IProdutoEstoqueRepository
{
    Task<IEnumerable<ProdutoEstoque>> GetByLojaIdAndProdutoId(Guid lojaId, Guid ProdutoId);
    Task<IEnumerable<ProdutoEstoque>> GetByLojaId(Guid lojaId);
    Task<IEnumerable<ProdutoEstoque>> GetByProdutoId(Guid produtoId);
    Task<ProdutoEstoque> GetById(Guid lojaId, Guid produtoId);
    Task<ProdutoEstoque> Create(ProdutoEstoque produtoEstoque);
    Task<ProdutoEstoque> Update(ProdutoEstoque produtoEstoque);
    Task Delete(Guid lojaId, Guid produtoId);
    Task DeleteByProdutoId(Guid produtoId);
    Task<bool> AtualizarQuantidadeEstoque(Guid lojaId, Guid produtoId, int quantidade);

}
