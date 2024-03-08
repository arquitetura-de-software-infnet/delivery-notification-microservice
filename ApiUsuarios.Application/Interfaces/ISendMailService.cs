using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.DTOs;

namespace ApiUsuarios.Application.Interfaces
{
    public interface ISendMailService
    {
        void SendMail(EmailMessageModel model);
    }
}
