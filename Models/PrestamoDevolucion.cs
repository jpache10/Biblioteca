using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

[Table("PrestamoDevolucion")]
public partial class PrestamoDevolucion
{
    [Key]
    [Display(Name ="No. Prestamo")]
    public int NoPrestamo { get; set; }

    [Display(Name ="Empleados")]
    public int? Empleado { get; set; }
    [Display(Name ="Libro")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int? Libro { get; set; }
    [Display(Name ="Usuarios")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public int? Usuario { get; set; }
    [DataType(DataType.Date)]
    [Display(Name ="Fecha del prestamo")]
    public DateOnly? FechaPrestamo { get; set; }
    [DataType(DataType.Date)]
    [Display(Name ="Fecha de devolución")]
    public DateOnly? FechaDevolucion { get; set; }

    [Column("MontoXDia", TypeName = "decimal(10, 2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Por favor, ingresar un número válido")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public decimal? MontoXdia { get; set; } = 0;

    [Range(0, int.MaxValue, ErrorMessage = "Por favor, ingresar un número válido")]
    public int? CantidadDias { get; set; } = 0;

    [StringLength(255)]
    public string? Comentario { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public bool Estado { get; set; }

    [ForeignKey("Empleado")]
    [InverseProperty("PrestamoDevolucions")]
    public virtual Empleado? EmpleadoNavigation { get; set; }

    [ForeignKey("Libro")]
    [InverseProperty("PrestamoDevolucions")]
    public virtual Libro? LibroNavigation { get; set; }

    [ForeignKey("Usuario")]
    [InverseProperty("PrestamoDevolucions")]
    public virtual Usuario? UsuarioNavigation { get; set; }
}
