using System.Net.Http;
using System.Threading.Tasks;
using Sample.Entities.Validation.Models;

namespace Sample.Client.IHttpRepository
{
    public interface ICoincidencePhoneNumberHttp
    {
        Task<HttpResponseMessage> Coincidence(PhoneNumberValidModel phone);
    }
}
