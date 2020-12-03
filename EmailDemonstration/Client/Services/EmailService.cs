using EmailDemonstration.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmailDemonstration.Client.Services
{

    public class EmailService:IEmailService
    {
        private readonly HttpClient httpClient;

        public EmailService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task SendEmail(Email email)
        {
            await this.httpClient.PostAsJsonAsync("api/email", email);
        }
    }
}
