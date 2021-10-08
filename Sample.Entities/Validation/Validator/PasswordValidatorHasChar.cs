using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sample.Entities.Validation.Validator
{
    // Пароль должен содержать хотя бы одну заглавную букву  (A - Z) и одну строчную (a - z)
    public class PasswordValidatorHasChar
    {
        public static ValidationResult IsValid(string password, ValidationContext context)
        {
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");

            bool isValidated = hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password);
           
            if (isValidated)
                return ValidationResult.Success;
            else
                return new ValidationResult("Пароль должен содержать хотя бы одну заглавную (A - Z) и одну строчную (a - z) букву");
        }
    }
}
