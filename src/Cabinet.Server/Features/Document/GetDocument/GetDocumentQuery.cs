using MediatR;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentQuery : IRequest<string>
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
