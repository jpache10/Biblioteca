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
    public class CienciasController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public CienciasController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

       // GET: Ciencias
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var ciencias = _context.Ciencias.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                ciencias = ciencias.Where(l =>
                    l.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var ciencias_view = PaginatedList<Ciencia>.Create(ciencias, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(ciencias_view);

        }

        // GET: Ciencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciencia = await _context.Ciencias
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (ciencia == null)
            {
                return NotFound();
            }

            return View(ciencia);
        }

        // GET: Ciencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Descripcion,Estado")] Ciencia ciencia)
        {
            if (ModelState.IsValid)
            {
                ciencia.Estado = true;
                _context.Add(ciencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciencia);
        }

        // GET: Ciencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciencia = await _context.Ciencias.FindAsync(id);
            if (ciencia == null)
            {
                return NotFound();
            }
            return View(ciencia);
        }

        // POST: Ciencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Descripcion,Estado")] Ciencia ciencia)
        {
            if (id != ciencia.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CienciaExists(ciencia.Identificador))
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
            return View(ciencia);
        }

        // GET: Ciencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciencia = await _context.Ciencias
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (ciencia == null)
            {
                return NotFound();
            }

            return View(ciencia);
        }

        // POST: Ciencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciencia = await _context.Ciencias.FindAsync(id);
            if (ciencia != null)
            {
                _context.Ciencias.Remove(ciencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CienciaExists(int id)
        {
            return _context.Ciencias.Any(e => e.Identificador == id);
        }
    }
}
