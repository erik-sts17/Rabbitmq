using Rabbit.Models.Entities;
using Rabbit.Models.Interfaces.Repositories;
using Rabbit.Models.Interfaces.Services;

namespace Rabbit.Services
{
    public class RabbitMensagemService : IRabbitMensagemService
    {
        private readonly IRabbitMensagemRepository _repository;
        public RabbitMensagemService(IRabbitMensagemRepository repository)
        {
            _repository = repository;
        }
        public void Send(RabbitMensagem mensagem)
        {
            _repository.Send(mensagem);
        }
    }
}