using GerenciadorEstoque.Presentation.Models;

namespace GerenciadorEstoque.Presentation.Services.VendaViewModel;

public interface IVendaService
{
    Task<bool> RegistrarVenda(RegistrarVendaViewModel venda);
}
