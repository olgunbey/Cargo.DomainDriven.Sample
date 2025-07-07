using DomainDriven.Sample.API.Location.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityRequest addCityRequest)
        {
            bool response = await mediator.Send(addCityRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddDistrict(AddDistrictRequest addDistrictRequest)
        {
            bool response = await mediator.Send(addDistrictRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddNeighbourhood(AddNeighbourhoodRequest addCountryRequest)
        {
            bool response = await mediator.Send(addCountryRequest);
            return Ok(response);
        }
    }
}
