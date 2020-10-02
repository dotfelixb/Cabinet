using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cabinet.Server.Features.Document
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, string>
    {
        public Task<string> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.DocumentName);
        }
    }
}
