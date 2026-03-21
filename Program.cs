using WorkerOrdersManagement;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var environment = builder.Environment.EnvironmentName;
Console.WriteLine(environment);

var host = builder.Build();
host.Run();
