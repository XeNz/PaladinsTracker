// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Ability
    {
        /// <summary>
        /// Initializes a new instance of the Ability class.
        /// </summary>
        public Ability()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Ability class.
        /// </summary>
        public Ability(string description = default(string), int id = default(int), string summary = default(string), string uRL = default(string))
        {
            Description = description;
            Id = id;
            Summary = summary;
            URL = uRL;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Summary")]
        public string Summary { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "URL")]
        public string URL { get; set; }

    }
}
