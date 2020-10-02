using MediatR;

namespace Cabinet.Server.Features.Container
{
    public class GetContainerQuery : IRequest<string>
    {
        public string ContainerName { get; set; }

        public GetContainerQuery(string name)
        {
            ContainerName = name;
        }
    }
}
