using Cabinet.Server.Model;
using FluentResults;
using MediatR;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommand : IRequest<Result<CabinetFileInfo>>
    {
        public string ContainerName { get; set; }

        public CreateContainerCommand(string name)
        {
            ContainerName = name;
        }
    }
}