using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mayorista_el_brujo.Models;

namespace mayorista_el_brujo.Controllers;

public class UsuarioController : Controller
{


    public UsuarioController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }

}
