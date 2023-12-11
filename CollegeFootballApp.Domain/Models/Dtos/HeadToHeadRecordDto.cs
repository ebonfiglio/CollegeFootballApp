using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Models.Dtos
{
    public class HeadToHeadRecordDto
    {
        public string Competitor1 { get; set; }
        public string Competitor2 { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
    }
}
