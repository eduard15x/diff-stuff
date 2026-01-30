dotnet add package microsoft.entityframeworkcore.sqlite --version 8.0.2
dotnet add package microsoft.entityframeworkcore.design --version 8.0.2
dotnet add package FluentValidation --version 8.0.2

-> create Model

-> create AppDbContext
-> add Order model to db set

-> create connection string in appsettings.json
-> register connection string in Program.cs

-> initialize database
    -dotnet ef migrations add InitialMigration
    -dotnet ef database update

-> create controller and use AppDbContext and insert in constructor using Dependency Injection...

-CQRS Manually
    -folders: Queries, Commands, Handlers
    -Queries/GetOrderByIdQuery.cs
    -Commands/CreateOrderCommand.cs
    -Handlers/GetOrderByIdQueryHandler.cs, CreateOrderCommandHandler.cs

    *GetOrderByIdQuery.cs
    public record GetOrderByIdQuery(int OrderId);

    *CreateOrderCommand.cs
    public record CreateOrderCommand(
        string FirstName,
        string LastName,
        string Status,
        decimal TotalCost
    );

    *GetOrderByIdQueryHandler.cs
    public class GetOrderByIdQueryHandler
    {
        public static async Task<Order?> Handle(GetOrderByIdQuery query, AppDbContext dbContext)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == query.OrderId);
        }
    }

    *CreateOrderCommandHandler.cs
    public class CreateOrderCommandHandler
    {
        public static async Task<Order> Handle(CreateOrderCommand command, AppDbContext dbContext)
        {
            var order = new Order
            {
                FirstName = command.FirstName,
                CreatedAt = DateTime.Now,
                ...
            };
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }

    *Use them in controller


-Add DTO instead models
-change static handlers to interfaces...
    -Handlers/IQueryHandler.cs
    -Handlers/ICommandHandler.cs

    *IQueryHandler.cs
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult?> HandleAsync(TQuery query);
    }

    *ICommandHandler.cs
    public interface ICommandHandler<TCommand, TResult> where TCommand : notnull
    {
        Task<TResult> HandleAsync(TCommand command);
    }

-update existing commands and queries with new interface
-register interface in Program.cs (scoped)