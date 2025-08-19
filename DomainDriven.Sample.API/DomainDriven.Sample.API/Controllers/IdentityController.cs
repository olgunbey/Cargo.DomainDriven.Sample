using DomainDriven.Sample.API.Feature.IdentityServer.Application.Commands;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            return this.ResponseApi(await mediator.Send(loginRequest));
        }
        [HttpPost]
        public async Task<IActionResult> RefreshTokenControl([FromBody] RefreshTokenControlRequest refreshTokenControlRequest)
        {
            return this.ResponseApi(await mediator.Send(refreshTokenControlRequest));
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            return this.ResponseApi(await mediator.Send(registerRequest));

        }
    }
}
