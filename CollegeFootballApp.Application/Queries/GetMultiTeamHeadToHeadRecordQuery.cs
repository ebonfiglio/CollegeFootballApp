using CollegeFootballApp.Application.Models.Dtos;
using CollegeFootballApp.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Queries
{
    public class GetMultiTeamHeadToHeadRecordQuery : IRequest<MultiTeamHeadToHeadRecordDto>
    {
        public List<int> TeamIds { get; set; }
    }
}
