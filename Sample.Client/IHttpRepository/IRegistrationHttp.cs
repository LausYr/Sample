using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Client.IHttpRepository
{
    public interface IRegistrationHttp
    {
        Task<string> CreateAccount(ApplicationUser account);
    }
}
