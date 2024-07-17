using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Application.LojaAggregate.DTOs;

public class LojaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
}
