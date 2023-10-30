using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }
        public string SeasonType { get; set; }
        public DateTime StartDate { get; set; }
        public bool StartTimeTbd { get; set; }
        public bool Completed { get; set; }
        public bool NeutralSite { get; set; }
        public bool ConferenceGame { get; set; }
        public int? Attendance { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public int HomeTeamConferenceId { get; set; }
        public TeamConference HomeTeamConference { get; set; }
        public int AwayTeamConferenceId { get; set; }
        public TeamConference AwayTeamConference { get; set; }
        public float ExcitementIndex { get; set; }
        public string Highlights { get; set; }
        public string Notes { get; set; }
    }
}
