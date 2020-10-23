using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Cabinet.Server.Features.Document
{
    public class CreateDocumentCommand : IRequest<Result<CabinetFileInfo>>
    {
        public IFormFile FromFile { get; set; }
        public string ContainerName { get; set; }
        public string DocumentName { get; set; }
        public bool OverRide { get; set; }

        public CreateDocumentCommand(IFormFile file, string containerName, string documentName, bool overRide)
        {
            FromFile = file;
            ContainerName = containerName;
            DocumentName = documentName;
            OverRide = overRide;
        }
    }
}