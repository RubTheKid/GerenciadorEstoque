using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Request;
using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Response;
using MediatR;

namespace GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Command;


public class RegistrarVendaCommand : IRequest<RegistrarVendaResponse>
{
    public RegistrarVendaRequest VendaRequest { get; set; }

    public RegistrarVendaCommand() { }

    public RegistrarVendaCommand(RegistrarVendaRequest vendaRequest)
    {
        VendaRequest = vendaRequest;
    }
}
