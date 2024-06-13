using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class UsuariosEmpleado
{
    [Key]
    public int Identificador { get; set; }

    [StringLength(60, ErrorMessage = "La cantidad maxima de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Nombre de usuario", Prompt = "Ingrese el nombre de usuario")]
    public required string Name { get; set; }


    [StringLength(200, ErrorMessage = "La cantidad maxima de caracteres es {1} y minimo 5", MinimumLength = 5)]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Contraseña", Prompt = "Ingrese la Contraseña")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    
    [StringLength(45, ErrorMessage = "La cantidad maxima de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public required string Rol { get; set; }

    [Display(Name = "Fecha de creación")]
    public required DateTime FechaCreacion { get; set; }
    
    [Display(Name = "Última Sesión")]
    public DateTime FechaUltimoInicioSesion { get; set; }

    [Display(Name = "Restablecer clave")]
    public bool RestablecerPassword { get; set; }

    public bool Estado { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Empleado")]
    public required int Empleado { get; set; }

    [ForeignKey("Empleado")]
    [Display(Name = "Empleado")]
    [InverseProperty("UsuariosEmpleados")]
    public virtual Empleado? EmpleadoNavigation { get; set; }


    [NotMapped]
    public string FechaCreacionFormateada => FechaCreacion.ToString("dd/MM/yyyy");

    [NotMapped]
    public string FechaUltimoInicioSesionFormateada => FechaUltimoInicioSesion.ToString("dd/MM/yyyy");

}
