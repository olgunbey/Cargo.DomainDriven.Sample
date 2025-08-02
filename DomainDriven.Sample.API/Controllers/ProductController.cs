using DomainDriven.Sample.API.Feature.Product.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest addProductRequest)
        {
            return Ok(await mediator.Send(addProductRequest));
        }
    }
}
