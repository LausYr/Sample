using System.Net.Http;
using System.Threading.Tasks;
using Sample.Entities.Validation.Models;

namespace Sample.Client.IHttpRepository
{
    public interface ICoincidenceEmailHttp
    {
        Task<HttpResponseMessage> Coincidence(EmailValidModel email);
    }
}
