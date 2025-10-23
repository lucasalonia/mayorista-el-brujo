using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mayorista_el_brujo.Models;
using mayorista_el_brujo.Repositorios;

namespace mayorista_el_brujo.Controllers;

// [Authorize(Policy = "AdminOnly")]
public class UsuarioController : Controller
{   
    //readonly indica que la variable solo puede ser asignada una vez,
    //  y normalmente se hace en el momento de la declaración o dentro del constructor de la clase.
    private readonly IRepositorioUsuario _repositorioUsuario;

    public UsuarioController( IRepositorioUsuario repositorioUsuario )
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public async Task<IActionResult> Index(int pageIndex = 1)
    {
        
        return View();
    }

    public async Task<IActionResult> ObtenerTodos(int pageIndex = 1)
    {
        //Simular retardo de 2 segundos para probar el cargando del front
        await Task.Delay(500);
        var usuarios = await _repositorioUsuario.ObtenerTodosAsync();
        var resultado = usuarios.Select(u => new
        {
            u.Id,
            Persona = u.Persona,
            u.NombreUsuario,
            Rol = u.Rol.ToString(),
            u.Estado
        });
        return Json(resultado);
    }
    
    public IActionResult Create()
    {
        return View();
    }
}
