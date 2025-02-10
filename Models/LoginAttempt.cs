using System;

namespace UserManagementAPI.Models
{
    public class LoginAttempt
    {
        public int Id { get; set; } // Identificador único del intento
        public Guid? UserId { get; set; } // Referencia al usuario (NULL si el email no existe)
        public string Email { get; set; } // Correo electrónico utilizado en el intento
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow; // Fecha y hora del intento
        public bool IsSuccessful { get; set; } // Indica si el intento fue exitoso
        public string IpAddress { get; set; } // Dirección IP desde la que se realizó el intento
        public string DeviceInfo { get; set; } // Información del dispositivo (opcional)
    }
}
