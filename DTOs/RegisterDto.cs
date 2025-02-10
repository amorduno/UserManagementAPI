using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Attributes;

namespace UserManagementAPI.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [StrongPassword(ErrorMessage = "La contraseña no cumple con los requisitos de seguridad.")]
        public string Password { get; set; }
    }
}
