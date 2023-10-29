using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public string Timezone { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }
        public int Capacity { get; set; }
        public int YearConstructed { get; set; }
        public bool Grass { get; set; }
        public bool Dome { get; set; }
    }

}
