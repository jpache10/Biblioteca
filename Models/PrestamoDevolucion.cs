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
    public int NoPrestamo { get; set; }

    [Display(Name ="Empleados")]
    public int? Empleado { get; set; }
    [Display(Name ="Libro")]
    public int? Libro { get; set; }
    [Display(Name ="Usuarios")]
    public int? Usuario { get; set; }

    public DateOnly? FechaPrestamo { get; set; }

    public DateOnly? FechaDevolucion { get; set; }

    [Column("MontoXDia", TypeName = "decimal(10, 2)")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public decimal? MontoXdia { get; set; }

    public int? CantidadDias { get; set; }

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
