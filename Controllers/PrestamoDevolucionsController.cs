using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> Index(int pageNumber = 1)
        {

            int pageSize = 10;
            int currentPage = pageNumber;

            var prestamos = _context.PrestamoDevolucions
            .Include(p => p.EmpleadoNavigation)
            .Include(p => p.LibroNavigation)
            .Include(p => p.UsuarioNavigation).AsQueryable();

            var prestamos_view = PaginatedList<PrestamoDevolucion>.Create(prestamos, currentPage, pageSize);

            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Descripcion");
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Descripcion");

            var prestamoDevolucionModel =  new PrestamoDevolucionSearchViewModel() {
                prestamoDevolucions = prestamos_view,
            };

            return View(prestamoDevolucionModel);

        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(PrestamoDevolucionSearchViewModel searchModel, int pageNumber = 1)
    {
        var query =  _context.PrestamoDevolucions
            .Include(p => p.EmpleadoNavigation)
            .Include(p => p.LibroNavigation)
            .Include(p => p.UsuarioNavigation).AsQueryable();

        if (searchModel.FechaInicioPrestamo.HasValue)
        {
            query = query.Where(p => p.FechaPrestamo >= DateOnly.FromDateTime(searchModel.FechaInicioPrestamo.Value));
        }

        if (searchModel.FechaFinPrestamo.HasValue)
        {
            query = query.Where(p => p.FechaPrestamo <= DateOnly.FromDateTime(searchModel.FechaFinPrestamo.Value));
        }

        if (searchModel.FechaInicioDevolucion.HasValue)
        {
            query = query.Where(p => p.FechaDevolucion >= DateOnly.FromDateTime(searchModel.FechaInicioDevolucion.Value));
        }

        if (searchModel.FechaFinDevolucion.HasValue)
        {
            query = query.Where(p => p.FechaDevolucion <= DateOnly.FromDateTime(searchModel.FechaFinDevolucion.Value));
        }

        if (searchModel.TipoBibliografia.HasValue)
        {
            query = query.Where(p => p.LibroNavigation.TipoBibliografia == searchModel.TipoBibliografia);
        }

        if (searchModel.Idioma.HasValue)
        {
            query = query.Where(p => p.LibroNavigation.Idioma == searchModel.Idioma);
        }

        searchModel.prestamoDevolucions = PaginatedList<PrestamoDevolucion>.Create(query, pageNumber, 10);



            ViewData["Idioma"] = new SelectList(_context.Idiomas, "Identificador", "Descripcion");
            ViewData["TipoBibliografia"] = new SelectList(_context.TiposBibliografia, "Identificador", "Descripcion");

        return View(searchModel);
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
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Nombre");
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Descripcion");
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Nombre");
            return View();
        }

        // POST: PrestamoDevolucions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoPrestamo,Libro,Usuario,FechaPrestamo,FechaDevolucion,MontoXdia,CantidadDias,Comentario,Estado")] PrestamoDevolucion prestamoDevolucion)
        {
            prestamoDevolucion.Empleado = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value);
            prestamoDevolucion.FechaPrestamo = DateOnly.FromDateTime(DateTime.Now);

            if(prestamoDevolucion.Empleado == null) 
            {
                ModelState.AddModelError(string.Empty, "Por favor, volver a loguearse el ID del usuario no esta disponible");
            }

            if (ModelState.IsValid)
            {
                _context.Add(prestamoDevolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Nombre", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Descripcion", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Nombre", prestamoDevolucion.Usuario);
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
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Nombre", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Descripcion", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Nombre", prestamoDevolucion.Usuario);
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
            
            ViewData["Empleado"] = new SelectList(_context.Empleados, "Identificador", "Nombre", prestamoDevolucion.Empleado);
            ViewData["Libro"] = new SelectList(_context.Libros, "Identificador", "Descripcion", prestamoDevolucion.Libro);
            ViewData["Usuario"] = new SelectList(_context.Usuarios, "Identificador", "Nombre", prestamoDevolucion.Usuario);
            
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
                prestamoDevolucion.Estado = true;
                prestamoDevolucion.FechaDevolucion = DateOnly.FromDateTime(DateTime.Now);
                _context.PrestamoDevolucions.Update(prestamoDevolucion);
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
