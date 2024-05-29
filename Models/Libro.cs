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

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    public string? SignaturaTopografica { get; set; }

    [Column("ISBN")]
    [StringLength(20)]
    public string? Isbn { get; set; }

    public int? TipoBibliografia { get; set; }

    public int? Autores { get; set; }

    public int? Editora { get; set; }

    public int? AnioPublicacion { get; set; }

    public int? Ciencia { get; set; }

    public int? Idioma { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

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
