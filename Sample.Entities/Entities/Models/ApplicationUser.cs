using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sample.Entities.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTimeOffset DateCreated { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите фамилию")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля LastName 256 символов")]
        public string LastName { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля FirstName 256 символов")]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите отчество")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Используйте кириллицу")]
        [MaxLength(256, ErrorMessage = "Длина поля Patronymic 256 символов")]
        public string Patronymic { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите дату рождения")]
        //[CustomValidation(typeof(AgeValidator), "IsValid")]
        public DateTime? DateOfBirth { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"^((7|8)+([0-9]){10})$", ErrorMessage = "Неверный формат номера телефона")]
        [MaxLength(11, ErrorMessage = "Длина поля PhoneNumber 11 символов")]
        public override string PhoneNumber { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        [MaxLength(256, ErrorMessage = "Длина поля Email 256 символов")]
        public override string Email { get; set; }

        [NotMapped]
        [MaxLength(256, ErrorMessage = "Длина поля Password 256 символов")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        //[CustomValidation(typeof(PasswordValidatorHasChar), "IsValid")]
        //[CustomValidation(typeof(PasswordValidatorHasNumberSpecial), "IsValid")]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

    }
}
