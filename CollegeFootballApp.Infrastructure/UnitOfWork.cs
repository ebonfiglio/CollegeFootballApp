using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Domain.Entities;
using CollegeFootballApp.Infrastructure.Repositories;

namespace CollegeFootballApp.Infrastructure
{
    

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private IRepository<Conference> conferenceRepository;
        public IRepository<Conference> ConferenceRepository
        {
            get
            {
                if (conferenceRepository == null)
                {
                    conferenceRepository = new ConferenceRepository(context);
                }
                return conferenceRepository;
            }
        }

        private IRepository<Game> gameRepository;
        public IRepository<Game> GameRepository
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new GameRepository(context);
                }
                return gameRepository;
            }
        }

        private IRepository<Team> teamRepository;
        public IRepository<Team> TeamRepository
        {
            get
            {
                if (teamRepository == null)
                {
                    teamRepository = new TeamRepository(context);
                }
                return teamRepository;
            }
        }

        private IRepository<Venue> venueRepository;
        public IRepository<Venue> VenueRepository
        {
            get
            {
                if (venueRepository == null)
                {
                    venueRepository = new VenueRepository(context);
                }
                return venueRepository;
            }
        }

        private IRepository<TeamConference> teamConferenceRepository;
        public IRepository<TeamConference> TeamConferenceRepository
        {
            get
            {
                if (teamConferenceRepository == null)
                {
                    teamConferenceRepository = new TeamConferenceRepository(context);
                }
                return teamConferenceRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

}
