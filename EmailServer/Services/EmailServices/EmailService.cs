using EmailServer.Models;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServer.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendEmail(SenderEmail email)
        {
            string htmlBody = @"
               <html lang="" en"">

                <head>
                  <meta content="" text/html; charset=utf-8"" http-equiv="" Content-Type"">
                  <title>Hotel Room Booking Receipt</title>
                  <style type="" text/css"">
                    /* Inline CSS styles */
                            HTML{background-color: #FFFFFF; color: #000000; text-align: center;}
                            .cover{margin-left: 50px;margin-right: 50px;}
                            .heading{font-size: 20px; font-weight: bold;color:white;background-color: #8B4513;padding-top: 1px;padding-bottom: 1px;text-align: center;}
                            .emailBody{font-size: 18px;padding-top: 10px;padding-right: 10px;padding-left: 10px;text-align: justify;color:black;}
                        </style>
                </head>

                <body>

                  <div class="" cover"">
                    <div class="" heading"">
                      <h2>Reservation Made Successfully!</h2>
                    </div>
                    <div class="" emailBody"">
                      <p>Hello Felix,</p>
                      <p>We are thrilled to inform you that your hotel room booking at Dhe Jomels Hotel has been successfully confirmed!
                        We
                        look
                        forward to welcoming you on[check -in date] and providing you with a delightful stay.</p>
                      <p>
                        Please feel free to reach out to us if you have any further inquiries or if there's anything we can do to make
                        your stay
                        more comfortable.
                      </p>
                      <p>
                        We can't wait to offer you a memorable experience at our hotel. Thank you for choosing [Hotel Name], and we
                        eagerly
                        await your arrival.
                      </p>
                      <p>
                        Safe travels and see you soon!
                      </p>
                      <p>
                        Best Regards,
                      </p>
                      <p>

                        Dhe Jomels Hotel, Siaya<br />
                        Call:+254 706 452 721<br />
                        Email:booking @dhejomelshotel.co.ke<br />
                      </p>
                    </div>
                  </div>

                </body>

                </html>";

            // Create a plain text version of the email body
            string plainTextBody = "Upcoming topics:\n\n" +
                                  "Using a Windows service in your project - Est. # of posts: 5\n" +
                                  "More RabbitMQ in .NET - Est. # of posts: 5";

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("felixadams6116@gmail.com", "zpixtfepnkwhvpdp");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("felixadams6116@gmail.com");
                mailMessage.To.Add(email.To);
                mailMessage.Subject = email.Subject;
                mailMessage.Body = plainTextBody;
                mailMessage.IsBodyHtml = true;

                // Create an alternate view for the HTML content with inline CSS styles
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, "text/html");
                mailMessage.AlternateViews.Add(htmlView);

                smtp.Send(mailMessage);
            }

            return Task.FromResult(true);
        }
    }
}
