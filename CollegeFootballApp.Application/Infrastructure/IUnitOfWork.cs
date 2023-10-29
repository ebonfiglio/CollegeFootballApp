using CollegeFootballApp.Domain.Entities;

namespace CollegeFootballApp.Application.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Conference> ConferenceRepository { get; }
        IRepository<Game> GameRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<Venue> VenueRepository { get; }
        IRepository<TeamConference> TeamConferenceRepository { get; }
        void SaveChanges();
    }
}
