using System.Net.Http;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Client.IHttpRepository
{
    public interface IRegistrationHttp
    {
        Task<HttpResponseMessage> CreateAccount(ApplicationUser account);
    }
}
