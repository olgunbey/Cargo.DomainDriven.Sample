namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos
{
    public class TokenConf
    {
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
    }
}
