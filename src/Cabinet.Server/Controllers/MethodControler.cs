using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cabinet.Server.Controllers
{
    [Route("methods")]
    public class MethodControler : ControllerBase
    {
        public OkObjectResult ContainerResponse<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(new { success = result.IsSuccess, payload = result.Value });
            }
            else
            {
                return Ok(new { success = false, reasons = result.Reasons.Select(r => r.Message) });
            }
        }
    }
}