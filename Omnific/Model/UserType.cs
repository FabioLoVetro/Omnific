using System.Text.Json.Serialization;

namespace Omnific.Model
{
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum UserType
        {
            Viewer,
            Creator,
            Administrator
        }
}
