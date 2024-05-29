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

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Cedula { get; set; }

    [StringLength(50)]
    public string? TandaLabor { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? PorcientoComision { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [InverseProperty("EmpleadoNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();
}
