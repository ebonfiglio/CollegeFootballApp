using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Models.Dtos
{
    public class TeamRecordDto
    {
        // Key: Opposing Team ID, Value: Head to Head Record
        public Dictionary<string, HeadToHeadRecordDto> Records { get; set; }
    }
}
