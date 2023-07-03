
using Rabbit.Models.Entities;

namespace Rabbit.Models.Interfaces.Services
{
    public interface IRabbitMensagemService
    {
        void Send(RabbitMensagem rabbitMensagem);
    }
}