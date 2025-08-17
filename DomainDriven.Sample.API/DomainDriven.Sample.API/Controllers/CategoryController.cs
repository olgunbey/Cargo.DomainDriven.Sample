
using DomainDriven.Sample.API.Feature.Product.Application.Commands.Category;
using DomainDriven.Sample.API.Feature.Product.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            return Ok(await mediator.Send(createCategoryRequest));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await mediator.Send(new GetAllCategoryRequest()));
        }
    }
}
