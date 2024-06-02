using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Autore
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? PaisOrigen { get; set; }

    [StringLength(100)]
    public string? IdiomaNativo { get; set; }

public bool Estado { get; set; }

    [InverseProperty("AutoresNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
