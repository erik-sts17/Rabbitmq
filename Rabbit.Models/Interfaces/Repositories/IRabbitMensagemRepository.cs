using Rabbit.Models.Entities;

namespace Rabbit.Models.Interfaces.Repositories
{
    public interface IRabbitMensagemRepository
    {
        void Send(RabbitMensagem rabbitMensagem);
    }
}