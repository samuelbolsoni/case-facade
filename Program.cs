using CaseFacade.Facade;
using CaseFacade.Facade.Interfaces;
using CaseFacade.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services registration
builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<ShippingService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<NotificationService>();

// registrar o facade
builder.Services.AddScoped<IPurchaseFacade, PurchaseFacade>();

var app = builder.Build();

// Ativar Swagger em ambiente de desenvolvimento
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "Facade Pattern API";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});

app.MapControllers();

app.Run();