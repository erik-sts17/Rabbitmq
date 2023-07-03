using System.Text;
using Newtonsoft.Json;
using Rabbit.Models.Entities;
using Rabbit.Models.Interfaces.Repositories;
using RabbitMQ.Client;

namespace Rabbit.Repository
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        public void Send(RabbitMensagem mensagem)
        {
           var factory = new ConnectionFactory { 
               HostName = "localhost"
           };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "MensagemQueue",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var json = JsonConvert.SerializeObject(mensagem);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                routingKey: "MensagemQueue",
                                basicProperties: null,
                                body: body);
        }
    }
}