using GerenciadorEstoque.Api.Controllers;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Command.AddProdutoEstoque.Response;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Request;
using GerenciadorEstoque.Application.ProdutoEstoqueAggregate.Query.GetProdutoEstoque.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GerenciadorEstoqueTests;

public class ProdutoEstoqueControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ProdutoEstoqueController _controller;

    public ProdutoEstoqueControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ProdutoEstoqueController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetProdutoEstoqueByLojaId_ReturnsOkResult_WhenProdutoEstoqueExists()
    {
        var produtosEstoque = new List<ProdutoEstoqueResponse> { new ProdutoEstoqueResponse() };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoEstoqueByLojaIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(produtosEstoque);
        var result = await _controller.GetProdutoEstoqueByLojaId(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetProdutoEstoqueByLojaId_ReturnsNotFound_WhenProdutoEstoqueDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoEstoqueByLojaIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<ProdutoEstoqueResponse>)null);
        var result = await _controller.GetProdutoEstoqueByLojaId(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProdutoEstoqueByProdutoId_ReturnsOkResult_WhenProdutoEstoqueExists()
    {
        var produtosEstoque = new List<ProdutoEstoqueResponse> { new ProdutoEstoqueResponse() };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoEstoqueByProdutoIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(produtosEstoque);
        var result = await _controller.GetProdutoEstoqueByProdutoId(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetProdutoEstoqueByProdutoId_ReturnsNotFound_WhenProdutoEstoqueDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoEstoqueByProdutoIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<ProdutoEstoqueResponse>)null);
        var result = await _controller.GetProdutoEstoqueByProdutoId(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }



    [Fact]
    public async Task AddProdutoEstoque_ReturnsOkResult_WhenRequestIsValid()
    {
        var response = new AddProdutoEstoqueResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddProdutoEstoqueRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
        var request = new AddProdutoEstoqueRequest(Guid.NewGuid(), Guid.NewGuid(), 10);
        var result = await _controller.AddProdutoEstoque(request);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task AddProdutoEstoque_ReturnsInternalServerError_WhenExceptionIsThrown()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddProdutoEstoqueRequest>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Error"));
        var request = new AddProdutoEstoqueRequest(Guid.NewGuid(), Guid.NewGuid(), 10);
        var result = await _controller.AddProdutoEstoque(request);
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }



}
