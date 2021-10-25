using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Sample.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Sample.OAuth.Data;

namespace Sample.OAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {

        private readonly OAuthContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public RegistrationController(UserManager<ApplicationUser> userManager, OAuthContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Post([FromBody] ApplicationUser account)
        {
            bool email = _db.Accounts.Any(a => a.NormalizedEmail == account.Email.ToUpper());
            bool phone = _db.Accounts.Any(p => p.PhoneNumber == account.PhoneNumber);
            if(email || phone) return BadRequest("Данный Email или номер телефона уже зарегестрирован");
            else
            {
                account.FirstName = Formating(account.FirstName);
                account.LastName = Formating(account.LastName);
                account.Patronymic = Formating(account.Patronymic);
                account.PhoneNumber = '7' + account.PhoneNumber.Remove(0, 1);
                account.DateCreated = DateTimeOffset.Now;
                account.UserName = account.Email;

                IdentityResult result = await _userManager.CreateAsync(account, account.Password);
                if (result.Succeeded)
                {
                    return Ok("Регистрация завершена");
                }
                else
                {
                    return BadRequest("Во время регистрации произошла ошибка");
                }
            }
        }

        private static string Formating(string name)
        {
            name = name.ToLower();
            name = name.ToUpper()[0] + name.Substring(1);
            return name;
        }

    }
}   
    