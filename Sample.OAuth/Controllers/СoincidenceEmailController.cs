using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Entities.Validation.Models;
using Sample.OAuth.Data;

namespace Intelzaim.OAuth.Controllers
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
        public async Task<ActionResult<string>> Post([FromBody] EmailValidModel model)
        {
            var test = await Task.Run(() => _db.Accounts.Any(a => a.Email == model.Email));
            if (test)
                return BadRequest("Данный номер телефона уже зарегестрирован");
            else 
                return Ok();
        }
    }
}
