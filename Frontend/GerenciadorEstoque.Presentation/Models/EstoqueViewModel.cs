namespace GerenciadorEstoque.Presentation.Models;

public class EstoqueViewModel
{
    public Guid ProdutoId { get; set; }
    public Guid LojaId { get; set; }
    public int Estoque { get; set; }
    public string Descricao { get; set; }
    public int EstoqueMinimo { get; set; }
    public PrecoViewModel Preco { get; set; }
    public string ProdutoNome { get; set; }
    public string LojaNome { get; set; }
}

public class LojaDetalhesViewModel
{
    public LojaViewModel Loja { get; set; }
    public IEnumerable<EstoqueViewModel> Estoque { get; set; }
}

public class ProdutoDetalhesViewModel
{
    public ProdutoViewModel Produto { get; set; }
    public IEnumerable<EstoqueViewModel> Estoque { get; set; }
}
