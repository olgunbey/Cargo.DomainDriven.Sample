using DomainDriven.Sample.API.Feature.Location.Application.Queries.City;
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
    }
}
