using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommand : IRequest<Result<ContainerInfo>>
    {
        public string ContainerName { get; set; }

        public CreateContainerCommand(string name)
        {
            ContainerName = name;
        }
    }
}
