using DomainDriven.Sample.API.Database;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRedisClientsManagerAsync>(new RedisManagerPool("localhost:6379"));
builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<CargoDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("CargoDb"));
});

builder.Services.AddEventStoreClient("esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false");

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
