using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri(@"amqp://guest:guest@localhost:5672/");

var connection = factory.CreateConnection();

using (var channel = connection.CreateModel())
{
    //var props = channel.CreateBasicProperties();  
    //props.ContentType = "text/plain";

    for (int i = 0; i <= 100000; i++)
    {
        byte[] body = Encoding.UTF8.GetBytes($"Testando {i}");

        channel.BasicPublish(
            exchange: "Exchange",
            routingKey: "",
            body: body
            );              
    }
}
