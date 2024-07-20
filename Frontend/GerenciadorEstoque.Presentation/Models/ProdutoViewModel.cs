using System.ComponentModel.DataAnnotations;

namespace GerenciadorEstoque.Presentation.Models;


public class ProdutoViewModel
{
    public Guid Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Required]
    [StringLength(11, ErrorMessage = "GTIN deve ter 11 caracteres.")]
    public string Gtin { get; set; }
    [Required]
    public PrecoViewModel Preco { get; set; }
    [Required]
    public int EstoqueMinimo { get; set; }
}



public class PrecoViewModel
{
    [Required]
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
