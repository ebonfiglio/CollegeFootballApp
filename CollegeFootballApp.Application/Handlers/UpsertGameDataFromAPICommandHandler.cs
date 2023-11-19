using CFBSharp.Model;
using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Services;
using MediatR;

namespace CollegeFootballApp.Application.Handlers
{
    public class UpsertGameDataFromAPICommandHandler : IRequestHandler<UpsertGameDataFromAPICommand, bool>
    {
        private readonly ICollegeFootballApiService _collegeFootballApiService;
        private readonly IGameService _gameService;

        public UpsertGameDataFromAPICommandHandler(ICollegeFootballApiService collegeFootballApiService, IGameService gameService)
        {
            _collegeFootballApiService = collegeFootballApiService;
            _gameService = gameService;
        }

        public async Task<bool> Handle(UpsertGameDataFromAPICommand request, CancellationToken cancellationToken)
        {
            try
            {
               List<Game> games = await _collegeFootballApiService.GetFBSGames(request.StartYear, request.EndYear);
                foreach (Game game in games)
                {
                   await _gameService.UpsertGameData(game);
                }
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
