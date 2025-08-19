namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Dtos
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenLifeTime { get; set; }
        public DateTime RefreshTokenLifeTime { get; set; }
    }
}
