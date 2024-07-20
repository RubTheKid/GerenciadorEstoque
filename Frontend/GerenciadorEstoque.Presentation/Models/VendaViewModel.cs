namespace GerenciadorEstoque.Presentation.Models;

public class RegistrarVendaViewModel
{
    public Guid LojaId { get; set; }
    public int Codigo { get; set; }
    public List<ProdutoVendaViewModel> ProdutosVendidos { get; set; }
    public List<LojaViewModel> Lojas { get; set; }
    public List<ProdutoViewModel> Produtos { get; set; }
    public List<EstoqueViewModel> Estoque { get; set; }
}

public class ProdutoVendaViewModel
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}


