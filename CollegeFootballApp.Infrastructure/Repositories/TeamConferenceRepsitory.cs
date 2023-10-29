using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public class TeamConferenceRepository : GenericRepository<TeamConference>
    {
        public TeamConferenceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
