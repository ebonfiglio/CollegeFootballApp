using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Infrastructure.Repositories
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
