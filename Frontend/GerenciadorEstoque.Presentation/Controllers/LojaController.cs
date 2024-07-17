using GerenciadorEstoque.Presentation.Models;
using GerenciadorEstoque.Presentation.Services.LojaServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Presentation.Controllers;

public class LojaController : Controller
{
    private readonly ILojaService _lojaService;
    private readonly ILogger<LojaController> _logger;

    public LojaController(ILojaService lojaService, ILogger<LojaController> logger)
    {
        _lojaService = lojaService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var lojas = await _lojaService.GetAllLojasAsync();
        if (lojas == null || !lojas.Any())
        {
            _logger.LogWarning("Erro interno: nenhuma loja foi encontrada.");
            lojas = new List<LojaViewModel>();
        }
        return View(lojas);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var loja = await _lojaService.GetLojaByIdAsync(id);
        if (loja == null) return NotFound();

        return View(loja);
    }
}
