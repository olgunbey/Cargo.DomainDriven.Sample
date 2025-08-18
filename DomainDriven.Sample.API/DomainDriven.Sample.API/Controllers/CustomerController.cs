using DomainDriven.Sample.API.Feature.Customer.Application.Commands;
using DomainDriven.Sample.API.Feature.Customer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequestDto)
        {
            return ResponseApi(await mediator.Send(loginRequestDto));
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequestDto)
        {
            return ResponseApi(await mediator.Send(registerRequestDto));
        }
    }
}
