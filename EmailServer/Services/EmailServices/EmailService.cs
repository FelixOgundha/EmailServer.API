using EmailServer.Models;
using FluentEmail.Core;
using System.Net;
using System.Net.Mail;

namespace EmailServer.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendEmail(SenderEmail email)
        {
            return Task.FromResult(true);
        }
    }
}
