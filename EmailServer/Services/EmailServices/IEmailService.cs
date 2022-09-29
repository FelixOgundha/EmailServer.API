using EmailServer.Models;
using FluentEmail.Core;

namespace EmailServer.Services.EmailServices
{
    public interface IEmailService
    {
        public Task<bool> SendEmail(SenderEmail email);
    }
}
