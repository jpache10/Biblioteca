using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Idioma
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [InverseProperty("IdiomaNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
