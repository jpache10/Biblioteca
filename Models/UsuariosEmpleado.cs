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
    [Display(Name = "Nombre de usuario", Prompt = "Ingrese el Nombre de usuario")]
    public required string Name { get; set; }


    [StringLength(200, ErrorMessage = "La cantidad maxima de caracteres es {1} y minimo 5", MinimumLength = 5)]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Contraseña", Prompt = "Ingrese la Contraseña")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    
    [StringLength(45, ErrorMessage = "La cantidad maxima de caracteres es {1}")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public required string Rol { get; set; }

    public required DateTime FechaCreacion { get; set; }
    
    public DateTime FechaUltimoInicioSesion { get; set; }

    public bool RestablecerPassword { get; set; }

    public bool Estado { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Empleado")]
    public required int Empleado { get; set; }

    [ForeignKey("Empleado")]
    [Display(Name = "Empleado")]
    [InverseProperty("UsuariosEmpleados")]
    public virtual Empleado? EmpleadoNavigation { get; set; }


}
