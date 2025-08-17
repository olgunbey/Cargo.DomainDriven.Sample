using DomainDriven.Sample.API.Feature.Product.Application.Commands.Product;
using DomainDriven.Sample.API.Feature.Product.Application.Dtos;
using DomainDriven.Sample.API.Feature.Product.Application.Queries;
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
        [HttpGet]
        public async Task<IActionResult> GetAllProductByCategoryId([FromHeader] Guid categoryIdRequest)
        {
            return Ok(await mediator.Send(new GetAllProductByCategoryIdRequest() { CategoryId=categoryIdRequest}));
        }
    }
}
