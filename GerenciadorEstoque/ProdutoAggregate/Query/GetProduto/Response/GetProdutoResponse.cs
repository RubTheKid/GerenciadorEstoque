using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Validations;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Response;

public sealed record GetProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public Preco Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}
