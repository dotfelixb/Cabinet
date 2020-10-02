using System.Threading.Tasks;
using Cabinet.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Server.Features.Document
{
    public class DocumentController : MethodControler
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get document info
        /// </summary>
        [HttpGet("document.info", Name = nameof(GetDocumentInfo))]
        public async Task<IActionResult> GetDocumentInfo([FromQuery]string containerName, [FromQuery] string documentName)
        {
            var query = new GetDocumentInfoQuery(containerName, documentName);
            var result = await _mediator.Send(query);
            return Ok(new { success = true, payload = result });
        }

        /// <summary>
        /// Get a document
        /// </summary>
        [HttpGet("document.get", Name = nameof(GetDocument))]
        public async Task<IActionResult> GetDocument([FromQuery] string containerName, [FromQuery] string documentName)
        {
            var query = new GetDocumentQuery(containerName, documentName);
            var result = await _mediator.Send(query);
            return Ok(new { success = true, payload = result });
        }

        /// <summary>
        /// Create document
        /// </summary>
        [HttpGet("document.create", Name = nameof(CreateDocument))]
        public async Task<IActionResult> CreateDocument([FromQuery] string containerName, [FromQuery] string documentName)
        {
            var query = new CreateDocumentCommand(containerName, documentName);
            var result = await _mediator.Send(query);
            return Ok(new { success = true, payload = result });
        }
    }
}
