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

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre del libro", Prompt = "Ingrese el nombre del libro")]
    [StringLength(255)]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    [Display(Name = "Signatura topográfica", Prompt = "Ingrese el Signatura topográfica")]
    public string? SignaturaTopografica { get; set; }

    [Column("ISBN")]
    [StringLength(20)]
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "ISBN", Prompt = "Ingrese el ISBN")]
    public string? Isbn { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Tipo de bibliografía", Prompt = "Ingrese el tipo de bibliografía")]
    public int? TipoBibliografia { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Autor", Prompt = "Ingrese el Autor")]
    public int? Autores { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Editora", Prompt = "Ingrese la Editora")]
    public int? Editora { get; set; }

    [Display(Name = "Año de publicación", Prompt = "Ingrese el Año de publicación")]
    public int? AnioPublicacion { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Ciencia", Prompt = "Ingrese la Ciencia")]
    public int? Ciencia { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Idioma", Prompt = "Ingrese el Idioma")]
    public int? Idioma { get; set; }

    public bool Estado { get; set; }

    [ForeignKey("Autores")]
    [InverseProperty("Libros")]
    public virtual Autore? AutoresNavigation { get; set; }

    [ForeignKey("Ciencia")]
    [InverseProperty("Libros")]
    public virtual Ciencia? CienciaNavigation { get; set; }

    [ForeignKey("Editora")]
    [InverseProperty("Libros")]
    public virtual Editora? EditoraNavigation { get; set; }

    [ForeignKey("Idioma")]
    [InverseProperty("Libros")]
    public virtual Idioma? IdiomaNavigation { get; set; }

    [InverseProperty("LibroNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();

    [ForeignKey("TipoBibliografia")]
    [InverseProperty("Libros")]
    public virtual TiposBibliografium? TipoBibliografiaNavigation { get; set; }
}
