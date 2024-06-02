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

    [Required(ErrorMessage = "Este mensaje es obligatorio")]
    [Display(Name = "Descripción", Prompt = "Ingrese el descripción")]
    [StringLength(255)]
    public required string Descripcion { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("IdiomaNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
