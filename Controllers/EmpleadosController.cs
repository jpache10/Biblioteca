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
    public class EmpleadosController : Controller
    {
        private readonly SqlDatabaseBibliotecaContext _context;

        public EmpleadosController(SqlDatabaseBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {

            int pageSize = 10;
            int currentPage = pageNumber ?? 1;

            var empleados = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(l =>
                    l.Nombre.ToLower().Contains(searchString.ToLower()) ||
                    l.Cedula.ToLower().Contains(searchString.ToLower()) ||
                    l.TandaLabor.ToLower().Contains(searchString.ToLower()) ||
                    l.PorcientoComision.ToString().ToLower().Contains(searchString.ToLower()) ||
                    (l.Estado ? "activo" : "inactivo").Contains(searchString.ToLower())
                );
            }

            var empleados_view = PaginatedList<Empleado>.Create(empleados, currentPage, pageSize);

            ViewData["CurrentFilter"] = searchString;

            return View(empleados_view);

        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewBag.TandaLaboral = new SelectList(new List<string> () {"Turno de mañana","Turno de tarde", "Turno de noche"});
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Nombre,Cedula,TandaLabor,PorcientoComision,FechaIngreso,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TandaLaboral = new SelectList(new List<string> () {"Turno de mañana","Turno de tarde", "Turno de noche"});
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            ViewBag.TandaLaboral = new SelectList(new List<string> () {"Turno de mañana","Turno de tarde", "Turno de noche"});
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Nombre,Cedula,TandaLabor,PorcientoComision,FechaIngreso,Estado")] Empleado empleado)
        {
            if (id != empleado.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Identificador))
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
            
            ViewBag.TandaLaboral = new SelectList(new List<string> () {"Turno de mañana","Turno de tarde", "Turno de noche"});
            
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Identificador == id);
        }
    }
}
