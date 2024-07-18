using GerenciadorEstoque.Presentation.Models;

namespace GerenciadorEstoque.Presentation.Services.EstoqueServices;

public interface IEstoqueService
{
    Task<IEnumerable<EstoqueViewModel>> GetEstoqueByLojaId(Guid lojaId);
    Task<IEnumerable<EstoqueViewModel>> GetEstoqueByProdutoId(Guid produtoId);
}
