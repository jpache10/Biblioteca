using System.ComponentModel.DataAnnotations;

public class LoginModel
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [Display(Name = "Usuario", Prompt = "Introduzca el usuario")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [Display(Name = "Contraseña", Prompt = "Introduzca la contraseña")]
    public string? Password { get; set; }
}