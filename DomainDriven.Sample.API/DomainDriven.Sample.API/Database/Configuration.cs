namespace DomainDriven.Sample.API.Database
{
    public class Configuration
    {
        public static string ConnectionString => new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetConnectionString("CargoDb")!;
    }
}
