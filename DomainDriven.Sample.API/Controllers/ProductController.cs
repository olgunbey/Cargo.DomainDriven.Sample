using DomainDriven.Sample.API.Feature.Product.Application.Commands.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest addProductRequest)
        {
            var data = new
            {
                Description="Description1",
                Color="Red",

            };

            string dat2a = JsonSerializer.Serialize(data);
            return Ok(await mediator.Send(addProductRequest));
        }
    }
}
