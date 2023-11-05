using Newtonsoft.Json;
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

        [JsonProperty("Season Type")]
        public string SeasonType { get; set; }

        [JsonProperty("Start Date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("Start Time Tbd")]
        public bool? StartTimeTbd { get; set; }

        public bool? Completed { get; set; }

        [JsonProperty("Neutral Site")]
        public bool? NeutralSite { get; set; }

        [JsonProperty("Conference Game")]
        public bool? ConferenceGame { get; set; }

        public int? Attendance { get; set; }

        [JsonProperty("Venue Id")]
        public int? VenueId { get; set; }

        public string Venue { get; set; }

        [JsonProperty("Home Id")]
        public int HomeId { get; set; }

        [JsonProperty("Home Team")]
        public string HomeTeam { get; set; }

        [JsonProperty("Home Conference")]
        public string HomeConference { get; set; }

        [JsonProperty("Home Division")]
        public string? HomeDivision { get; set; }

        [JsonProperty("Home Points")]
        public int? HomePoints { get; set; }

        // Assuming HomeLineScores is an array in the JSON, but if it's not, you would need to individually map each one as was shown previously.
        [JsonProperty("Home Line Scores")]
        public List<int>? HomeLineScores { get; set; }

        [JsonProperty("Home Post Win Prob")]
        public double? HomePostWinProb { get; set; }

        [JsonProperty("Home Pregame Elo")]
        public int? HomePregameElo { get; set; }

        [JsonProperty("Home Postgame Elo")]
        public int? HomePostgameElo { get; set; }

        [JsonProperty("Away Id")]
        public int AwayId { get; set; }

        [JsonProperty("Away Team")]
        public string AwayTeam { get; set; }

        [JsonProperty("Away Conference")]
        public string? AwayConference { get; set; }

        [JsonProperty("Away Division")]
        public string? AwayDivision { get; set; }

        [JsonProperty("Away Points")]
        public int? AwayPoints { get; set; }

        // Similarly for AwayLineScores
        [JsonProperty("Away Line Scores")]
        public List<int>? AwayLineScores { get; set; }

        [JsonProperty("Away Post Win Prob")]
        public double? AwayPostWinProb { get; set; }

        [JsonProperty("Away Pregame Elo")]
        public int? AwayPregameElo { get; set; }

        [JsonProperty("Away Postgame Elo")]
        public int? AwayPostgameElo { get; set; }

        [JsonProperty("Excitement Index")]
        public double? ExcitementIndex { get; set; }

        public string? Highlights { get; set; }

        public string? Notes { get; set; }
    }
}
