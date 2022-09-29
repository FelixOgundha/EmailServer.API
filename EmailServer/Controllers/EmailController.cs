using EmailServer.Models;
using EmailServer.Services.EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _email;

        public EmailController(IEmailService email)
        {
            _email = email;
        }

        [HttpPost("TestMail")]
        public async Task<IActionResult> TestMail(SenderEmail mail)
        {
            var result = await _email.SendEmail(mail);

            return Ok(result);
        }
    }
}
