using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Models.Dtos
{
    public class MultiTeamHeadToHeadRecordDto
    {
        // Key: Team Id, Value: Records against other teams
        public Dictionary<int, TeamRecordDto> TeamRecords { get; set; }
    }
}
