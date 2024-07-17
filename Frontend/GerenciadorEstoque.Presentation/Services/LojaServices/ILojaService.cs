using GerenciadorEstoque.Presentation.Models;

namespace GerenciadorEstoque.Presentation.Services.LojaServices;

public interface ILojaService
{
    Task<LojaViewModel> GetLojaByIdAsync(Guid id);
    Task<IEnumerable<LojaViewModel>> GetAllLojasAsync();
    Task<LojaViewModel> GetLojaByCodeAsync(string codigo);
    Task<bool> AddLojaAsync(LojaViewModel loja);
    Task<bool> UpdateLojaAsync(LojaViewModel request);
    Task<bool> RemoveLojaAsync(Guid id);
}
