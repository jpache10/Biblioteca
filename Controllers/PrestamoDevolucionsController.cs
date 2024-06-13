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
    public class PrestamoDevolucionsController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public PrestamoDevolucionsController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: PrestamoDevolucions
        public async Task<IActionResult> Index()
        {
            var sqlDatabaseBibliotecaContext = _context.PrestamoDevolucions.Include(p => p.EmpleadoNavigation).Include(p => p.LibroNavigation).Include(p => p.UsuarioNavigation);
            return View(await sqlDatabaseBibliotecaContext.ToListAsync());
        }

        // GET: PrestamoDevolucions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDevolucion = await _context.PrestamoDevolucions
                .Include(p => p.EmpleadoNavigation)
                .Include(p => p.LibroNavigation)
                .Include(p => p.UsuarioNavigation)
                .FirstOrDefaultAsync(m => m.NoPrestamo == id);
            if (prestamoDevolucion == null)
            {
                return NotFound();
            }

            return View(prestamoDevolucion);
        }

        // GET: PrestamoDevolucions/Create
        public IActionResult Create()
        {
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador");
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Identificador");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Identificador");
            return View();
        }

        // POST: PrestamoDevolucions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoPrestamo,Empleado,Libro,Usuario,FechaPrestamo,FechaDevolucion,MontoXdia,CantidadDias,Comentario,Estado")] PrestamoDevolucion prestamoDevolucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamoDevolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Identificador", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Identificador", prestamoDevolucion.Usuario);
            return View(prestamoDevolucion);
        }

        // GET: PrestamoDevolucions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDevolucion = await _context.PrestamoDevolucions.FindAsync(id);
            if (prestamoDevolucion == null)
            {
                return NotFound();
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Identificador", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Identificador", prestamoDevolucion.Usuario);
            return View(prestamoDevolucion);
        }

        // POST: PrestamoDevolucions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoPrestamo,Empleado,Libro,Usuario,FechaPrestamo,FechaDevolucion,MontoXdia,CantidadDias,Comentario,Estado")] PrestamoDevolucion prestamoDevolucion)
        {
            if (id != prestamoDevolucion.NoPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamoDevolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoDevolucionExists(prestamoDevolucion.NoPrestamo))
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
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Identificador", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Identificador", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Identificador", prestamoDevolucion.Usuario);
            return View(prestamoDevolucion);
        }

        // GET: PrestamoDevolucions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamoDevolucion = await _context.PrestamoDevolucions
                .Include(p => p.EmpleadoNavigation)
                .Include(p => p.LibroNavigation)
                .Include(p => p.UsuarioNavigation)
                .FirstOrDefaultAsync(m => m.NoPrestamo == id);
            if (prestamoDevolucion == null)
            {
                return NotFound();
            }

            return View(prestamoDevolucion);
        }

        // POST: PrestamoDevolucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamoDevolucion = await _context.PrestamoDevolucions.FindAsync(id);
            if (prestamoDevolucion != null)
            {
                _context.PrestamoDevolucions.Remove(prestamoDevolucion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoDevolucionExists(int id)
        {
            return _context.PrestamoDevolucions.Any(e => e.NoPrestamo == id);
        }
    }
}
