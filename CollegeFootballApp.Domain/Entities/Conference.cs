using CollegeFootballApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Entities
{
    public class Conference : IHeadToHeadCompetitor
    {
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public string? Abbreviation { get; set; }
        public string? Classification { get; set; }

        [NotMapped]
        public string Identifier => Name;
    }

}
