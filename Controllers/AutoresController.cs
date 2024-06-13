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

namespace Biblioteca.Controllers
{
   
    [Authorize(Roles = "Administrador,Usuario")]
    public class AutoresController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public AutoresController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var autores = _context.Autores.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                autores = autores.Where(l =>
                    l.Nombre.ToLower().Contains(searchString.ToLower()) ||
                    l.PaisOrigen.ToLower().Contains(searchString.ToLower()) ||
                    l.IdiomaNativo.ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var autores_view = PaginatedList<Autore>.Create(autores, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(autores_view);

        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            var paises = ListadoPaises.GetPaises();
            var idiomas = _context.Idiomas.Where(x => x.Estado == true).Select(x => x.Descripcion).ToList();
            ViewBag.Paises = new SelectList(paises);
            ViewBag.Idiomas = new SelectList(idiomas);

            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre,PaisOrigen,IdiomaNativo,Estado")] Autore autore)
        {

            var paises = ListadoPaises.GetPaises();
            var idiomas = _context.Idiomas.Where(x => x.Estado == true).Select(x => x.Descripcion).ToList();

            if (ModelState.IsValid)
            {
                if (AutorNameExists(autore.Nombre))
                {
                    ModelState.AddModelError("Nombre", "Ya existe un autor con este nombre.");
                    
                    ViewBag.Paises = new SelectList(paises);
                    ViewBag.Idiomas = new SelectList(idiomas);
                    return View(autore);
                }

                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

          
            ViewBag.Paises = new SelectList(paises);
            ViewBag.Idiomas = new SelectList(idiomas);

            return View(autore);
            
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }

            var paises = ListadoPaises.GetPaises();
            var idiomas = _context.Idiomas.Where(x => x.Estado == true).Select(x => x.Descripcion).ToList();
            ViewBag.Paises = new SelectList(paises);
            ViewBag.Idiomas = new SelectList(idiomas);

            return View(autore);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Nombre,PaisOrigen,IdiomaNativo,Estado")] Autore autore)
        {
            if (id != autore.Identificador)
            {
                return NotFound();
            }

            var paises = ListadoPaises.GetPaises();
            var idiomas = _context.Idiomas.Where(x => x.Estado == true).Select(x => x.Descripcion).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(autore);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoreExists(autore.Identificador))
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
            
           
            ViewBag.Paises = new SelectList(paises);
            ViewBag.Idiomas = new SelectList(idiomas);

            return View(autore);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autore = await _context.Autores.FindAsync(id);
            if (autore != null)
            {
                _context.Autores.Remove(autore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoreExists(int id)
        {
            return _context.Autores.Any(e => e.Identificador == id);
        }

        private bool AutorNameExists(string name)
        {
            return _context.Autores.Any(e => e.Nombre == name);
        }
    }
}
