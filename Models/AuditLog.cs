using System;

namespace UserManagementAPI.Models
{
    public class AuditLog
    {
        public int Id { get; set; } // Identificador único del evento
        public Guid? UserId { get; set; } // Referencia al usuario (NULL si no aplica)
        public string EventType { get; set; } // Tipo de evento (e.g., LoginSuccess, LoginFailed, PasswordChanged)
        public string EventDetails { get; set; } // Detalles adicionales del evento
        public string IpAddress { get; set; } // Dirección IP desde la que se realizó el evento
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Fecha y hora del evento
    }
}