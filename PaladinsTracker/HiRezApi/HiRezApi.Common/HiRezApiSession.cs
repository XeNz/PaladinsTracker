using System;
using Newtonsoft.Json;

namespace HiRezApi.Common
{
    public sealed class HiRezApiSession : IEquatable<HiRezApiSession>
    {
        internal HiRezApiSession(DateTime createdAt, string sessionId, Platform platform, ITimeStampProvider timeStampProvider)
        {
            Platform = platform;
            CreatedAt = createdAt;
            SessionId = sessionId;
            TimeStampProvider = timeStampProvider ?? new DateTimeUtcTimeStampProvider();
        }

        internal HiRezApiSession()
        {
        }

        [JsonProperty]
        public DateTime CreatedAt { get; private set; }

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrEmpty(SessionId)
                               && CreatedAt.AddMinutes(Constants.SESSION_EXPIRATION_TIME_MINUTES) > TimeStampProvider.ProvideTime();

        [JsonProperty]
        public Platform Platform { get; private set; }

        [JsonProperty]
        public string SessionId { get; private set; }

        [JsonIgnore]
        public ITimeStampProvider TimeStampProvider { get; set; }

        public bool Equals(HiRezApiSession other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(SessionId, other.SessionId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((HiRezApiSession) obj);
        }

        public override int GetHashCode()
        {
            return SessionId != null ? SessionId.GetHashCode() : 0;
        }

        public static bool operator ==(HiRezApiSession left, HiRezApiSession right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HiRezApiSession left, HiRezApiSession right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(CreatedAt)}: {CreatedAt}, {nameof(IsValid)}: {IsValid}, {nameof(SessionId)}: {SessionId}";
        }
    }
}