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
    [Display(Name = "Nombre", Prompt = "Ingrese el Nombre")]
    public string? Nombre { get; set; }

    [StringLength(20)]
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Cédula / RNC", Prompt = "Ingrese la Cédula / RNC")]
    public string? Cedula { get; set; }

    [StringLength(20)]
    [Display(Name = "No. de carnet", Prompt = "Ingrese el No. de carnet")]
    public string? NoCarnet { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Tipo de persona", Prompt = "Ingrese el Tipo de persona")]
    public string? TipoPersona { get; set; }
    public bool Estado { get; set; }

    [InverseProperty("UsuarioNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();
}
