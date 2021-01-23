using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cabinet.Server.Controllers
{
    [Route("methods")]
    public class MethodControler : ControllerBase
    {
        public ObjectResult ResultResponse<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(new { success = result.IsSuccess, payload = result.Value });
            }
            else
            {
                return NotFound(new { success = false, reasons = result.Reasons.Select(r => r.Message) });
            }
        }

        public BadRequestObjectResult RequiredBadResponse(string reason = "")
        {
            return BadRequest(new { reason });
        }

        public BadRequestObjectResult RequiredBadResponse(string[] reasons)
        {
            return BadRequest(new { reasons });
        }
    }
}