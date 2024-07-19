namespace GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Response;

public class RegistrarVendaResponse
{
    public RegistrarVendaResponse(bool sucesso, string mensagem, Guid? vendaId = null, List<ProdutoVendaResponseItem> produtosVendidos = null)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        VendaId = vendaId;
        ProdutosVendidos = produtosVendidos;
    }

    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public Guid? VendaId { get; set; }
    public List<ProdutoVendaResponseItem> ProdutosVendidos { get; set; }
}

public class ProdutoVendaResponseItem
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}