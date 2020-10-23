using Cabinet.Server.Config;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, Result<CabinetFileInfo>>
    {
        private readonly CabinetSettings cs;

        public CreateContainerCommandHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<CabinetFileInfo>> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var path = Path.Combine(cs.DataDir, request.ContainerName);

                // does the directory already exist
                if (Directory.Exists(path))
                {
                    var message = $"container name '{request.ContainerName}' already exist";
                    return Result.Fail<CabinetFileInfo>(new Error(message));
                }

                var subdi = cs.DirectoryInfo.CreateSubdirectory(request.ContainerName);

                // was the directory created
                var cInfo = new CabinetFileInfo { CreatedAt = subdi.CreationTime, Name = subdi.Name, Path = subdi.FullName };
                return Result.Ok(cInfo);
            });
        }
    }
}