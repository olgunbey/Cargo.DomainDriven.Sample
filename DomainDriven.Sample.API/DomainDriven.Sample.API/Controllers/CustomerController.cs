using DomainDriven.Sample.API.Feature.Customer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequestDto)
        {
            return Ok(await mediator.Send(loginRequestDto));
        }
    }
}
