using Cabinet.Server.Config;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Result<CabinetFileInfo>>
    {
        private readonly CabinetSettings cs;

        public GetDocumentQueryHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<CabinetFileInfo>> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var dPath = Path.Combine(cs.DataDir, request.ContainerName);
                if (!Directory.Exists(dPath))
                {
                    var message = $"container name '{request.ContainerName}' does not exist";
                    return Result.Fail<CabinetFileInfo>(new Error(message));
                }

                var fPath = Path.Combine(dPath, request.DocumentName);
                if (!File.Exists(fPath))
                {
                    var message = $"file name '{request.ContainerName}' does not exist";
                    return Result.Fail<CabinetFileInfo>(new Error(message));
                }

                var cfInfo = new CabinetFileInfo
                {
                    CreatedAt = File.GetCreationTimeUtc(fPath),
                    Name = request.DocumentName,
                    MimeType = Path.GetExtension(fPath),
                    Path = fPath
                };

                return Result.Ok(cfInfo);
            });
        }
    }
}