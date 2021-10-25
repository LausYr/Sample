using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Entities.Validation.Models;
using Sample.OAuth.Data;

namespace Sample.OAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СoincidenceEmailController : ControllerBase
    {
        OAuthContext _db;
        public СoincidenceEmailController(OAuthContext db)
        {
            _db = db;
        }
        public async Task<ActionResult<string>> Post([FromBody] EmailValidModel Email)
        {
            var test = await Task.Run(() => _db.Accounts.Any(a => a.Email == Email.Value));
            if (test)
                return BadRequest("Данный Email уже зарегестрирован");
            else 
                return Ok();
        }
    }
}
