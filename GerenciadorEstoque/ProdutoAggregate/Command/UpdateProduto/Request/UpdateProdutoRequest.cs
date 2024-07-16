using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Response;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Request;

public sealed record UpdateProdutoRequest : IRequest<UpdateProdutoResponse>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}
