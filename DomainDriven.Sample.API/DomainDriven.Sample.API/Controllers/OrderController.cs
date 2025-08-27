using DomainDriven.Sample.API.Feature.Order.Application.Commands;
using DomainDriven.Sample.API.Feature.Order.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest)
        {
            return base.ResponseApi(await mediator.Send(createOrderRequest));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderByCustomerId([FromHeader]Guid customerId)
        {
            return base.ResponseApi(await mediator.Send(new GetAllOrderByCustomerIdRequest() { CustomerId = customerId }));

        }
    }
}
