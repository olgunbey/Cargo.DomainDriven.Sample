using DomainDriven.Sample.API.Feature.Product.Application.Commands.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    }
}
