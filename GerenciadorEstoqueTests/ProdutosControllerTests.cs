using GerenciadorEstoque.Api.Controllers;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.AddProduto.Response;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.RemoveProduto.Response;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Response;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos.Response;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetProduto.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GerenciadorEstoqueTests;

public class ProdutosControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ProdutosController _controller;

    public ProdutosControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ProdutosController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAllProdutos_ReturnsOkResult_WithListOfProdutos()
    {
        var produtos = new List<GetAllProdutosResponse>
            {
                new GetAllProdutosResponse { Id = Guid.NewGuid(), Nome = "Produto 1" },
                new GetAllProdutosResponse { Id = Guid.NewGuid(), Nome = "Produto 2" }
            };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProdutosRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(produtos);

        var result = await _controller.GetAllProdutos();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<GetAllProdutosResponse>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetAllProdutos_ReturnsNotFound_WhenNoProdutosExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProdutosRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((List<GetAllProdutosResponse>)null);

        var result = await _controller.GetAllProdutos();

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProdutoById_ReturnsOkResult_WithProduto()
    {
        var produto = new GetProdutoResponse { Id = Guid.NewGuid(), Nome = "Produto" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoByIdRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(produto);

        var result = await _controller.GetProdutoById(produto.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<GetProdutoResponse>(okResult.Value);
        Assert.Equal(produto.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetProdutoById_ReturnsNotFound_WhenProdutoDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoByIdRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetProdutoResponse)null);

        var result = await _controller.GetProdutoById(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProdutoByGtin_ReturnsOkResult_WithProduto()
    {
        var produto = new GetProdutoResponse { Id = Guid.NewGuid(), Nome = "Produto" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoByGtinRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(produto);

        var result = await _controller.GetProdutoByGtin("gtin");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<GetProdutoResponse>(okResult.Value);
        Assert.Equal(produto.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetProdutoByGtin_ReturnsNotFound_WhenProdutoDoesNotExist()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProdutoByGtinRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetProdutoResponse)null);

        var result = await _controller.GetProdutoByGtin("gtin");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Post_AddsProduto_ReturnsOkResult()
    {
        var id = Guid.NewGuid();
        var request = new AddProdutoRequest { Nome = "Produto" };
        var response = new AddProdutoResponse { Id = id, Nome = "Produto" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<AddProdutoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var result = await _controller.Post(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<AddProdutoResponse>(okResult.Value);
        Assert.Equal(response.Id, returnValue.Id);
    }

    [Fact]
    public async Task Post_AddProduto_ThrowsException_ReturnsStatusCode500()
    {
        var request = new AddProdutoRequest { Nome = "Produto" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<AddProdutoRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Internal Server Error"));

        var result = await _controller.Post(request);

        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
        Assert.Equal("Internal Server Error", objectResult.Value);
    }
    [Fact]
    public async Task Put_UpdatesProduto_ReturnsOkResult()
    {
        var id = Guid.NewGuid();
        var request = new UpdateProdutoRequest { Id = id, Nome = "Produto Atualizado" };
        var response = new UpdateProdutoResponse { Id = id, Nome = "Produto Atualizado" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateProdutoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var result = await _controller.Put(id, request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<UpdateProdutoResponse>(okResult.Value);
        Assert.Equal(response.Id, returnValue.Id);
        Assert.Equal(response.Nome, returnValue.Nome);
    }

    [Fact]
    public async Task Put_ProdutoNotFound_ReturnsNotFoundResult()
    {
        var id = Guid.NewGuid();
        var request = new UpdateProdutoRequest { Id = id, Nome = "Produto Atualizado" };



        var result = await _controller.Put(id, request);

        Assert.IsType<NotFoundResult>(result);
    }


    [Fact]
    public async Task Delete_Produto_ReturnsOkResult()
    {
        var id = Guid.NewGuid();
        var response = new RemoveProdutoResponse { Id = id };

        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveProdutoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var result = await _controller.Delete(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RemoveProdutoResponse>(okResult.Value);
        Assert.Equal(response.Id, returnValue.Id);
    }


    [Fact]
    public async Task Delete_ProdutoNotFound_ReturnsNotFoundResult()
    {
        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveProdutoRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((RemoveProdutoResponse)null);

        var result = await _controller.Delete(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }
}
