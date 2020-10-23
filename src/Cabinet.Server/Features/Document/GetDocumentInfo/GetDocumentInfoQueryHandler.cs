﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentInfoQueryHandler : IRequestHandler<GetDocumentInfoQuery, string>
    {
        public Task<string> Handle(GetDocumentInfoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.DocumentName);
        }
    }
}