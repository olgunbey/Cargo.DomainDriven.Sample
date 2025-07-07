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
        public async Task<IActionResult> AddCargo(AddCargoInformationRequest addCargoInformationRequest)
        {
            var response = await mediator.Send(addCargoInformationRequest);
            return Ok(response);
        }
    }
}
