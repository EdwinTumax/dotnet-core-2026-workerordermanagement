using System.Text.Json;
using WorkerOrdersManagement.Domain.Entities;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                Order orderProcessOne = new Order();                            
                orderProcessOne.EntityType = EntityType.CANDIDATE;
                orderProcessOne.OperationType = OperationType.CREATE;
                orderProcessOne.Status = OrderStatus.PENDING;
                orderProcessOne.Aspirante = new Aspirante();
                orderProcessOne.Aspirante.Apellidos = "Tumax";
                orderProcessOne.Aspirante.Nombres = "Edwin";
                orderProcessOne.Aspirante.Direccion = "Guatemala, Guatemala";
                orderProcessOne.Aspirante.Email = "edwintumax@gmail.com";
                orderProcessOne.Aspirante.ExamenId = "1";
                orderProcessOne.Aspirante.JornadaId = "2";
                orderProcessOne.Aspirante.CarreraId = "3";

                _logger.LogInformation("Worker running Object one: {0}", JsonSerializer.Serialize(orderProcessOne));
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
