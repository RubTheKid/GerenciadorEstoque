using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Domain.Entities.LojaAggregate.Validations;

public class CodigoLoja
{
    public string Codigo { get; private set; }

    public CodigoLoja(string codigo)
    {
        if (!Regex.IsMatch(codigo, @"^\d{4}$"))
        {
            throw new ArgumentException("O código deve ter exatamente 4 dígitos.");
        }

        Codigo = codigo;
    }

}
