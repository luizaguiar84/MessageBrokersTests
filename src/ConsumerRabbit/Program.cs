using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri(@"amqp://guest:guest@localhost:5672/");

var connection = factory.CreateConnection();

var channel = connection.CreateModel();

var consumidor = new EventingBasicConsumer(channel);

consumidor.Received += (sender, eventArg) =>
{
    var message = Encoding.UTF8.GetString(eventArg.Body.Span);
    Console.WriteLine($"Mensagem recebida: {message}");
    //Thread.Sleep(1000);
    channel.BasicAck(eventArg.DeliveryTag, multiple: false);
};

var queue = "queue";
channel.BasicConsume(queue: queue, autoAck: false, consumer: consumidor);

Console.ReadKey();