using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Empleado
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(100, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Nombre", Prompt = "Ingrese la Nombre")]
    public string? Nombre { get; set; }

    [StringLength(20, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Cédula", Prompt = "Ingrese la Cédula")]
    public string? Cedula { get; set; }

    [StringLength(50, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Tanda laboral", Prompt = "Ingrese la Tanda laboral")]
    public string? TandaLabor { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Porciento de Comisión (0.00)", Prompt = "Ingrese la Comisión 0.10")]
    public decimal? PorcientoComision { get; set; }

    [Display(Name = "Fecha de ingreso", Prompt = "Seleccionar fecha de ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("EmpleadoNavigation")]
    public virtual ICollection<UsuariosEmpleado> UsuariosEmpleados { get; set; } = new List<UsuariosEmpleado>();

    [InverseProperty("EmpleadoNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();
}
