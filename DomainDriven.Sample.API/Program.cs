using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICargo, CargoInformation>();
builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<CargoDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("CargoDb"));
});
builder.Services.AddScoped<ICargoManagementDbContext, CargoDbContext>();
builder.Services.AddEventStoreClient("esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false");

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
