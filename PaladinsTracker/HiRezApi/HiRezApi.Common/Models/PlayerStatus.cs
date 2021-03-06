// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PlayerStatus : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the PlayerStatus class.
        /// </summary>
        public PlayerStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PlayerStatus class.
        /// </summary>
        public PlayerStatus(string retMsg, int match = default(int), object personalStatusMessage = default(object), int status = default(int), string statusString = default(string))
            : base(retMsg)
        {
            Match = match;
            PersonalStatusMessage = personalStatusMessage;
            Status = status;
            StatusString = statusString;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Match")]
        public int Match { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "personal_status_message")]
        public object PersonalStatusMessage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status_string")]
        public string StatusString { get; set; }

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
