using System;

namespace UserManagementAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public string? RefreshToken { get; set; } // Permite valores NULL
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}