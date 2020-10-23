using Cabinet.Server.Config;
using Cabinet.Server.Extensions;
using Cabinet.Server.Model;
using FluentResults;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Result<CabinetFileInfo>>
    {
        private readonly CabinetSettings cs;

        public CreateDocumentCommandHandler(CabinetSettings cabinetSettings)
        {
            cs = cabinetSettings;
        }

        public Task<Result<CabinetFileInfo>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var dPath = Path.Combine(cs.DataDir, request.ContainerName);
                if (!Directory.Exists(dPath))
                {
                    var message = $"container name '{request.ContainerName}' does not exist";
                    return Result.Fail<CabinetFileInfo>(new Error(message));
                }

                var fPath = Path.Combine(dPath, request.DocumentName );

                var fileExist = File.Exists(fPath);

                // override is off but file already exist
                if (!request.OverRide && fileExist)
                {
                    return Result.Fail<CabinetFileInfo>(new Error($"file '{request.DocumentName}' already exist!"));
                }

                // override is on and file already exist
                if (request.OverRide && fileExist)
                {
                    try
                    {
                        File.Delete(fPath);
                    }
                    catch (Exception ex)
                    {
                        return Result.Fail<CabinetFileInfo>(new Error(ex.Message));
                    }
                }

                using var stream = new FileStream(fPath, FileMode.Create);
                await request.FromFile.CopyToAsync(stream);

                var cfInfo = new CabinetFileInfo
                {
                    Name = request.DocumentName,
                    Path = fPath,
                    Size = request.FromFile.Length,
                    ContainerName = request.ContainerName,
                    DocumentName = request.DocumentName,
                    MimeType = request.FromFile.ContentType,
                    CreatedAt = DateTime.UtcNow,
                };

                return Result.Ok(cfInfo);
            });
        }
    }
}