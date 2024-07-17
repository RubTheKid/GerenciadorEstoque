using System.Text.RegularExpressions;

namespace GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Validations;

public class CodigoLoja
{
    public string Codigo { get; set; }

    public CodigoLoja(string codigo)
    {
        if (!Regex.IsMatch(codigo, @"^\d{4}$"))
        {
            throw new ArgumentException("O código deve ter exatamente 4 dígitos.");
        }

        Codigo = codigo;
    }

}
