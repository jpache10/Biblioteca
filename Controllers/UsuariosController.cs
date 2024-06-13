using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Biblioteca.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public UsuariosController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var usuarios = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(l =>
                    l.Nombre.ToLower().Contains(searchString.ToLower()) ||
                    l.Cedula.ToLower().Contains(searchString.ToLower()) ||
                    l.NoCarnet.ToLower().Contains(searchString.ToLower()) ||
                    l.TipoPersona.ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var usuarios_view = PaginatedList<Usuario>.Create(usuarios, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(usuarios_view);

        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewBag.TipoUser = new SelectList(new List<string> () {"Física", "Jurídica"});
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre,Cedula,NoCarnet,TipoPersona,Estado")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                usuario.NoCarnet = NoCarnetUser.GenerarCode();
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.TipoUser = new SelectList(new List<string> () {"Física", "Jurídica"});
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Nombre,Cedula,NoCarnet,TipoPersona,Estado")] Usuario usuario)
        {
            if (id != usuario.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Identificador))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.TipoUser = new SelectList(new List<string> () {"Física", "Jurídica"});
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Identificador == id);
        }
    }
}
