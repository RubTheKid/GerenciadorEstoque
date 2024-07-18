namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Response;

public sealed record UpdateProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }
    public DateTime? DateModified { get; set; }
}
