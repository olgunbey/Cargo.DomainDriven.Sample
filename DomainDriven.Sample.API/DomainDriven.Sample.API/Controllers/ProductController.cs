using DomainDriven.Sample.API.Feature.Product.Application.Commands.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest addProductRequest)
        {
            return Ok(await mediator.Send(addProductRequest));
        }
        public async Task<IActionResult> GetAllProductByCategoryId([FromHeader]string categoryId)
        {

        }
    }
}
