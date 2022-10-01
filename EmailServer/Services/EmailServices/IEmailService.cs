using EmailServer.Models;

namespace EmailServer.Services.EmailServices
{
    public interface IEmailService
    {
        public Task<bool> SendEmail(SenderEmail email);
    }
}
