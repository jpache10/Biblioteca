using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class Libro
{
    [Key]
    public int Identificador { get; set; }

    [Display(Name = "Nombre del libro", Prompt = "Ingrese el nombre del libro")]
    [StringLength(255, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    [Display(Name = "Signatura topográfica", Prompt = "Ingrese el Signatura topográfica")]
    public string? SignaturaTopografica { get; set; }

    [Column("ISBN")]
    [StringLength(20, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "ISBN", Prompt = "Ingrese el ISBN")]
    public string? Isbn { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Tipo de bibliografía", Prompt = "Ingrese el tipo de bibliografía")]
    public int? TipoBibliografia { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Autor", Prompt = "Ingrese el Autor")]
    public int? Autores { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Editora", Prompt = "Ingrese la Editora")]
    public int? Editora { get; set; }

    [Display(Name = "Año de publicación", Prompt = "Ingrese el Año de publicación")]
    public int? AnioPublicacion { get; set; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Ciencia", Prompt = "Ingrese la Ciencia")]
    public int? Ciencia { get; set; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Idioma", Prompt = "Ingrese el Idioma")]
    public int? Idioma { get; set; }

    public bool Estado { get; set; }

    [ForeignKey("Autores")]
    [Display(Name = "Autor")]
    [InverseProperty("Libros")]
    public virtual Autore? AutoresNavigation { get; set; }

    [ForeignKey("Ciencia")]
    [Display(Name = "Ciencia")]
    [InverseProperty("Libros")]
    public virtual Ciencia? CienciaNavigation { get; set; }

    [ForeignKey("Editora")]
    [Display(Name = "Editora")]
    [InverseProperty("Libros")]
    public virtual Editora? EditoraNavigation { get; set; }

    [ForeignKey("Idioma")]
    [Display(Name = "Idioma")]
    [InverseProperty("Libros")]
    public virtual Idioma? IdiomaNavigation { get; set; }

    [InverseProperty("LibroNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();

    [ForeignKey("TipoBibliografia")]
    [InverseProperty("Libros")]
    public virtual TiposBibliografium? TipoBibliografiaNavigation { get; set; }
}
