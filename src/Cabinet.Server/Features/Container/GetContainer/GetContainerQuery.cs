using Cabinet.Server.Model;
using FluentResults;
using MediatR;

namespace Cabinet.Server.Features.Container
{
    public class GetContainerQuery : IRequest<Result<CabinetFileInfo>>
    {
        public string ContainerName { get; set; }

        public GetContainerQuery(string name)
        {
            ContainerName = name;
        }
    }
}