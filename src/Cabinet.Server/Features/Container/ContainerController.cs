using Cabinet.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class ContainerController : MethodControler
    {
        private readonly IMediator _mediator;

        public ContainerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get container info
        /// </summary>
        [HttpGet("container.info", Name = nameof(GetContainer))]
        public async Task<IActionResult> GetContainer([FromQuery] string containername)
        {
            var query = new GetContainerQuery(containername);
            var result = await _mediator.Send(query);
            return ContainerResponse(result);
        }

        /// <summary>
        /// Create container
        /// </summary>
        [HttpPost("container.create", Name = nameof(CreateContainer))]
        public async Task<IActionResult> CreateContainer([FromQuery] string containername)
        {
            var command = new CreateContainerCommand(containername);
            var result = await _mediator.Send(command);
            return ContainerResponse(result);
        }
    }
}
