// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class DataUsed : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the DataUsed class.
        /// </summary>
        public DataUsed()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DataUsed class.
        /// </summary>
        public DataUsed(string retMsg, int activeSessions = default(int), int concurrentSessions = default(int), int requestLimitDaily = default(int), int sessionCap = default(int), int sessionTimeLimit = default(int), int totalRequestsToday = default(int), int totalSessionsToday = default(int))
            : base(retMsg)
        {
            ActiveSessions = activeSessions;
            ConcurrentSessions = concurrentSessions;
            RequestLimitDaily = requestLimitDaily;
            SessionCap = sessionCap;
            SessionTimeLimit = sessionTimeLimit;
            TotalRequestsToday = totalRequestsToday;
            TotalSessionsToday = totalSessionsToday;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Active_Sessions")]
        public int ActiveSessions { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Concurrent_Sessions")]
        public int ConcurrentSessions { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Request_Limit_Daily")]
        public int RequestLimitDaily { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Session_Cap")]
        public int SessionCap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Session_Time_Limit")]
        public int SessionTimeLimit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Total_Requests_Today")]
        public int TotalRequestsToday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Total_Sessions_Today")]
        public int TotalSessionsToday { get; set; }

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
