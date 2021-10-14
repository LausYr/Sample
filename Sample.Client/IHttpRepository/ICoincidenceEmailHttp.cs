using System.Threading.Tasks;
using Sample.Entities.Validation.Models;

namespace Sample.Client.HttpRepository
{
    public interface ICoincidenceEmailHttp
    {
        Task<string> Coincidence(EmailValidModel email);
    }
}
