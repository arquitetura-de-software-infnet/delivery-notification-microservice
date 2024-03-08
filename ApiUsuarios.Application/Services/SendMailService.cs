using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.DTOs;
using ApiUsuarios.Domain.Interfaces.Messages;
using ApiUsuarios.Application.Interfaces;
using Newtonsoft.Json;

namespace ApiUsuarios.Application.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly IMailService? _messageProducer;

        public SendMailService(IMailService? messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public void SendMail(EmailMessageModel model)
        {
            var emailMessageDTO = new EmailMessageDTO
            {
                MailTo = model.Mail,
                Subject = "Pedido realizado",
                IsBodyHtml = true,
                Body = $@"
                    <div>
                        <p>Pedido realizado com sucesso.</p>
                        <p>Atenciosamente,</p>
                        <p>Equipe Infnet.</p>
                    </div>
                "
            };

            _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));
        }
    }
}
