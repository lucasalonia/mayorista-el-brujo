using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mayorista_el_brujo.Models;

namespace mayorista_el_brujo.Controllers;

// [Authorize(Policy = "AdminOnly")]
public class UsuarioController : Controller
{


    public UsuarioController()
    {

    }

    public IActionResult Index(int pageIndex = 1)
    {
        return View();
    }

}
