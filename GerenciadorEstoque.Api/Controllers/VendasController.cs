using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Command;
using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarVenda([FromBody] RegistrarVendaRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new RegistrarVendaCommand(request);
        var result = await _mediator.Send(command);

        if (!result.Sucesso)
        {
            return BadRequest(result.Mensagem);
        }

        return Ok(result);
    }
}