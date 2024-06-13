using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Biblioteca.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Biblioteca.Extensions;

namespace Biblioteca.Controllers
{
    public class AccountController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public AccountController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

    // [Route("/login")]
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    // [Route("/login")]
    public async Task<IActionResult> Login([Bind("Username,Password")] LoginModel loginModel)
    {

        if (!ModelState.IsValid)
        {
            return View(loginModel);
        }


        var usuario = await _context.UsuariosEmpleado.Where(x => x.Name == loginModel.Username && x.Password == loginModel.Password.Sha256()).FirstOrDefaultAsync();


        // Aquí iría tu lógica de autenticación, por ejemplo:
        if (usuario != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Name),
                new Claim(ClaimTypes.Role, usuario.Rol),
                new Claim(ClaimTypes.PrimarySid, usuario.Identificador.ToString()),
                new Claim(ClaimTypes.Sid, usuario.Empleado.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                // Configuración adicional si es necesario
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

         ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
        return View();
    }

    [AllowAnonymous]
    [Route("/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
      
    }

