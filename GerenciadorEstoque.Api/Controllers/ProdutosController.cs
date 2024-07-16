using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProdutos()
    {
        var query = new GetAllProdutosRequest();
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoById(Guid id)
    {
        var query = new GetProdutoByIdRequest(id);
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("gtin/{gtin}")]
    public async Task<IActionResult> GetProdutoByGtin(string gtin)
    {
        var query = new GetProdutoByGtinRequest(gtin);
        var result = await _mediator.Send(query);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddProdutoRequest request)
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
    public async Task<IActionResult> Put(Guid id, UpdateProdutoRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);

        if (response is null) return NotFound();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new RemoveProdutoRequest { Id = id };

        var response = await _mediator.Send(request);

        if (response == null) return NotFound();

        return Ok(response);

    }
}
