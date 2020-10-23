using Cabinet.Server.Config;
using Cabinet.Server.Extensions;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentInfoQueryHandler : IRequestHandler<GetDocumentInfoQuery, Result<CabinetFileInfo>>
    {
        private readonly CabinetSettings cs;

        public GetDocumentInfoQueryHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<CabinetFileInfo>> Handle(GetDocumentInfoQuery request, CancellationToken cancellationToken)
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

                var file = new FileInfo(fPath);

                var cfInfo = new CabinetFileInfo
                {
                    Name = file.Name,
                    Path = file.FullName,
                    Size = file.Length,
                    ContainerName = request.ContainerName,
                    DocumentName = request.DocumentName,
                    MimeType = file.Extension.ToMimeType(cs.MimeTypes),
                    CreatedAt = file.CreationTimeUtc,
                };

                return Result.Ok(cfInfo);
            });
        }
    }
}