using EmailServer.Models;

namespace EmailServer.Services.EmailServices
{
    public interface IEmailService
    {
        public void SendEmail(Email email);
    }
}
