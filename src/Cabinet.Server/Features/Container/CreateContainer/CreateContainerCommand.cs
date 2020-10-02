using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommand : IRequest<string>
    {
        public string ContainerName { get; set; }

        public CreateContainerCommand(string name)
        {
            ContainerName = name;
        }
    }
}
