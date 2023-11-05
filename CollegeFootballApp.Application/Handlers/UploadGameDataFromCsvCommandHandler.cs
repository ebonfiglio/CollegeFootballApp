using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Domain.Entities;
using MediatR;

namespace CollegeFootballApp.Application.Handlers
{
    public class UploadGameDataFromCsvCommandHandler : IRequestHandler<UploadGameDataFromCsvCommand, bool>
    {
        private readonly IReadFileService _jsonFileService;
        private readonly IUnitOfWork _unitOfWork;

        public UploadGameDataFromCsvCommandHandler(IReadFileService jsonFileService, IUnitOfWork unitOfWork)
        {
            _jsonFileService = jsonFileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UploadGameDataFromCsvCommand request, CancellationToken cancellationToken)
        {
            List<GameDto> gameDataDtos = _jsonFileService.ReadFile<GameDto>(request.FilePath);

            await ProcessGamesFromJson(gameDataDtos);

            return true;
        }

        public async Task ProcessGamesFromJson(List<GameDto> gameDTOs)
        {
            List<Game> games = new();
            foreach (GameDto dto in gameDTOs)
            {
                Game game = await MapDtoToGame(dto);
                await _unitOfWork.GameRepository.AddAsync(game);
                _unitOfWork.SaveChanges();
                //games.Add(game);
            }
            //_unitOfWork.GameRepository.BulkInsert(games);
            //_unitOfWork.SaveChanges();
        }

        private async Task<Game> MapDtoToGame(GameDto dto)
        {
            Game game = new()
            {
                Id = dto.Id,
                Season = dto.Season,
                Week = dto.Week,
                SeasonType = dto.SeasonType,
                StartDate = dto.StartDate,
                StartTimeTbd = dto.StartTimeTbd,
                Completed = dto.Completed,
                NeutralSite = dto.NeutralSite,
                ConferenceGame = dto.ConferenceGame,
                Attendance = dto.Attendance,
                VenueId = dto.VenueId,
                ExcitementIndex = dto.ExcitementIndex.HasValue ? (float)dto.ExcitementIndex : 0,
                Highlights = dto.Highlights,
                Notes = dto.Notes
            };

            game.Venue = await ProcessVenue(dto);
            game.HomeTeamConference = await ProcessHomeTeamConference(dto);
            game.AwayTeamConference = await ProcessAwayTeamConference(dto, game.HomeTeamConference?.Conference);

            return game;
        }

        private async Task<Venue> ProcessVenue(GameDto dto)
        {
            // Handling Venue association
            Venue venue = await _unitOfWork.VenueRepository.FindSingleAsync(v => v.Id == dto.VenueId);
            if (venue == null)
            {
                venue = new Venue { Id = dto.VenueId, Name = dto.Venue };
                await _unitOfWork.VenueRepository.AddAsync(venue);
            }
            _unitOfWork.SaveChanges();
            return venue;
        }

        private async Task<TeamConference> ProcessHomeTeamConference(GameDto dto)
        {
            // Handling Home TeamConference association
            TeamConference homeTeamConference = await _unitOfWork.TeamConferenceRepository.FindSingleAsync(
     tc => tc.TeamId == dto.HomeId && tc.Conference.Name == dto.HomeConference,
     tc => tc.Team,
     tc => tc.Conference);

            if (homeTeamConference == null)
            {
                Team homeTeam = await _unitOfWork.TeamRepository.FindSingleAsync(t => t.Id == dto.HomeId);
                if (homeTeam == null)
                {
                    homeTeam = new Team { Id = dto.HomeId, School = dto.HomeTeam };
                    await _unitOfWork.TeamRepository.AddAsync(homeTeam);
                    _unitOfWork.SaveChanges();
                }

                Conference homeConference = await _unitOfWork.ConferenceRepository.FindSingleAsync(c => c.Name == dto.HomeConference);
                if (homeConference == null)
                {
                    homeConference = new Conference { Name = dto.HomeConference };
                    await _unitOfWork.ConferenceRepository.AddAsync(homeConference);
                    _unitOfWork.SaveChanges();
                }

                homeTeamConference = new TeamConference { TeamId = dto.HomeId, ConferenceName = homeConference.Name };
                await _unitOfWork.TeamConferenceRepository.AddAsync(homeTeamConference);
                _unitOfWork.SaveChanges();
            }
            return homeTeamConference;
        }

        private async Task<TeamConference> ProcessAwayTeamConference(GameDto dto, Conference homeConference)
        {
            // Always handle the away team logic.
            Team awayTeam = await _unitOfWork.TeamRepository.FindSingleAsync(t => t.Id == dto.AwayId);
            if (awayTeam == null)
            {
                awayTeam = new Team { Id = dto.AwayId, School = dto.AwayTeam };
                await _unitOfWork.TeamRepository.AddAsync(awayTeam);
                _unitOfWork.SaveChanges();
            }

            // Check if the away conference is the same as the home conference.
            Conference awayConference;
            if (dto.AwayConference == dto.HomeConference)
            {
                // If the same, reuse the home conference entity.
                awayConference = homeConference;
            }
            else
            {
                // If different, fetch or create the away conference.
                awayConference = await _unitOfWork.ConferenceRepository.FindSingleAsync(c => c.Name == dto.AwayConference);
                if (awayConference == null)
                {
                    awayConference = new Conference { Name = dto.AwayConference };
                    await _unitOfWork.ConferenceRepository.AddAsync(awayConference);
                    _unitOfWork.SaveChanges();
                }
            }

            // Create or find the away team conference association.
            TeamConference awayTeamConference = await _unitOfWork.TeamConferenceRepository.FindSingleAsync(
                tc => tc.TeamId == dto.AwayId && tc.ConferenceName == awayConference.Name);

            if (awayTeamConference == null)
            {
                awayTeamConference = new TeamConference { TeamId = dto.AwayId, ConferenceName = awayConference.Name };
                await _unitOfWork.TeamConferenceRepository.AddAsync(awayTeamConference);
                _unitOfWork.SaveChanges();
            }

            return awayTeamConference;
        }

    }
}
