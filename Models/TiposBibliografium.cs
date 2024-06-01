using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class TiposBibliografium
{
    [Key]
    public int Identificador { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Descripción", Prompt = "Ingrese la descripción")]
    [StringLength(255)]
    public required string Descripcion { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("TipoBibliografiaNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
