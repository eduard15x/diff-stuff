var builder = WebApplication.CreateBuilder(args);

// Used for YARP API
// Create route and clusters for any service you need
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// Used for YARP Api
app.MapReverseProxy();

app.Run();
