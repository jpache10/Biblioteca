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

    public int? Empleado { get; set; }

    public int? Libro { get; set; }

    public int? Usuario { get; set; }

    public DateOnly? FechaPrestamo { get; set; }

    public DateOnly? FechaDevolucion { get; set; }

    [Column("MontoXDia", TypeName = "decimal(10, 2)")]
    public decimal? MontoXdia { get; set; }

    public int? CantidadDias { get; set; }

    [StringLength(255)]
    public string? Comentario { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

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
