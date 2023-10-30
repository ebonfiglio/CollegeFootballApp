using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Handlers
{
    public class UploadGameDataFromCsvCommandHandler : IRequestHandler<UploadGameDataFromCsvCommand, bool>
    {
        private readonly ICsvFileService _csvFileService;
        private readonly IUnitOfWork _unitOfWork;

        public UploadGameDataFromCsvCommandHandler(ICsvFileService csvFileService, IUnitOfWork unitOfWork)
        {
            _csvFileService = csvFileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UploadGameDataFromCsvCommand request, CancellationToken cancellationToken)
        {
            List<GameDto> gameDataDtos = _csvFileService.ReadCsvFile(request.FilePath);

            await ProcessGamesFromJson(gameDataDtos);

            return true;
        }

        public async Task ProcessGamesFromJson(List<GameDto> gameDTOs)
        {
            List<Game> games = new();
            foreach (GameDto dto in gameDTOs)
            {
                var game = await MapDtoToGame(dto);
                games.Add(game);
            }
            _unitOfWork.GameRepository.BulkInsert(games);
            _unitOfWork.SaveChanges();
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
            game.AwayTeamConference = await ProcessAwayTeamConference(dto);

            return game;
        }

        private async Task<Venue> ProcessVenue(GameDto dto)
        {
            // Handling Venue association
            Venue venue = await _unitOfWork.VenueRepository.FindSingle(v => v.Id == dto.VenueId);
            if (venue == null)
            {
                venue = new Venue { Id = dto.VenueId, Name = dto.Venue };
                await _unitOfWork.VenueRepository.Add(venue);
            }
            return venue;
        }

        private async Task<TeamConference> ProcessHomeTeamConference(GameDto dto)
        {
            // Handling Home TeamConference association
            TeamConference homeTeamConference = await _unitOfWork.TeamConferenceRepository.FindSingle(
     tc => tc.TeamId == dto.HomeId && tc.Conference.Name == dto.HomeConference,
     tc => tc.Team,
     tc => tc.Conference);

            if (homeTeamConference == null)
            {
                Team homeTeam = await _unitOfWork.TeamRepository.FindSingle(t => t.Id == dto.HomeId);
                if (homeTeam == null)
                {
                    homeTeam = new Team { Id = dto.HomeId, School = dto.HomeTeam };
                    await _unitOfWork.TeamRepository.Add(homeTeam);
                }

                Conference homeConference = await _unitOfWork.ConferenceRepository.FindSingle(c => c.Name == dto.HomeConference);
                if (homeConference == null)
                {
                    homeConference = new Conference { Name = dto.HomeConference };
                    await _unitOfWork.ConferenceRepository.Add(homeConference);
                }

                homeTeamConference = new TeamConference { TeamId = dto.HomeId, ConferenceId = homeConference.Id };
                await _unitOfWork.TeamConferenceRepository.Add(homeTeamConference);
            }
            return homeTeamConference;
        }

        private async Task<TeamConference> ProcessAwayTeamConference(GameDto dto)
        {
            // Handling Away TeamConference association
            TeamConference AwayTeamConference = await _unitOfWork.TeamConferenceRepository.FindSingle(
     tc => tc.TeamId == dto.AwayId && tc.Conference.Name == dto.AwayConference,
     tc => tc.Team,
     tc => tc.Conference);

            if (AwayTeamConference == null)
            {
                Team AwayTeam = await _unitOfWork.TeamRepository.FindSingle(t => t.Id == dto.AwayId);
                if (AwayTeam == null)
                {
                    AwayTeam = new Team { Id = dto.AwayId, School = dto.AwayTeam };
                    await _unitOfWork.TeamRepository.Add(AwayTeam);
                }

                Conference AwayConference = await _unitOfWork.ConferenceRepository.FindSingle(c => c.Name == dto.AwayConference);
                if (AwayConference == null)
                {
                    AwayConference = new Conference { Name = dto.AwayConference };
                    await _unitOfWork.ConferenceRepository.Add(AwayConference);
                }

                AwayTeamConference = new TeamConference { TeamId = dto.AwayId, ConferenceId = AwayConference.Id };
                await _unitOfWork.TeamConferenceRepository.Add(AwayTeamConference);
            }
            return AwayTeamConference;
        }

    }
}
