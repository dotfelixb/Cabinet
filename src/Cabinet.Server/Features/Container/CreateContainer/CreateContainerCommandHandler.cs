using Cabinet.Server.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, string>
    {
        public Task<string> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            // check if container exist

            return Task.FromResult(request.ContainerName);
        }
    }
}
