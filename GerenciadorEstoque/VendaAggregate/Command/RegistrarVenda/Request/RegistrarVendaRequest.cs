namespace GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Request;

public class RegistrarVendaRequest
{
    public Guid LojaId { get; set; }
    public int Codigo { get; set; }
    public List<ProdutoVendaItemRequest> ProdutosVendidos { get; set; }

    public RegistrarVendaRequest() { }

    public RegistrarVendaRequest(Guid lojaId, int codigo, List<ProdutoVendaItemRequest> produtosVendidos)
    {
        LojaId = lojaId;
        Codigo = codigo;
        ProdutosVendidos = produtosVendidos;
    }
}

public class ProdutoVendaItemRequest
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}
