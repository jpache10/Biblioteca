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
    public class LibrosController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public LibrosController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var libros = _context.Libros
            .Include(l => l.AutoresNavigation)
            .Include(l => l.CienciaNavigation)
            .Include(l => l.EditoraNavigation)
            .Include(l => l.IdiomaNavigation)
            .Include(l => l.TipoBibliografiaNavigation).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                libros = libros.Where(l =>
                    (l.AnioPublicacion != null ? l.AnioPublicacion.ToString(): "0").ToLower().Contains(searchString.ToLower()) ||
                    l.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    l.SignaturaTopografica.ToLower().Contains(searchString.ToLower()) ||
                    l.AutoresNavigation.Nombre.ToLower().Contains(searchString.ToLower()) ||
                    l.CienciaNavigation.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    l.IdiomaNavigation.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    l.EditoraNavigation.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    l.TipoBibliografiaNavigation.Descripcion.ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var libros_view = PaginatedList<Libro>.Create(libros, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(libros_view);
           
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutoresNavigation)
                .Include(l => l.CienciaNavigation)
                .Include(l => l.EditoraNavigation)
                .Include(l => l.IdiomaNavigation)
                .Include(l => l.TipoBibliografiaNavigation)
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {

            ViewData["Autores"] = new SelectList(_context.Autores, "Identificador", "Nombre");
            ViewData["Ciencia"] = new SelectList(_context.Ciencias, "Identificador", "Descripcion");
            ViewData["Editora"] = new SelectList(_context.Editoras, "Identificador", "Descripcion");
            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Descripcion");
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Descripcion");

            return View();

        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Descripcion,SignaturaTopografica,Isbn,TipoBibliografia,Autores,Editora,AnioPublicacion,Ciencia,Idioma,Estado")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Autores"] = new SelectList(_context.Autores, "Identificador", "Identificador", libro.Autores);
            ViewData["Ciencia"] = new SelectList(_context.Ciencias, "Identificador", "Identificador", libro.Ciencia);
            ViewData["Editora"] = new SelectList(_context.Editoras, "Identificador", "Identificador", libro.Editora);
            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Identificador", libro.Idioma);
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Identificador", libro.TipoBibliografia);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["Autores"] = new SelectList(_context.Autores, "Identificador", "Identificador", libro.Autores);
            ViewData["Ciencia"] = new SelectList(_context.Ciencias, "Identificador", "Identificador", libro.Ciencia);
            ViewData["Editora"] = new SelectList(_context.Editoras, "Identificador", "Identificador", libro.Editora);
            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Identificador", libro.Idioma);
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Identificador", libro.TipoBibliografia);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Descripcion,SignaturaTopografica,Isbn,TipoBibliografia,Autores,Editora,AnioPublicacion,Ciencia,Idioma,Estado")] Libro libro)
        {
            if (id != libro.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Identificador))
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
            ViewData["Autores"] = new SelectList(_context.Autores, "Identificador", "Identificador", libro.Autores);
            ViewData["Ciencia"] = new SelectList(_context.Ciencias, "Identificador", "Identificador", libro.Ciencia);
            ViewData["Editora"] = new SelectList(_context.Editoras, "Identificador", "Identificador", libro.Editora);
            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Identificador", libro.Idioma);
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Identificador", libro.TipoBibliografia);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutoresNavigation)
                .Include(l => l.CienciaNavigation)
                .Include(l => l.EditoraNavigation)
                .Include(l => l.IdiomaNavigation)
                .Include(l => l.TipoBibliografiaNavigation)
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Identificador == id);
        }
    }
}
