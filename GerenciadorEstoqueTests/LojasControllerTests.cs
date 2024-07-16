using GerenciadorEstoque.Api.Controllers;
using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.AddLoja.Response;
using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.RemoveLoja.Response;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Command.UpdateLoja.Response;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetAll.Response;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Request;
using GerenciadorEstoque.Application.LojaAggregate.Query.GetLoja.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GerenciadorEstoqueTests;

public class LojasControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly LojasController _controller;

    public LojasControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new LojasController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAllLojas_ReturnsOkResult_WhenLojasExist()
    {
        var lojas = new List<GetAllLojasResponse> { new GetAllLojasResponse() };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLojasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(lojas);
        var result = await _controller.GetAllLojas();
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetAllLojas_ReturnsNotFound_WhenNoLojasExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLojasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((List<GetAllLojasResponse>)null);
        var result = await _controller.GetAllLojas();
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetLojaById_ReturnsOkResult_WhenLojaExists()
    {
        var loja = new GetLojaResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetLojaByIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(loja);
        var result = await _controller.GetLojaById(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetLojaById_ReturnsNotFound_WhenLojaDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetLojaByIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetLojaResponse)null);
        var result = await _controller.GetLojaById(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetLojaByCode_ReturnsOkResult_WhenLojaExists()
    {
        var loja = new GetLojaResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetLojaByCodigoRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(loja);
        var result = await _controller.GetLojaByCode("0001");
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetLojaByCode_ReturnsNotFound_WhenLojaDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetLojaByCodigoRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((GetLojaResponse)null);
        var result = await _controller.GetLojaByCode("0001");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Post_ReturnsOkResult_WhenAddLojaRequestIsValid()
    {
        var response = new AddLojaResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddLojaRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
        var result = await _controller.Post(new AddLojaRequest());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task Post_ReturnsInternalServerError_WhenExceptionIsThrown()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddLojaRequest>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Error"));
        var result = await _controller.Post(new AddLojaRequest());
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task Put_ReturnsOkResult_WhenUpdateLojaRequestIsValid()
    {
        var response = new UpdateLojaResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateLojaRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
        var result = await _controller.Put(new UpdateLojaRequest());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task Put_ReturnsNotFound_WhenLojaDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateLojaRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((UpdateLojaResponse)null);
        var result = await _controller.Put(new UpdateLojaRequest());
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsOkResult_WhenRemoveLojaRequestIsValid()
    {
        var response = new RemoveLojaResponse();
        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveLojaRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
        var result = await _controller.Delete(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenLojaDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveLojaRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync((RemoveLojaResponse)null);
        var result = await _controller.Delete(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }
}
