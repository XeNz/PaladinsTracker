using Newtonsoft.Json;

namespace PaladinsTracker.Shared.Models.Dto
{
    public class RankedConquestDto
    {
        
        [JsonProperty(PropertyName = "Leaves")]
        public int Leaves { get; set; }

        [JsonProperty(PropertyName = "Losses")]
        public int Losses { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Points")]
        public int Points { get; set; }

        [JsonProperty(PropertyName = "PrevRank")]
        public int PrevRank { get; set; }

        [JsonProperty(PropertyName = "Rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "Rank_Stat_Conquest")]
        public object RankStatConquest { get; set; }

        [JsonProperty(PropertyName = "Rank_Stat_Duel")]
        public object RankStatDuel { get; set; }

        [JsonProperty(PropertyName = "Rank_Stat_Joust")]
        public object RankStatJoust { get; set; }

        [JsonProperty(PropertyName = "Season")]
        public int Season { get; set; }

        [JsonProperty(PropertyName = "Tier")]
        public int Tier { get; set; }

        [JsonProperty(PropertyName = "Trend")]
        public int Trend { get; set; }

        [JsonProperty(PropertyName = "Wins")]
        public int Wins { get; set; }

        [JsonProperty(PropertyName = "player_id")]
        public int PlayerId { get; set; }

        [JsonProperty(PropertyName = "ret_msg")]
        public string RetMsg { get; set; }
    }
}