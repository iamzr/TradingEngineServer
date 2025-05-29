using Api.Grpc.Services;
using TradingEngineServer.OrderbookManager;
using TradingEngineServer.Orders;

var builder = WebApplication.CreateBuilder(args);

// Register background engine
builder.Services.AddSingleton<IOrderbookManager, OrderbookManager>();
builder.Services.AddSingleton<IOrderIdGenerator, OrderIdGenerator>();

// Add services to the container.
builder.Services.AddGrpc();

// Add reflection service
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<TradingService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


// Enable gRPC reflection in development only.
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();
