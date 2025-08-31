namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos
{
    public class GenerateTokenDto
    {
        public string AcessToken { get; set; }
        public DateTime AccessTokenLifeTime { get; set; }
    }
}
