using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoController(IMediator mediator) : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> AddCargo([FromBody] CreateCargoRequest addCargoRequest)
        //{
        //    return Ok(await mediator.Send(addCargoRequest));
        //}
        //[HttpGet]
        //public async Task<IActionResult> UpdateCargoStatus([FromHeader] UpdateCargoStatusRequest updateCargoStatusRequest)
        //{
        //    return Ok(await mediator.Send(updateCargoStatusRequest));
        //}
    }
}
