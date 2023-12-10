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
        public string? SeasonType { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? StartTimeTbd { get; set; }
        public bool? Completed { get; set; }
        public bool? NeutralSite { get; set; }
        public bool? ConferenceGame { get; set; }
        public int? Attendance { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        // Composite foreign keys for HomeTeamConference
        public int HomeId { get; set; }
        public string HomeConferenceName { get; set; }
        public TeamConference HomeTeamConference { get; set; }

        // Composite foreign keys for AwayTeamConference
        public int AwayTeamId { get; set; }
        public string AwayConferenceName { get; set; }
        public TeamConference AwayTeamConference { get; set; }
        public float? ExcitementIndex { get; set; }
        public string? Highlights { get; set; }
        public string? Notes { get; set; }

        public string? HomeDivision { get; set; }

        public int? HomePoints { get; set; }

        public string? HomeLineScores { get; set; }

        public double? HomePostWinProb { get; set; }

        public int? HomePregameElo { get; set; }

        public int? HomePostgameElo { get; set; }

        public string? AwayDivision { get; set; }

        public int? AwayPoints { get; set; }

        public string? AwayLineScores { get; set; }

        public double? AwayPostWinProb { get; set; }

        public int? AwayPregameElo { get; set; }

        public int? AwayPostgameElo { get; set; }
    }
}
