using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Request;

public sealed record AddProdutoRequest : IRequest<AddProdutoResponse>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}
