using DomainDriven.Sample.API.Employee.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public IActionResult AssignToEmployee(AssignToEmployeeRequest assignToEmployeeRequest)
        {
            return Ok();
        }
    }
}
