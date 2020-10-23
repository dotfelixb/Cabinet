using Cabinet.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetDocumentInfo(
            [FromQuery] string containerName,
            [FromQuery] string documentName)
        {
            var query = new GetDocumentInfoQuery(containerName, documentName);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(new { success = true, payload = result.Value });
        }

        /// <summary>
        /// Get a document as download
        /// </summary>
        [HttpGet("document.get", Name = nameof(GetDocument))]
        public async Task<IActionResult> GetDocument(
            [FromQuery] string containerName,
            [FromQuery] string documentName)
        {
            var query = new GetDocumentQuery(containerName, documentName);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            var file = new FileStream(result.Value.Path, FileMode.Open);
            return File(file, result.Value.MimeType, fileDownloadName: result.Value.Name);
        }

        /// <summary>
        /// Create document
        /// </summary>
        [HttpPost("document.create", Name = nameof(CreateDocument))]
        public async Task<IActionResult> CreateDocument(
            IFormFile file,
            [FromQuery] string containerName,
            [FromQuery] string documentName,
            [FromQuery] bool overRide)
        {
            var query = new CreateDocumentCommand(file, containerName, documentName, overRide);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                var reasons = result.Errors.ToArray().Select(r => r.Message);
                return BadRequest(new {success = false, reasons });
            }

            return Ok(new { success = true, payload = result.Value });
        }
    }
}