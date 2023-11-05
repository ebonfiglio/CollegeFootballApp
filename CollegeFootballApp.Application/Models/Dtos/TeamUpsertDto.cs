using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Application.Models.Dtos
{
    internal class TeamUpsertDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("School")]
        public string School { get; set; }

        [JsonProperty("Mascot")]
        public string Mascot { get; set; }

        [JsonProperty("Abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("Alt Name1")]
        public string AltName1 { get; set; }

        [JsonProperty("Alt Name2")]
        public string AltName2 { get; set; }

        [JsonProperty("Alt Name3")]
        public string AltName3 { get; set; }

        [JsonProperty("Conference")]
        public string Conference { get; set; }

        [JsonProperty("Classification")]
        public string Classification { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("Alt Color")]
        public string AltColor { get; set; }

        [JsonProperty("Logos[0]")]
        public string PrimaryLogo { get; set; }

        [JsonProperty("Logos[1]")]
        public string SecondaryLogo { get; set; }

        [JsonProperty("Twitter")]
        public string Twitter { get; set; }
    }
}
