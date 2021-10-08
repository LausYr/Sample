using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sample.Entities.Validation.Validator
{
    // Пароль должен содержать минимум одну цифру и один не буквенно-цифровой символ
    public class PasswordValidatorHasNumberSpecial
    {
        public static ValidationResult IsValid(string password, ValidationContext context)
        {
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasSpecial =new Regex(@"\W");

            bool isValidated = hasNumber.IsMatch(password) && hasSpecial.IsMatch(password);

            if (isValidated)
                return ValidationResult.Success;
            else
                return new ValidationResult("Пароль должен содержать минимум одну цифру и один не буквенно-цифровой символ");
        }
    }
}
