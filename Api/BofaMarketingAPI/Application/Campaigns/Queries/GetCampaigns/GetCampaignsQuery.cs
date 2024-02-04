using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Campaigns.Queries.GetCampains
{
    public record GetCampainsQuery : IRequest<IEnumerable<Campaign>>;

    public class GetCampainsQueryHandler : IRequestHandler<GetCampainsQuery, IEnumerable<Campaign>>
    {
        private readonly IAppDbContext _context;

        public GetCampainsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Campaign>> Handle(GetCampainsQuery request, CancellationToken cancellationToken)
        {
            return   _context.Campaigns.Take(100).ToList();
        }
    }
}