using CollegeFootballApp.Application.Commands;
using CollegeFootballApp.Application.Infrastructure;
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
    public class UpsertTeamCommandHandler : IRequestHandler<UpsertTeamCommand, Team>
    {
        private readonly IReadFileService _jsonFileService;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTeamCommandHandler(IReadFileService jsonFileService, IUnitOfWork unitOfWork)
        {
            _jsonFileService = jsonFileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Team>> Handle(UpsertTeamCommand request, CancellationToken cancellationToken)
        {
            var teamDtos = _jsonFileService.ReadTeamFile(request.FilePath);
            var teams = new List<Team>();

            foreach (var dto in teamDtos)
            {
                var team = await _unitOfWork.TeamRepository.GetByIdAsync(dto.Id);
                if (team == null)
                {
                    team = new Team { Id = dto.Id };
                    await _unitOfWork.TeamRepository.AddAsync(team);
                }

                team.School = dto.School;
                team.Mascot = dto.Mascot;
                team.Abbreviation = dto.Abbreviation;
                team.AltName1 = dto.AltName1;
                team.AltName2 = dto.AltName2;
                team.AltName3 = dto.AltName3;
                team.Classification = dto.Classification;
                team.Color = dto.Color;
                team.AltColor = dto.AltColor;
                team.Logos = String.Join(";", dto.Logos);
                team.Twitter = dto.Twitter;

                _unitOfWork.TeamRepository.Update(team); // This is called regardless of add or update operation.
                teams.Add(team);
            }

            _unitOfWork.SaveChanges();
            return teams;
        }
    }
}

}
