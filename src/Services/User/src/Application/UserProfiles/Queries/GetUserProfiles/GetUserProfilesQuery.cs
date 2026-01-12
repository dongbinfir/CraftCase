using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Application.Common.Interfaces;
using User.Domain.Entities;

namespace User.Application.UserProfiles.Queries.GetUserProfiles
{
    public record GetUserProfilesQuery : IRequest<List<UserProfile>>;

    public class GetProductsQueryHandler : IRequestHandler<GetUserProfilesQuery, List<UserProfile>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserProfile>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<UserProfile>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
