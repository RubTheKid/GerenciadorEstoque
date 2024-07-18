using GerenciadorEstoque.Presentation.Models;
using GerenciadorEstoque.Presentation.Services.EstoqueServices;
using GerenciadorEstoque.Presentation.Services.LojaServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Presentation.Controllers;

public class LojasController : Controller
{
    private readonly ILojaService _lojaService;
    private readonly IEstoqueService _estoqueService;
    private readonly ILogger<LojasController> _logger;

    public LojasController(ILojaService lojaService, ILogger<LojasController> logger, IEstoqueService estoqueService)
    {
        _lojaService = lojaService;
        _logger = logger;
        _estoqueService = estoqueService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var lojas = await _lojaService.GetAllLojasAsync();
        if (lojas == null || !lojas.Any())
        {
            lojas = new List<LojaViewModel>();
        }
        return View(lojas);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var loja = await _lojaService.GetLojaByIdAsync(id);
        if (loja == null)
        {
            return NotFound();
        }

        var estoque = await _estoqueService.GetEstoqueByLojaId(id);
        var model = new LojaDetalhesViewModel
        {
            Loja = loja,
            Estoque = estoque
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var loja = await _lojaService.GetLojaByIdAsync(id);

        if (loja == null)
        {
            return NotFound();
        }

        return View(loja);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, LojaViewModel loja)
    {
        if (id != loja.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var updatedLoja = await _lojaService.UpdateLojaAsync(loja);

            if (updatedLoja != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
        return View(loja);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(LojaViewModel loja)
    {
        if (ModelState.IsValid)
        {
            await _lojaService.AddLojaAsync(loja);
            return RedirectToAction(nameof(Index));
        }
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var error in errors)
        {

            Console.WriteLine(error.ErrorMessage);
        }

        return View(loja);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _lojaService.RemoveLojaAsync(id);
        if (result)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}