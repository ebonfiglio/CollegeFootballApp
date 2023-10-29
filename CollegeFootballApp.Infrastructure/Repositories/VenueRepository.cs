using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public class VenueRepository : GenericRepository<Venue>
    {
        public VenueRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
