using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class IdiomasController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public IdiomasController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Idiomas
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var idiomas = _context.Idiomas.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                idiomas = idiomas.Where(l =>
                    l.Descripcion.ToLower().Contains(searchString.ToLower())
                );
            }

            var idiomas_view = PaginatedList<Idioma>.Create(idiomas, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(idiomas_view);

        }

        // GET: Idiomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // GET: Idiomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Idiomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Descripcion,Estado")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                idioma.Estado = true;
                _context.Add(idioma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idioma);
        }

        // GET: Idiomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }
            return View(idioma);
        }

        // POST: Idiomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Descripcion,Estado")] Idioma idioma)
        {
            if (id != idioma.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idioma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaExists(idioma.Identificador))
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
            return View(idioma);
        }

        // GET: Idiomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idioma = await _context.Idiomas
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (idioma == null)
            {
                return NotFound();
            }

            return View(idioma);
        }

        // POST: Idiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma != null)
            {
                _context.Idiomas.Remove(idioma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaExists(int id)
        {
            return _context.Idiomas.Any(e => e.Identificador == id);
        }
    }
}
