using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserManagementAPI.Attributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string password)
            {
                // Verifica que la contraseña tenga al menos:
                // - Una letra mayúscula
                // - Una letra minúscula
                // - Un número
                // - Un carácter especial
                var hasUpper = Regex.IsMatch(password, "[A-Z]");
                var hasLower = Regex.IsMatch(password, "[a-z]");
                var hasDigit = Regex.IsMatch(password, "[0-9]");
                var hasSpecial = Regex.IsMatch(password, "[^a-zA-Z0-9]");

                if (hasUpper && hasLower && hasDigit && hasSpecial)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("La contraseña debe incluir al menos una letra mayúscula, una minúscula, un número y un carácter especial.");
            }

            return new ValidationResult("La contraseña no es válida.");
        }
    }
}
