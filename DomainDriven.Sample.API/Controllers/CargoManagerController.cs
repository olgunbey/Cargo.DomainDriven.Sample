using DomainDriven.Sample.API.CargoManagement.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoManagerController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCargo(AddCargoRequest addCargoRequest)
        {
            var response = await mediator.Send(addCargoRequest);
            return Ok(response);
        }
    }
}
