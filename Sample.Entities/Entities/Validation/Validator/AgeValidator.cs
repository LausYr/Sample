using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Entities.Validation.Validator
{
    // Пользователь должен быть старше 18 лет
    public class AgeValidator 
    {
        public static ValidationResult IsValid(DateTime? DateOfBirth, ValidationContext context)
        {
            if (DateOfBirth == null) 
                return new ValidationResult("Проверка возраста невозможна, значение DateOfBirth = null ");

            int age = DateTime.Now.Year - DateOfBirth.Value.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.Value.DayOfYear) 
                age++;

            if (age >= 18) 
                return ValidationResult.Success;
            else 
                return new ValidationResult("Пользователю меньше 18 лет");
        }
    }
}
