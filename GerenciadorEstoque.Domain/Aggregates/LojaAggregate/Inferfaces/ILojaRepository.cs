namespace GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Inferfaces;

public interface ILojaRepository
{
    Task<IEnumerable<Loja>> GetAll();
    Task<Loja> GetById(Guid id);
    Task<Loja> GetByCode(string code);
    Task<Loja> Create(Loja loja);
    Task<Loja> Update(Loja loja);
    Task Delete(Guid id);
}
