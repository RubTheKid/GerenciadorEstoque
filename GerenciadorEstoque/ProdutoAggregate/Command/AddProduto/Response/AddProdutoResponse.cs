namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Response;

public sealed record AddProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}
