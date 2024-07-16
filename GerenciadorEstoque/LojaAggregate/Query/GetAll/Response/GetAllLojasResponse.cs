using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

namespace GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Response;

public sealed record GetAllLojasResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public CodigoLoja Codigo { get; set; }
    public Endereco Endereco { get; set; }
    public TelefoneLoja Telefone { get; set; }
}
