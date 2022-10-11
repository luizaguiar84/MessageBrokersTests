using Confluent.Kafka;

var config = new ConsumerConfig()
{
    BootstrapServers = "tricycle-01.srvs.cloudkafka.com:9094,tricycle-02.srvs.cloudkafka.com:9094,tricycle-03.srvs.cloudkafka.com:9094",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.ScramSha256,
    SaslUsername = "l2gu7ibo",
    SaslPassword = "eg6etvHq9SDqkqyMfKxoPldKvH_4Mtvk",

    GroupId = "l2gu7ibo-consumer",
    AutoOffsetReset = AutoOffsetReset.Latest

};

var topic = "l2gu7ibo-default";
var count = 0;

var builder = new ConsumerBuilder<string, string>(config);

using var consumer = builder.Build();
consumer.Subscribe(topic);
while (true)
{
    var result = consumer.Consume(TimeSpan.FromSeconds(1));
    if (result != null)
    {
        string texto = result.Message.Value;
        Console.WriteLine($"|{count++}| recebido: {texto}");
    }
}