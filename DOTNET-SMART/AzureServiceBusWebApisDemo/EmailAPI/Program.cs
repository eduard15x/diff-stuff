
using AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus;
using EmailAPI.BackgroundService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string serviceBusConnectionString = builder.Configuration.GetConnectionString("ServiceBusConnection") ?? "";
builder.Services.AddSingleton<IServiceBusQueue, ServiceBusQueue>(
    x => new ServiceBusQueue(serviceBusConnectionString ?? "")
);

builder.Services.AddHostedService<AzureServiceBusListener>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
