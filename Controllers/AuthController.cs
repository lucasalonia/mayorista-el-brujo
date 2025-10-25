// using mayorista_el_brujo.Models;
// using mayorista_el_brujo.Services;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.ComponentModel.DataAnnotations;
// using System.Security.Claims;


// namespace mayorista_el_brujo.Controllers
// {
//     public class AuthController : Controller
//     {
//         private readonly AuthServiceImpl _authServiceImpl;

//         public AuthController(AuthServiceImpl authServiceImpl)
//         {
//             _authServiceImpl = authServiceImpl;
//         }

//         [AllowAnonymous]
//         public IActionResult Login(string? returnUrl = null)
//         {
//             ViewBag.ReturnUrl = returnUrl;
//             return View();
//         }

//         [HttpPost]
//         [AllowAnonymous]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
//         {
//             if (!ModelState.IsValid)
//             {
//                 ViewBag.ReturnUrl = returnUrl;
//                 return View(model);
//             }

//             var usuario = await _repositorioUsuario.ValidarUsuarioAsync(model.Username, model.Password);
//             if (usuario == null)
//             {
//                 ModelState.AddModelError("", "Usuario o contraseña incorrectos");
//                 ViewBag.ReturnUrl = returnUrl;
//                 return View(model);
//             }

//             var claims = new List<Claim>
//             {
//                 new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
//                 new Claim(ClaimTypes.Name, usuario.NombreUsuario),
//                 new Claim(ClaimTypes.Role, usuario.Rol.ToString())// admin o empleado
//             };

//             var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//             await HttpContext.SignInAsync(
//                 CookieAuthenticationDefaults.AuthenticationScheme,
//                 new ClaimsPrincipal(claimsIdentity),
//                 new AuthenticationProperties
//                 {
//                     IsPersistent = model.RememberMe,
//                     ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(8)
//                 });

//             if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
//                 return Redirect(returnUrl);

//             return RedirectToAction("Index", "Home");
//         }

//         [Authorize]
//         public async Task<IActionResult> Logout()
//         {
//             await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//             return RedirectToAction("Login");
//         }
//     }

//     public class LoginViewModel
//     {
//         public string Username { get; set; } = "";
//         public string Password { get; set; } = "";
//         public bool RememberMe { get; set; }
//     }
// }
