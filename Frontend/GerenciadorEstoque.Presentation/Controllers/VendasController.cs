using GerenciadorEstoque.Presentation.Models;
using GerenciadorEstoque.Presentation.Services.EstoqueServices;
using GerenciadorEstoque.Presentation.Services.LojaServices;
using GerenciadorEstoque.Presentation.Services.VendaViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Presentation.Controllers;

public class VendasController : Controller
{
    private readonly IVendaService _vendaService;
    private readonly ILojaService _lojaService;
    private readonly IEstoqueService _estoqueService;

    public VendasController(IVendaService service, ILojaService lojaService, IEstoqueService estoqueService)
    {
        _vendaService = service;
        _lojaService = lojaService;
        _estoqueService = estoqueService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var lojas = await _lojaService.GetAllLojasAsync();
        var model = new RegistrarVendaViewModel
        {
            ProdutosVendidos = new List<ProdutoVendaViewModel>(),
            Lojas = lojas.ToList(),
            Estoque = new List<EstoqueViewModel>()
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutosByLoja(Guid lojaId)
    {
        var estoque = await _estoqueService.GetEstoqueByLojaId(lojaId);
        return PartialView("_ProdutosPartial", estoque.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegistrarVendaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Lojas = (await _lojaService.GetAllLojasAsync()).ToList();
            var estoque = await _estoqueService.GetEstoqueByLojaId(model.LojaId);
            model.Estoque = estoque.ToList();
            return View(model);
        }

        var result = await _vendaService.RegistrarVenda(model);

        if (result)
        {
            return RedirectToAction("Sucesso");
        }

        ModelState.AddModelError(string.Empty, "Erro ao registrar a venda.");
        return View(model);
    }

    [HttpGet]
    public async Task<JsonResult> GetProdutos(Guid lojaId)
    {
        var estoque = await _estoqueService.GetEstoqueByLojaId(lojaId);
        return Json(estoque);
    }
}


