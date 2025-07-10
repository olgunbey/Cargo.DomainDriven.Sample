using DomainDriven.Sample.API.CargoManagement.Application.Commands;
using DomainDriven.Sample.API.CargoManagement.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoManagerController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCargo(AddCargoRequestDto addCargoRequest)
        {
            var response = await mediator.Send(new AddCargoRequest() { AddCargoRequestDto = addCargoRequest });
            return Ok(response);
        }
    }
}
