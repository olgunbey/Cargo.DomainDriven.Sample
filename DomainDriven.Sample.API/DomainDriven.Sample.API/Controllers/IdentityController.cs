using DomainDriven.Sample.API.Feature.IdentityServer.Application.Commands;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ResourceOwnerRequest loginRequest)
        {
            return this.ResponseApi(await mediator.Send(loginRequest));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Refresh([FromHeader] string refreshToken)
        {
            return this.ResponseApi(await mediator.Send(new RefreshTokenRenewalRequest() { RefreshToken = refreshToken }));
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            return this.ResponseApi(await mediator.Send(registerRequest));
        }
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] ClientCredentialRequest clientCredentialRequest)
        {
            return this.ResponseApi(await mediator.Send(clientCredentialRequest));
        }
    }
}
