using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Editora
{
    [Key]
    public int Identificador { get; set; }


    [Display(Name = "Descripción", Prompt = "Ingrese la descripción")]
    [StringLength(255, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public required string Descripcion { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("EditoraNavigation")]
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
