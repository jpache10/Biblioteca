using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers;

[Authorize(Roles = "Administrador,Usuario")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SqlDatabaseBibliotecaContext _context;

    public HomeController(ILogger<HomeController> logger, SqlDatabaseBibliotecaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {

        var DashboardViewModel = new DashboardViewModel()
        {
            Cards = new List<DashBoardCard>() {
                new DashBoardCard () {
                Title = "Tipo de bibliografía",
                Description="Permite organizar la información consultada",
                estadistica = new Dictionary<string, int>
                {
                        { "Cantidad de registros", _context.TiposBibliografia.Count() },
                },
                },
                new DashBoardCard () {
                Title = "Editoras",
                Description="Contempla la edición de libros como un conjunto",
                estadistica = new Dictionary<string, int>
                {
                        { "Cantidad de registros", _context.Editoras.Count() },
                },
            },
                    new DashBoardCard () {
            Title = "Autores",
            Description = "Información sobre los autores de las publicaciones",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Autores.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Ciencias",
            Description = "Categorías de ciencias a las que pertenecen las publicaciones",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Ciencias.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Empleados",
            Description = "Información sobre los empleados de la biblioteca",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Empleados.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Idiomas",
            Description = "Idiomas en los que están disponibles las publicaciones",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Idiomas.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Libros",
            Description = "Listado de libros disponibles en la biblioteca",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Libros.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Préstamos y Devoluciones",
            Description = "Registros de préstamos y devoluciones de libros",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.PrestamoDevolucions.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Usuario",
            Description = "Información sobre los usuarios registrados",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.Usuarios.Count() }
            }
        },
        new DashBoardCard () {
            Title = "Usuarios Empleados",
            Description = "Información sobre empleados que manejan el sistema",
            estadistica = new Dictionary<string, int>
            {
                { "Cantidad de registros", _context.UsuariosEmpleado.Count() }
            }
        }
        }
        };

        return View(DashboardViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
