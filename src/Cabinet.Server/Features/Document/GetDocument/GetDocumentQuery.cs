using Cabinet.Server.Model;
using FluentResults;
using MediatR;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentQuery : IRequest<Result<CabinetFileInfo>>
    {
        public string ContainerName { get; set; }
        public string DocumentName { get; set; }

        public GetDocumentQuery(string containerName, string documentName)
        {
            ContainerName = containerName;
            DocumentName = documentName;
        }
    }
}