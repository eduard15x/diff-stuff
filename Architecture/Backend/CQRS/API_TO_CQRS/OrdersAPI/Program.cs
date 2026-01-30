using Microsoft.EntityFrameworkCore;
using OrdersAPI.Commands;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Handlers;
using OrdersAPI.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BaseConnection"))
);

builder.Services.AddScoped<ICommandHandler<CreateOrderCommand, OrderDto>, CreateOrderCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetOrderByIdQuery, OrderDto?>, GetOrderByIdQueryHandler>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
