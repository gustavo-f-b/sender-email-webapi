using Microsoft.AspNetCore.Mvc;
using SenderEmail.WebApi.Models;

namespace SenderEmail.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("enviar-email")]
        public IActionResult SendEmail(Email email)
        {
            var result = _emailService.Send(email);

            return Ok(result);
        }
    }
}
