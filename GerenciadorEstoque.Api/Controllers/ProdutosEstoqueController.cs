using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.DeleteProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.UpdateProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoEstoqueController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoEstoqueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("loja/{lojaId}/produto/{produtoId}")]
    public async Task<IActionResult> GetProdutoEstoqueById(Guid lojaId, Guid produtoId)
    {
        var query = new GetProdutoEstoqueByLojaIdAndProdutoIdRequest(lojaId, produtoId);
        var result = await _mediator.Send(query);

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpGet("loja/{lojaId}")]
    public async Task<IActionResult> GetProdutoEstoqueByLojaId(Guid lojaId)
    {
        var query = new GetProdutoEstoqueByLojaIdRequest(lojaId);
        var result = await _mediator.Send(query);

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpGet("produto/{produtoId}")]
    public async Task<IActionResult> GetProdutoEstoqueByProdutoId(Guid produtoId)
    {
        var query = new GetProdutoEstoqueByProdutoIdRequest(produtoId);
        var result = await _mediator.Send(query);

        if (result == null) return NotFound();

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> AddProdutoEstoque(AddProdutoEstoqueRequest request)
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
    public async Task<IActionResult> UpdateProdutoEstoque(UpdateProdutoEstoqueRequest request)
    {
        var response = await _mediator.Send(request);

        if (response == null) return NotFound();

        return Ok(response);
    }

  
}
