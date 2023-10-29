using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public class ConferenceRepository : GenericRepository<Conference>
    {
        public ConferenceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
