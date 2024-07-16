using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Request;
using GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto.Response;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.ProdutoAggregate.Command.UpdateProduto;

public class UpdateProdutoHandler : IRequestHandler<UpdateProdutoRequest, UpdateProdutoResponse>
{
    private readonly IProdutoRepository _repository;

    public UpdateProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProdutoResponse> Handle(UpdateProdutoRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var produto = await _repository.GetById(request.Id);

        if (produto == null)
        {
            throw new NotFoundException("Produto não encontrado.");
        }

        produto.AlterarNome(request.Nome);
        produto.AlterarDescricao(request.Descricao);
        produto.AlterarGtin(request.Gtin);
        produto.AlterarPreco(request.Preco);
        produto.AlterarEstoqueMinimo(request.EstoqueMinimo);
        produto.DateModified = DateTime.Now;

        await _repository.Update(produto);

        return new UpdateProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Gtin = produto.Gtin,
            Preco = produto.Preco.Valor,
            EstoqueMinimo = produto.EstoqueMinimo,
            DateModified = produto.DateModified
        };
    }
}

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
