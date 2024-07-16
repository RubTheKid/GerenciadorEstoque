using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LojasController : ControllerBase
{
    private readonly IMediator _mediator;

    public LojasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLojas()
    {
        var query = new GetAllLojasRequest();
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLojaById(Guid id)
    {
        var query = new GetLojaByIdRequest(id);
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("code/{codigo}")]
    public async Task<IActionResult> GetLojaByCode(string codigo)
    {
        var query = new GetLojaByCodigoRequest(codigo);
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddLojaRequest request)
    {
        try
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateLojaRequest request)
    {
        var response = await _mediator.Send(request);

        if (response is null) return NotFound();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new RemoveLojaRequest { Id = id };

        var response = await _mediator.Send(request);

        if (response is null) return NotFound();

        return Ok(response);
    }
}
