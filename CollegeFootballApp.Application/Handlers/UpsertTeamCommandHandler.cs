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
    public class UpsertTeamCommandHandler : IRequestHandler<UpsertTeamCommand, bool>
    {
        private readonly IReadFileService _jsonFileService;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTeamCommandHandler(IReadFileService jsonFileService, IUnitOfWork unitOfWork)
        {
            _jsonFileService = jsonFileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpsertTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<TeamUpsertDto> teamDtos = _jsonFileService.ReadFile<TeamUpsertDto>(request.FilePath);
                List<Team> teams = new();

                foreach (TeamUpsertDto dto in teamDtos)
                {
                    Team team = await _unitOfWork.TeamRepository.GetByIdAsync(dto.Id);
                    if (team == null)
                    {
                        team = new Team { Id = dto.Id };
                        await _unitOfWork.TeamRepository.AddAsync(team);
                        _unitOfWork.SaveChanges();
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
                    team.Logos = $"{dto.PrimaryLogo},{dto.SecondaryLogo}";
                    team.Twitter = dto.Twitter;

                    await _unitOfWork.TeamRepository.UpdateAsync(team); // This is called regardless of add or update operation.
                    teams.Add(team);
                }

                _unitOfWork.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}