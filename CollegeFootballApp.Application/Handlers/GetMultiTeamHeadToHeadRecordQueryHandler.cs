using CollegeFootballApp.Application.Infrastructure;
using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Application.Queries;
using CollegeFootballApp.Application.Services;
using CollegeFootballApp.Domain.Models.Dtos;
using CollegeFootballApp.Domain.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Handlers
{
    public class GetMultiTeamHeadToHeadRecordQueryHandler : IRequestHandler<GetMultiTeamHeadToHeadRecordQuery, MultiTeamHeadToHeadRecordDto>
    {
        private readonly IHeadToHeadRecordService _teamRecordService;
        private readonly IGameService _gameService;

        public GetMultiTeamHeadToHeadRecordQueryHandler(IHeadToHeadRecordService teamRecordService, IGameService gameService)
        {
            _teamRecordService = teamRecordService;
            _gameService = gameService;
        }

        public async Task<MultiTeamHeadToHeadRecordDto> Handle(GetMultiTeamHeadToHeadRecordQuery request, CancellationToken cancellationToken)
        {
            // Fetch games involving all specified teams
            var games = await _gameService.GetGamesByMultipleTeamsAsync(request.TeamNames);

            // Calculate head-to-head record for each pair of teams
            return await _teamRecordService.CalculateHeadToHeadRecordAsync(games, request.TeamIds);
        }
    }
}
