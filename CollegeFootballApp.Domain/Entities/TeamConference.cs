namespace CollegeFootballApp.Domain.Entities
{
    public class TeamConference
    {

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}
