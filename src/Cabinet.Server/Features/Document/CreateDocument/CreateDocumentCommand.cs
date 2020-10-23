using MediatR;

namespace Cabinet.Server.Features.Document
{
    public class CreateDocumentCommand : IRequest<string>
    {
        public string ContainerName { get; set; }
        public string DocumentName { get; set; }

        public CreateDocumentCommand(string containerName, string documentName)
        {
            ContainerName = containerName;
            DocumentName = documentName;
        }
    }
}