using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates
{
    public class ClientCredential : AggregateRoot
    {
        public ClientCredential()
        {

        }
        public ClientCredential(string clientId, string clientSecret, string issuer, string audience)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.Issuer = issuer;
            this.Audience = audience;
        }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string Issuer { get; private set; }
        public string Audience { get; private set; }
    }
}
