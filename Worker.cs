using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WorkerOrdersManagement.Domain.Entities;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;
    private IChannel channel;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        connectionFactory.Port = _configuration.GetValue<int>("RabbitBrokerConfiguration:Port");
        connectionFactory.HostName = _configuration.GetValue<string>("RabbitBrokerConfiguration:HostName");
        connectionFactory.UserName = _configuration.GetValue<string>("RabbitBrokerConfiguration:UserName");
        connectionFactory.Password = _configuration.GetValue<string>("RabbitBrokerConfiguration:Password");
        try
        {
            IConnection connection = await connectionFactory.CreateConnectionAsync();
            this.channel = await connection.CreateChannelAsync();
            var consumer = new AsyncEventingBasicConsumer(this.channel);
            consumer.ReceivedAsync += ConsumerMessageReceivedEvent;

            await this.channel.BasicConsumeAsync(
                queue: _configuration.GetValue<string>("RabbitBrokerConfiguration:Queue"),
                autoAck: false,
                consumer: consumer
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            Console.WriteLine(ex.Message);
        }

    }

    private async Task ConsumerMessageReceivedEvent(object sender, BasicDeliverEventArgs e)
    {
        try
        {
            string message = Encoding.UTF8.GetString(e.Body.ToArray());
            Order order = JsonSerializer.Deserialize<Order>(message);
            await this.channel.BasicAckAsync(e.DeliveryTag, false);
            await sendOrder(order);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task sendOrder(Order order)
    {
        HttpClient client = new HttpClient();
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = {new JsonStringEnumConverter()}
        };
        StringContent content = new StringContent(JsonSerializer.Serialize(order, options));
        var response = await client.PostAsync(_configuration.GetValue<string>("HttpClientOrderConfiguration:url"),content);
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(responseBody);
    }

}
