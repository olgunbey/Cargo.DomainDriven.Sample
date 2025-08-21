using DomainDriven.Sample.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriven.Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ResponseApi<T>(ResponseDto<T> responseDto)
        {
            HttpContext.Response.StatusCode = responseDto.StatusCode;
            if (responseDto.StatusCode == 204)
                return NoContent();


            return new ObjectResult(responseDto);
        }
    }
}
