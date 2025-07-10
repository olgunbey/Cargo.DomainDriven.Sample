using DomainDriven.Sample.API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CargoDbContext>(options =>
{
    options.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=checkpointpassword;Port=5432;Database=Cargo");
});
builder.Services.AddScoped<IApplicationDbContext, CargoDbContext>();
builder.Services.AddEventStoreClient("esdb://localhost:2113?tls=false");
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
