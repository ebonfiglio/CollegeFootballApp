using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public class TeamRepository : GenericRepository<Team>
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
