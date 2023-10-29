namespace CollegeFootballApp.Domain.Entities
{
    public class TeamConference
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
