using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MAContabilidade.Models;
using MAContabilidade.Data;

namespace MAContabilidade.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var servicos = _context.Servicos.ToList();
        return View(servicos);
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Obrigada()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
