using EmailServer.Models;

using System.Net;
using System.Net.Mail;

namespace EmailServer.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendEmail(SenderEmail email)
        {
           SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("felixadams6116@gmail.com",
               "zpixtfepnkwhxxxxx");
            smtp.Send("felixadams6116@gmail.com", email.To,
               email.Subject, email.Body);
         
            smtp.Dispose();
            return Task.FromResult(true);
        }
    }
}
