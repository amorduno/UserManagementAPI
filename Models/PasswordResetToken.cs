using System;

namespace UserManagementAPI.Models
{
    public class PasswordResetToken
    {
        public int Id { get; set; } // Identificador único del token
        public Guid UserId { get; set; } // Clave foránea para el usuario
        public User User { get; set; } // Propiedad de navegación hacia User
        public string Token { get; set; } // Token generado para restablecer la contraseña
        public DateTime ExpiresAt { get; set; } // Fecha de expiración del token
        public DateTime? UsedAt { get; set; } // Fecha en que el token fue utilizado
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Fecha de creación del token
    }
}
