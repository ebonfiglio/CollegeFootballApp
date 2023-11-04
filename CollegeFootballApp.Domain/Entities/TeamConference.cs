namespace CollegeFootballApp.Domain.Entities
{
    public class TeamConference
    {

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public string ConferenceName { get; set; }
        public Conference Conference { get; set; }
    }
}
