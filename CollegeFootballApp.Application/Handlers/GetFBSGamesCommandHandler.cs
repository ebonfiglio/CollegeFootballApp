using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Services;
using MediatR;

namespace CollegeFootballApp.Application.Handlers
{
    public class GetFBSGamesCommandHandler : IRequestHandler<GetFBSGamesCommand, bool>
    {
        private readonly ICollegeFootballApiService _collegeFootballApiService;

        public GetFBSGamesCommandHandler(ICollegeFootballApiService collegeFootballApiService)
        {
            _collegeFootballApiService = collegeFootballApiService;
        }

        public async Task<bool> Handle(GetFBSGamesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _collegeFootballApiService.GetFBSGames(request.StartYear, request.EndYear);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
