using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Models.Dtos
{
    public class GameDto
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
        public string Venue { get; set; }
        public int HomeId { get; set; }
        public string HomeTeam { get; set; }
        public string HomeConference { get; set; }
        public string HomeDivision { get; set; }
        public int HomePoints { get; set; }
        public List<int> HomeLineScores { get; set; }
        public double HomePostWinProb { get; set; }
        public int? HomePregameElo { get; set; }
        public int? HomePostgameElo { get; set; }
        public int AwayId { get; set; }
        public string AwayTeam { get; set; }
        public string AwayConference { get; set; }
        public string AwayDivision { get; set; }
        public int AwayPoints { get; set; }
        public List<int> AwayLineScores { get; set; }
        public double AwayPostWinProb { get; set; }
        public int? AwayPregameElo { get; set; }
        public int? AwayPostgameElo { get; set; }
        public double? ExcitementIndex { get; set; }
        public string Highlights { get; set; }
        public string Notes { get; set; }
    }
}
