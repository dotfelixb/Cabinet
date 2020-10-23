using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, string>
    {
        public Task<string> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.DocumentName);
        }
    }
}