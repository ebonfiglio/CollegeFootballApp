using CollegeFootballApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Entities
{
    public class Team : IHeadToHeadCompetitor
    {
        public int Id { get; set; }
        public string? School { get; set; }
        public string? Mascot { get; set; }
        public string? Abbreviation { get; set; }
        public string? AltName1 { get; set; }
        public string? AltName2 { get; set; }
        public string? AltName3 { get; set; }
        public string? Classification { get; set; }
        public string? Color { get; set; }
        public string? AltColor { get; set; }
        public string? Logos { get; set; }
        public string? Twitter { get; set; }

        [NotMapped]
        public string Identifier => Id.ToString();
    }

}
