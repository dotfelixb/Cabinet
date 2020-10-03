using Cabinet.Server.Config;
using Cabinet.Server.Extensions;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, Result<ContainerInfo>>
    {
        private readonly CabinetSettings cs;

        public CreateContainerCommandHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<ContainerInfo>> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            var path = Path.Combine(cs.DataDir, request.ContainerName);
           
            // does the directory already exist
            if (Directory.Exists(path))
            {
                var message = $"container name '{request.ContainerName}' already exist";
                return Task.FromResult(Result.Fail<ContainerInfo>(new Error(message)));
            }

            var subdi = cs.DirectoryInfo.CreateSubdirectory(request.ContainerName);

            // was the directory created
            var cInfo = new ContainerInfo { CreatedAt = subdi.CreationTime, Name = subdi.Name, Path = subdi.FullName };
            return Task.FromResult(Result.Ok(cInfo));
        }
    }
}
