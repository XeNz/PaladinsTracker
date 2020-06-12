using Newtonsoft.Json;

namespace PaladinsTracker.Shared.Models.Dto
{
    public class MatchHistoryDto
    {
        
    [JsonProperty(PropertyName = "ActiveId1")]
    public int ActiveId1 { get; set; }

    [JsonProperty(PropertyName = "ActiveId2")]
    public int ActiveId2 { get; set; }

    [JsonProperty(PropertyName = "ActiveId3")]
    public int ActiveId3 { get; set; }

    [JsonProperty(PropertyName = "ActiveId4")]
    public int ActiveId4 { get; set; }

    [JsonProperty(PropertyName = "Active_1")]
    public string Active1 { get; set; }

    [JsonProperty(PropertyName = "Active_2")]
    public string Active2 { get; set; }

    [JsonProperty(PropertyName = "Active_3")]
    public string Active3 { get; set; }

    [JsonProperty(PropertyName = "Active_4")]
    public string Active4 { get; set; }

    [JsonProperty(PropertyName = "Assists")]
    public int Assists { get; set; }

    [JsonProperty(PropertyName = "Champion")]
    public string Champion { get; set; }

    [JsonProperty(PropertyName = "ChampionId")]
    public int ChampionId { get; set; }

    [JsonProperty(PropertyName = "Creeps")]
    public int Creeps { get; set; }

    [JsonProperty(PropertyName = "Damage")]
    public int Damage { get; set; }

    [JsonProperty(PropertyName = "Damage_Bot")]
    public int DamageBot { get; set; }

    [JsonProperty(PropertyName = "Damage_Done_In_Hand")]
    public int DamageDoneInHand { get; set; }

    [JsonProperty(PropertyName = "Damage_Mitigated")]
    public int DamageMitigated { get; set; }

    [JsonProperty(PropertyName = "Damage_Structure")]
    public int DamageStructure { get; set; }

    [JsonProperty(PropertyName = "Damage_Taken")]
    public int DamageTaken { get; set; }

    [JsonProperty(PropertyName = "Damage_Taken_Magical")]
    public int DamageTakenMagical { get; set; }

    [JsonProperty(PropertyName = "Damage_Taken_Physical")]
    public int DamageTakenPhysical { get; set; }

    [JsonProperty(PropertyName = "Deaths")]
    public int Deaths { get; set; }

    [JsonProperty(PropertyName = "Distance_Traveled")]
    public int DistanceTraveled { get; set; }

    [JsonProperty(PropertyName = "Gold")]
    public int Gold { get; set; }

    [JsonProperty(PropertyName = "Healing")]
    public int Healing { get; set; }

    [JsonProperty(PropertyName = "Healing_Bot")]
    public int HealingBot { get; set; }

    [JsonProperty(PropertyName = "Healing_Player_Self")]
    public int HealingPlayerSelf { get; set; }

    [JsonProperty(PropertyName = "ItemId1")]
    public int ItemId1 { get; set; }

    [JsonProperty(PropertyName = "ItemId2")]
    public int ItemId2 { get; set; }

    [JsonProperty(PropertyName = "ItemId3")]
    public int ItemId3 { get; set; }

    [JsonProperty(PropertyName = "ItemId4")]
    public int ItemId4 { get; set; }

    [JsonProperty(PropertyName = "ItemId5")]
    public int ItemId5 { get; set; }

    [JsonProperty(PropertyName = "ItemId6")]
    public int ItemId6 { get; set; }

    [JsonProperty(PropertyName = "Item_1")]
    public string Item1 { get; set; }

    [JsonProperty(PropertyName = "Item_2")]
    public string Item2 { get; set; }

    [JsonProperty(PropertyName = "Item_3")]
    public string Item3 { get; set; }

    [JsonProperty(PropertyName = "Item_4")]
    public string Item4 { get; set; }

    [JsonProperty(PropertyName = "Item_5")]
    public string Item5 { get; set; }

    [JsonProperty(PropertyName = "Item_6")]
    public string Item6 { get; set; }

    [JsonProperty(PropertyName = "Killing_Spree")]
    public int KillingSpree { get; set; }

    [JsonProperty(PropertyName = "Kills")]
    public int Kills { get; set; }

    [JsonProperty(PropertyName = "Level")]
    public int Level { get; set; }

    [JsonProperty(PropertyName = "Map_Game")]
    public string MapGame { get; set; }

    [JsonProperty(PropertyName = "Match")]
    public int Match { get; set; }

    [JsonProperty(PropertyName = "Match_Time")]
    public string MatchTime { get; set; }

    [JsonProperty(PropertyName = "Minutes")]
    public int Minutes { get; set; }

    [JsonProperty(PropertyName = "Multi_kill_Max")]
    public int MultiKillMax { get; set; }

    [JsonProperty(PropertyName = "Objective_Assists")]
    public int ObjectiveAssists { get; set; }

    [JsonProperty(PropertyName = "Queue")]
    public string Queue { get; set; }

    [JsonProperty(PropertyName = "Region")]
    public string Region { get; set; }

    [JsonProperty(PropertyName = "Skin")]
    public string Skin { get; set; }

    [JsonProperty(PropertyName = "SkinId")]
    public int SkinId { get; set; }

    [JsonProperty(PropertyName = "Surrendered")]
    public int Surrendered { get; set; }

    [JsonProperty(PropertyName = "TaskForce")]
    public int TaskForce { get; set; }

    [JsonProperty(PropertyName = "Team1Score")]
    public int Team1Score { get; set; }

    [JsonProperty(PropertyName = "Team2Score")]
    public int Team2Score { get; set; }

    [JsonProperty(PropertyName = "Time_In_Match_Seconds")]
    public int TimeInMatchSeconds { get; set; }

    [JsonProperty(PropertyName = "Wards_Placed")]
    public int WardsPlaced { get; set; }

    [JsonProperty(PropertyName = "Win_Status")]
    public string WinStatus { get; set; }

    [JsonProperty(PropertyName = "Winning_TaskForce")]
    public int WinningTaskForce { get; set; }

    [JsonProperty(PropertyName = "playerName")]
    public string PlayerName { get; set; }
    }
}