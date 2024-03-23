using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using prenota.Models;
using prenota_5h.Models;

namespace prenota_5h.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Prenota()
    {
        


        return View();
    }
    public IActionResult Database()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
            return Redirect("\\home\\index");
        Database db = new ();
        db.SaveChanges();
        return View(db);
    }

    [HttpPost]
    public IActionResult Prenotato( Utente u )
    {
        Database db = new ();
        db.Utenti.Add(u);
        db.SaveChanges();
        //settiamo una variabile di sessione chiamata nomeutente con valore u.Nome
        HttpContext.Session.SetString("NomeUtente", u.Nome );
        return View(u);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
