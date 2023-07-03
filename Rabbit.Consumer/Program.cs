using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Rabbit.Models.Entities;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "MensagemQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    try
    {
        var body = ea.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);
        var rabbitMensagem = JsonConvert.DeserializeObject<RabbitMensagem>(json);
        Thread.Sleep(3000);
        Console.WriteLine($"Id: {rabbitMensagem.Id}; Título: {rabbitMensagem.Titulo}; Texto: {rabbitMensagem.Texto}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        channel.BasicNack(ea.DeliveryTag, false, true);
    }
};
channel.BasicConsume(queue: "MensagemQueue",
                     autoAck: true,
                     consumer: consumer);
Console.WriteLine("Digite para sair");
Console.ReadLine();