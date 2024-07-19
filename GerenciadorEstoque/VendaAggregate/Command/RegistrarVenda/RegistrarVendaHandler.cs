using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Command;
using GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda.Response;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.VendaAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate.Interfaces;
using MediatR;

namespace GerenciadorEstoque.Application.VendaAggregate.Command.RegistrarVenda;

public class RegistrarVendaCommandHandler : IRequestHandler<RegistrarVendaCommand, RegistrarVendaResponse>
{
    private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;
    private readonly IVendaRepository _vendaRepository;
    private readonly IVendaProdutoRepository _vendaProdutoRepository;
    private readonly ILojaRepository _lojaRepository;

    public RegistrarVendaCommandHandler(IProdutoEstoqueRepository produtoEstoqueRepository, IVendaRepository vendaRepository, IVendaProdutoRepository vendaProdutoRepository, ILojaRepository lojaRepository)
    {
        _produtoEstoqueRepository = produtoEstoqueRepository;
        _vendaRepository = vendaRepository;
        _vendaProdutoRepository = vendaProdutoRepository;
        _lojaRepository = lojaRepository;
    }

    public async Task<RegistrarVendaResponse> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
    {
        if (request.VendaRequest.ProdutosVendidos == null || request.VendaRequest.ProdutosVendidos.Count == 0)
        {
            return new RegistrarVendaResponse(false, "Nenhum produto fornecido para a venda.");
        }

        var loja = await _lojaRepository.GetById(request.VendaRequest.LojaId);
        if (loja == null)
        {
            return new RegistrarVendaResponse(false, "Loja não encontrada.");
        }

        var venda = new Venda(request.VendaRequest.LojaId, loja, request.VendaRequest.Codigo);

        await _vendaRepository.Create(venda);

        var produtosVendidos = new List<ProdutoVendaResponseItem>();

        //buscar produto
        //decrementar
        //post
        foreach (var item in request.VendaRequest.ProdutosVendidos)
        {
            var produtoEstoque = await _produtoEstoqueRepository.GetById(request.VendaRequest.LojaId, item.ProdutoId);
            if (produtoEstoque == null)
            {
                return new RegistrarVendaResponse(false, $"Produto {item.ProdutoId} não encontrado na loja especificada.");
            }

            if (produtoEstoque.Estoque < item.Quantidade)
            {
                return new RegistrarVendaResponse(false, "estoque insuficiente.");
            }

            produtoEstoque.AlterarQuantidade(produtoEstoque.Estoque - item.Quantidade);
            await _produtoEstoqueRepository.AtualizarQuantidadeEstoque(request.VendaRequest.LojaId, item.ProdutoId, produtoEstoque.Estoque);

            var vendaProduto = new VendaProduto(venda.Id, item.ProdutoId, produtoEstoque.Produto, item.Quantidade);
            await _vendaProdutoRepository.Create(vendaProduto);

            produtosVendidos.Add(new ProdutoVendaResponseItem
            {
                ProdutoId = item.ProdutoId,
                Quantidade = item.Quantidade
            });
        }

        return new RegistrarVendaResponse(true, "Venda registrada com sucesso.", venda.Id, produtosVendidos);
    }
}
