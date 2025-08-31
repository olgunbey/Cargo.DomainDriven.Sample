namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos
{
    public class ClientCredentialDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenLifeTime { get; set; }
    }
}
