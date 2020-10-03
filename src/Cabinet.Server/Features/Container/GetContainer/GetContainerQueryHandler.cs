using Cabinet.Server.Config;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Container
{
    public class GetContainerQueryHandler : IRequestHandler<GetContainerQuery, Result<ContainerInfo>>
    {
        private readonly CabinetSettings cs;

        public GetContainerQueryHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<ContainerInfo>> Handle(GetContainerQuery request, CancellationToken cancellationToken)
        {
            var path = Path.Combine(cs.DataDir, request.ContainerName);
            if (!Directory.Exists(path))
            {
                var message = $"container name '{request.ContainerName}' does not exist";
                return Task.FromResult(Result.Fail<ContainerInfo>(new Error(message)));
            }

            var dir = new DirectoryInfo(path);
            // use auto mapper
            var cInfo = new ContainerInfo { CreatedAt = dir.CreationTime, Name = dir.Name, Path = dir.FullName };

            return Task.FromResult(Result.Ok(cInfo));
        }
    }
}
