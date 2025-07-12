using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContextFactory : IDesignTimeDbContextFactory<CargoDbContext>
    {
        public CargoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CargoDbContext>();
            var connectionString = configuration.GetConnectionString("CargoDb");

            optionsBuilder.UseNpgsql(connectionString);

            return new CargoDbContext(optionsBuilder.Options);
        }
    }
}
