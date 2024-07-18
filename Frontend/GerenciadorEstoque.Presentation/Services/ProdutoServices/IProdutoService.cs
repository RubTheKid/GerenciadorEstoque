using GerenciadorEstoque.Presentation.Models;

namespace GerenciadorEstoque.Presentation.Services.ProdutoServices;

public interface IProdutoService
{
    Task<ProdutoViewModel> GetProdutoById(Guid id);
    Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();
    Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produto);
    Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produto);
    Task<bool> DeleteProduto(Guid id);

}