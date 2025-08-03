using DomainDriven.Sample.API.Database;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Application.IntegrationEventHandlers;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ServiceStack;
using ServiceStack.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IMongoClient>(cnf => new MongoClient("mongodb+srv://olgunbey:UWCtu6HVrcbs6zeu@parametrecluster.hvwzz.mongodb.net/?retryWrites=true&w=majority&appName=ParametreCluster"));


builder.Services.AddSingleton<IRedisClientsManagerAsync>(new RedisManagerPool("localhost:6379"));
builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<CargoDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("CargoDb"));
});

builder.Services.AddEventStoreClient("esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false");

builder.Services.AddScoped<ICargoDbContext>(provider => provider.GetRequiredService<CargoDbContext>());

builder.Services.AddScoped<IProductDbContext>(provider => provider.GetRequiredService<CargoDbContext>());

builder.Services.AddScoped<IOrderDbContext>(provider => provider.GetRequiredService<CargoDbContext>());

builder.Services.AddScoped<ILocationDbContext>(provider => provider.GetRequiredService<CargoDbContext>());

builder.Services.AddMassTransit<IBus>(configure =>
{
    configure.AddConsumer<OrderReceivedIntegrationEventHandler>();
    configure.UsingRabbitMq((context, configurator) =>
    {

        configurator.Host(builder.Configuration.GetSection("AmqpConf")["Host"], config =>
        {
            config.Username(builder.Configuration.GetSection("AmqpConf")["Username"]!);
            config.Password(builder.Configuration.GetSection("AmqpConf")["Password"]!);

        });
        configurator.ReceiveEndpoint("OrderReceivedIntegrationEvent", cnf => cnf.ConfigureConsumer<OrderReceivedIntegrationEventHandler>(context));

    });

});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
