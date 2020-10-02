using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class GetContainerQueryHandler : IRequestHandler<GetContainerQuery, string>
    {
        public Task<string> Handle(GetContainerQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.ContainerName);
        }
    }
}
