using System.Threading.Tasks;

namespace EmailDemonstration.Shared
{
    public interface IEmailService
    {
        public Task SendEmail(Email email);
    }
}
