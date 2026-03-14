using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WorkerOrdersManagement.Domain.Entities;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private IChannel channel;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        connectionFactory.Port = 5672;
        connectionFactory.HostName = "localhost";
        connectionFactory.UserName = "guest";
        connectionFactory.Password = "guest";
        try
        {
            IConnection connection = await connectionFactory.CreateConnectionAsync();
            this.channel = await connection.CreateChannelAsync();
            var consumer = new AsyncEventingBasicConsumer(this.channel);
            consumer.ReceivedAsync += ConsumerMessageReceivedEvent;
            
            await this.channel.BasicConsumeAsync(
                queue: "kalum.dev.net.2026.queue",
                autoAck: false,
                consumer: consumer
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            Console.WriteLine(ex.Message);
        }

        /*while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {

                Order orderProcessOne = new Order();     
                orderProcessOne.EntityType = EntityType.APPLICANT;
                orderProcessOne.OperationType = OperationType.CREATE;
                orderProcessOne.Status = OrderStatus.PENDING;
                orderProcessOne.EntityData = new Applicant("Tumax","Edwin","Guatemala, Guatemala","24711529","edwintumax@gmail.com","1","2","3");

                Order orderProcessTow = new Order();     
                orderProcessTow.EntityType = EntityType.STUDENT;
                orderProcessTow.OperationType = OperationType.CREATE;
                orderProcessTow.Status = OrderStatus.PENDING;
                orderProcessTow.EntityData = new Student("Aguilar","Raul","Guatemala, Mixco","33124569","raulaguilar@gmail.com",Guid.NewGuid().ToString());

                Console.WriteLine(orderProcessOne.OrderId);
                Console.WriteLine(orderProcessTow.OrderId);


                _logger.LogInformation("Worker running Object one: {0}", JsonSerializer.Serialize(orderProcessOne));
            }
            await Task.Delay(1000, stoppingToken);
        }*/
    }

    private async Task ConsumerMessageReceivedEvent(object sender, BasicDeliverEventArgs e)
    {
        string message = Encoding.UTF8.GetString(e.Body.ToArray());
        Console.WriteLine($"Mensaje recibido: {message}");
        await this.channel.BasicAckAsync(e.DeliveryTag, false);
    }
}
