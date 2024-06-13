using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class TiposBibliografiumController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public TiposBibliografiumController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: TiposBibliografium
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var tiposBibliografia = _context.TiposBibliografia.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                tiposBibliografia = tiposBibliografia.Where(l =>
                    l.Descripcion.ToLower().Contains(searchString.ToLower()) || 
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var bibliografias = PaginatedList<TiposBibliografium>.Create(tiposBibliografia, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(bibliografias);

        }

        // GET: TiposBibliografium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBibliografium = await _context.TiposBibliografia
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (tiposBibliografium == null)
            {
                return NotFound();
            }

            return View(tiposBibliografium);
        }

        // GET: TiposBibliografium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposBibliografium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Descripcion,Estado")] TiposBibliografium tiposBibliografium)
        {
            if (ModelState.IsValid)
            {
                tiposBibliografium.Estado = true;
                _context.Add(tiposBibliografium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposBibliografium);
        }

        // GET: TiposBibliografium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBibliografium = await _context.TiposBibliografia.FindAsync(id);
            if (tiposBibliografium == null)
            {
                return NotFound();
            }
            return View(tiposBibliografium);
        }

        // POST: TiposBibliografium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Descripcion,Estado")] TiposBibliografium tiposBibliografium)
        {
            if (id != tiposBibliografium.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposBibliografium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposBibliografiumExists(tiposBibliografium.Identificador))
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
            return View(tiposBibliografium);
        }

        // GET: TiposBibliografium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBibliografium = await _context.TiposBibliografia
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (tiposBibliografium == null)
            {
                return NotFound();
            }

            return View(tiposBibliografium);
        }

        // POST: TiposBibliografium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposBibliografium = await _context.TiposBibliografia.FindAsync(id);
            if (tiposBibliografium != null)
            {
                _context.TiposBibliografia.Remove(tiposBibliografium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposBibliografiumExists(int id)
        {
            return _context.TiposBibliografia.Any(e => e.Identificador == id);
        }
    }
}
