using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Usuario
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Cedula { get; set; }

    [StringLength(20)]
    public string? NoCarnet { get; set; }

    [StringLength(50)]
    public string? TipoPersona { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [InverseProperty("UsuarioNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();
}
