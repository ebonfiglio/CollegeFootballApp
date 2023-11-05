using CollegeFootballApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Commands
{
    public class UpsertTeamCommand : IRequest<Team>
    {
        public TeamUpsertDto TeamDto { get; set; }

        public UpsertTeamCommand(TeamUpsertDto teamDto)
        {
            TeamDto = teamDto;
        }
    }

}
