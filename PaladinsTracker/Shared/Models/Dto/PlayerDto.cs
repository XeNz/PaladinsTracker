
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PaladinsTracker.Shared.Models.Dto
{
    public class PlayerDto
    {
        [JsonProperty(PropertyName = "Created_Datetime")]
        public string CreatedDatetime { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Last_Login_Datetime")]
        public string LastLoginDatetime { get; set; }

        [JsonProperty(PropertyName = "Leaves")]
        public int Leaves { get; set; }

        [JsonProperty(PropertyName = "Level")]
        public int Level { get; set; }

        [JsonProperty(PropertyName = "Losses")]
        public int Losses { get; set; }

        [JsonProperty(PropertyName = "MasteryLevel")]
        public int MasteryLevel { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Personal_Status_Message")]
        public string PersonalStatusMessage { get; set; }

        [JsonProperty(PropertyName = "RankedConquest")]
        public RankedConquestDto RankedConquest { get; set; }

        [JsonProperty(PropertyName = "Region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "Team_Name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "Tier_Conquest")]
        public int TierConquest { get; set; }

        [JsonProperty(PropertyName = "Total_Achievements")]
        public int TotalAchievements { get; set; }

        [JsonProperty(PropertyName = "Total_Worshippers")]
        public int TotalWorshippers { get; set; }

        [JsonProperty(PropertyName = "Wins")]
        public int Wins { get; set; }
        
        public IList<MatchHistoryDto> MatchHistory { get; set; }
    }
}