using Confluent.Kafka;

var config = new ProducerConfig()
{
    BootstrapServers = "tricycle-01.srvs.cloudkafka.com:9094,tricycle-02.srvs.cloudkafka.com:9094,tricycle-03.srvs.cloudkafka.com:9094",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.ScramSha256,
    SaslUsername = "l2gu7ibo",
    SaslPassword = "eg6etvHq9SDqkqyMfKxoPldKvH_4Mtvk"
};

var builder = new ProducerBuilder<string, string>(config);

using (var producer = builder.Build())
{
    var message = new Message<string, string>
    {
        Key = "Luiz",
        Value = "Hello World"
    };

    var topic = "l2gu7ibo-default";

    for (int i = 0; i < 50; i++)
    {
        await producer.ProduceAsync(topic, message);
    }
}
