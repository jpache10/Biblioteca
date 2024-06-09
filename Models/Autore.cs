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
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Nombre", Prompt = "Ingrese el Nombre")]
    public string? Nombre { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "País", Prompt = "Ingrese el País")]
    public string? PaisOrigen { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Idioma nativo", Prompt = "Ingrese el idioma nativo")]
    public string? IdiomaNativo { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("AutoresNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
