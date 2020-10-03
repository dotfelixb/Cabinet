using Cabinet.Server.Model;
using FluentResults;
using MediatR;

namespace Cabinet.Server.Features.Container
{
    public class GetContainerQuery : IRequest<Result<ContainerInfo>>
    {
        public string ContainerName { get; set; }

        public GetContainerQuery(string name)
        {
            ContainerName = name;
        }
    }
}
