namespace GerenciadorEstoque.Presentation.Models;


public class ProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public PrecoViewModel Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}



public class PrecoViewModel
{
    public decimal Valor { get; set; }
}


public class ProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Gtin { get; set; }
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }
}
