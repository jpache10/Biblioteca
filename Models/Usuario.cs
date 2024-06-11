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

    [StringLength(100, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Nombre", Prompt = "Ingrese el Nombre")]
    public string? Nombre { get; set; }

    [StringLength(20, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Cédula / RNC", Prompt = "Ingrese la Cédula / RNC")]
    public string? Cedula { get; set; }

    [StringLength(20, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Display(Name = "No. de carnet", Prompt = "Ingrese el No. de carnet")]
    public string? NoCarnet { get; set; }

    [StringLength(50, ErrorMessage = "El número máximo de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Tipo de persona", Prompt = "Ingrese el Tipo de persona")]
    public string? TipoPersona { get; set; }
    public bool Estado { get; set; }

    [InverseProperty("UsuarioNavigation")]
    public virtual ICollection<PrestamoDevolucion> PrestamoDevolucions { get; set; } = new List<PrestamoDevolucion>();
}
