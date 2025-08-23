using DomainDriven.Sample.API.Feature.Location.Application.Commands.Location;
using DomainDriven.Sample.API.Feature.Location.Application.Queries.City;
using DomainDriven.Sample.API.Feature.Location.Application.Queries.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            return this.ResponseApi(await mediator.Send(new GetAllCityRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> SaveLocationForOrder([FromBody] SaveLocationForOrderRequest saveLocationForOrderRequest)
        {
            return this.ResponseApi(await mediator.Send(saveLocationForOrderRequest));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSaveLocationForOrder([FromHeader] Guid customerId)
        {
            return this.ResponseApi(await mediator.Send(new GetAllSaveLocationForOrderRequest(customerId)));
        }
        [HttpGet]
        public async Task<IActionResult> RemoveLocationForOrder([FromHeader]Guid locationId)
        {
            return this.ResponseApi(await mediator.Send(new RemoveLocationForOrderRequest(locationId)));
        }
    }
}
