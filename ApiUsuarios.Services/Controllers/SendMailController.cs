using ApiUsuarios.Application.Models;
using ApiUsuarios.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailService _sendMailService;

        public SendMailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        [HttpPost]
        public IActionResult SendMail(EmailMessageModel model)
        {
            try
            {
                _sendMailService.SendMail(model);
            }
            catch (Exception ex)
            {
                StatusCode(500, ex);
            }

            return StatusCode(200, model.StatusMessage = "E-mail enviado com sucesso.");
        }
    }
}
