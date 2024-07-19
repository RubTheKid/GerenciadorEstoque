namespace GerenciadorEstoque.Domain.Aggregates.VendaAggregate.Interfaces;

public interface IVendaRepository
{
    Task<Venda> Create(Venda venda);
    Task<IEnumerable<Venda>> GetAll();
    Task<Venda> GetById(Guid id);
}
