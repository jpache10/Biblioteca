using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class UsuarioAdmin
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(60, ErrorMessage = "La cantidad maxima de caracteres es {1}")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Nombre de usuario", Prompt = "Ingrese el Nombre de usuario")]
    public required string Name { get; set; }

    [StringLength(60, ErrorMessage = "La cantidad maxima de caracteres es {1}")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Contraseña", Prompt = "Ingrese la Contraseña")]
    public required string Password { get; set; }

    public required string Rol { get; set; }

    public bool Estado { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Empleado")]
    public required int Empleado { get; set; }

    [ForeignKey("Empleado")]
    [Display(Name = "Empleado")]
    [InverseProperty("UsuarioAdmins")]
    public virtual Empleado? EmpleadoNavigation { get; set; }


}
