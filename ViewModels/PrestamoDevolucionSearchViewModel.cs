using System.ComponentModel.DataAnnotations;

public class PrestamoDevolucionSearchViewModel
{
    public PrestamoDevolucionSearchViewModel () {

    }


    [DataType(DataType.Date)]
    [Display(Name = "Fecha de inicio del préstamo")]
    public DateTime? FechaInicioPrestamo { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de fin del préstamo")]
    public DateTime? FechaFinPrestamo { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de inicio de la devolución")]
    public DateTime? FechaInicioDevolucion { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de fin de la devolución")]
    public DateTime? FechaFinDevolucion { get; set; }

    [Display(Name = "Tipo de bibliografía", Prompt = "Ingrese el tipo de bibliografia")]
    public int? TipoBibliografia { get; set; }
    
    [Display(Name = "Idioma", Prompt = "Ingrese el Idioma")]
    public int? Idioma { get; set; }

    public virtual PaginatedList<Biblioteca.Models.PrestamoDevolucion> prestamoDevolucions {get; set;}

}