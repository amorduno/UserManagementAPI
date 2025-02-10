using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

public class AuthService : IAuthService
{
    private readonly string _jwtSecret;

    public AuthService(IConfiguration configuration)
    {
        _jwtSecret = configuration["JwtSettings:SecretKey"];

        if (string.IsNullOrEmpty(_jwtSecret) || _jwtSecret.Length < 32)
        {
            throw new InvalidOperationException("La clave secreta JWT debe tener al menos 32 caracteres.");
        }
    }

    public string HashPassword(string password)
    {
        Console.WriteLine("Iniciando proceso de hashing...");
        try
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10); // Ajusta el coste de trabajo
            Console.WriteLine("Hashing completado.");
            return hashedPassword;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al hashear la contraseña: {ex.Message}");
            throw; // Relanza la excepción para depuración
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret); // Convierte la clave a bytes

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}