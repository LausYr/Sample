using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sample.Client.IHttpRepository;
using Sample.Entities.Models;

namespace Sample.Client.HttpRepository
{
    public class RegistrationHttp : IRegistrationHttp
    {
        private readonly HttpClient _client;
        public RegistrationHttp()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:5005")};
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _client.DefaultRequestHeaders.Add("User-Agent", "blazorWASM");
        }

            public async Task<HttpResponseMessage> CreateAccount(ApplicationUser account)
        {
            var content = JsonSerializer.Serialize(account);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("api/Registration", bodyContent);
            return postResult;
        }
    }
}
