using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Entities.Validation.Models;
using Sample.OAuth.Data;

namespace Intelzaim.OAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СoincidencePhoneNumberController : ControllerBase
    {
        OAuthContext _db;
        public СoincidencePhoneNumberController(OAuthContext db)
        {
            _db = db;
        }
        public async Task<ActionResult<string>> Post([FromBody] PhoneNumberValidModel model)
        {
            var test = await Task.Run(() => _db.Accounts.Any(a => a.PhoneNumber == model.PhoneNumber));
            if (test)
                return BadRequest("Данный номер телефона уже зарегестрирован");
            else
                return Ok();
        }
    }
}
