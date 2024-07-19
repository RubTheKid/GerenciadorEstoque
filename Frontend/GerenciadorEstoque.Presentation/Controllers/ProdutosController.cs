using GerenciadorEstoque.Presentation.Models;
using GerenciadorEstoque.Presentation.Services.EstoqueServices;
using GerenciadorEstoque.Presentation.Services.ProdutoServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Presentation.Controllers;

public class ProdutosController : Controller
{
    private readonly IProdutoService _produtoService;
    private readonly IEstoqueService _estoqueService;

    public ProdutosController(IProdutoService produtoService, IEstoqueService estoqueService)
    {
        _produtoService = produtoService;
        _estoqueService = estoqueService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoService.GetAllProdutos();
        if (produtos == null || !produtos.Any())
        {
            produtos = new List<ProdutoViewModel>();
        }
        return View(produtos);
    }


    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var produto = await _produtoService.GetProdutoById(id);
        if (produto == null)
        {
            return NotFound();
        }

        var estoque = await _estoqueService.GetEstoqueByProdutoId(id);
        var model = new ProdutoDetalhesViewModel
        {
            Produto = produto,
            Estoque = estoque
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var produto = await _produtoService.GetProdutoById(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produto)
    {
        if (id != produto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var updatedProduto = await _produtoService.UpdateProduto(produto);

            if (updatedProduto != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
        return View(produto);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProdutoViewModel produto)
    {
        if (ModelState.IsValid)
        {
            await _produtoService.CreateProduto(produto);
            return RedirectToAction(nameof(Index));
        }

        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _produtoService.DeleteProduto(id);
        if (result)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }



}
