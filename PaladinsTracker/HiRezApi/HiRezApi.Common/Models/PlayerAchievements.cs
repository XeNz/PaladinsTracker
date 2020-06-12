// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PlayerAchievements : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the PlayerAchievements class.
        /// </summary>
        public PlayerAchievements()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PlayerAchievements class.
        /// </summary>
        public PlayerAchievements(string retMsg, int assistedKills = default(int), int campsCleared = default(int), int divineSpree = default(int), int doubleKills = default(int), int fireGiantKills = default(int), int firstBloods = default(int), int godLikeSpree = default(int), int goldFuryKills = default(int), int id = default(int), int immortalSpree = default(int), int killingSpree = default(int), int minionKills = default(int), string name = default(string), int pentaKills = default(int), int phoenixKills = default(int), int playerKills = default(int), int quadraKills = default(int), int rampageSpree = default(int), int shutdownSpree = default(int), int siegeJuggernautKills = default(int), int towerKills = default(int), int tripleKills = default(int), int unstoppableSpree = default(int), int wildJuggernautKills = default(int))
            : base(retMsg)
        {
            AssistedKills = assistedKills;
            CampsCleared = campsCleared;
            DivineSpree = divineSpree;
            DoubleKills = doubleKills;
            FireGiantKills = fireGiantKills;
            FirstBloods = firstBloods;
            GodLikeSpree = godLikeSpree;
            GoldFuryKills = goldFuryKills;
            Id = id;
            ImmortalSpree = immortalSpree;
            KillingSpree = killingSpree;
            MinionKills = minionKills;
            Name = name;
            PentaKills = pentaKills;
            PhoenixKills = phoenixKills;
            PlayerKills = playerKills;
            QuadraKills = quadraKills;
            RampageSpree = rampageSpree;
            ShutdownSpree = shutdownSpree;
            SiegeJuggernautKills = siegeJuggernautKills;
            TowerKills = towerKills;
            TripleKills = tripleKills;
            UnstoppableSpree = unstoppableSpree;
            WildJuggernautKills = wildJuggernautKills;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AssistedKills")]
        public int AssistedKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CampsCleared")]
        public int CampsCleared { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DivineSpree")]
        public int DivineSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DoubleKills")]
        public int DoubleKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FireGiantKills")]
        public int FireGiantKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FirstBloods")]
        public int FirstBloods { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GodLikeSpree")]
        public int GodLikeSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GoldFuryKills")]
        public int GoldFuryKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ImmortalSpree")]
        public int ImmortalSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "KillingSpree")]
        public int KillingSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MinionKills")]
        public int MinionKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PentaKills")]
        public int PentaKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PhoenixKills")]
        public int PhoenixKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PlayerKills")]
        public int PlayerKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "QuadraKills")]
        public int QuadraKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RampageSpree")]
        public int RampageSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ShutdownSpree")]
        public int ShutdownSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SiegeJuggernautKills")]
        public int SiegeJuggernautKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TowerKills")]
        public int TowerKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TripleKills")]
        public int TripleKills { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnstoppableSpree")]
        public int UnstoppableSpree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WildJuggernautKills")]
        public int WildJuggernautKills { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
