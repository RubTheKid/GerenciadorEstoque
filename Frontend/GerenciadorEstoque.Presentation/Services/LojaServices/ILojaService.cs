using GerenciadorEstoque.Presentation.Models;

namespace GerenciadorEstoque.Presentation.Services.LojaServices;

public interface ILojaService
{
    Task<LojaViewModel> GetLojaByIdAsync(Guid id);
    Task<IEnumerable<LojaViewModel>> GetAllLojasAsync();
}
