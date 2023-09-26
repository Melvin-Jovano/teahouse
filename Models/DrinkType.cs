using System.Text.Json.Serialization;

namespace teahouse.Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DrinkType {
        Cold = 0,
        Hot = 1,
        Normal = 2
    }
}