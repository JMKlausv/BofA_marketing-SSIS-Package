using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Campaigns.Queries.GetCampains
{
    public record ExecuteSSISPackageCommand : IRequest<string>;

    public class ExecuteSSISPackageCommandHandler : IRequestHandler<ExecuteSSISPackageCommand, String>
    {
        private readonly ISSISManager _manager;

        public ExecuteSSISPackageCommandHandler(ISSISManager manager)
        {
            _manager = manager;
        }
        public async Task<String> Handle(ExecuteSSISPackageCommand request, CancellationToken cancellationToken)
        {
               _manager.ExecuteSSISPackage();
               return "Fighting , ";
        }
    }
}