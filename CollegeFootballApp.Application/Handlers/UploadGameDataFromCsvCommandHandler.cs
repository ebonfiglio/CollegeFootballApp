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
        private readonly IGameService _gameService;

        public UploadGameDataFromCsvCommandHandler(IReadFileService jsonFileService, IGameService gameService)
        {
            _jsonFileService = jsonFileService;
            _gameService = gameService;
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
               await _gameService.UpsertGameData(dto);
            }
        }
    }
}
