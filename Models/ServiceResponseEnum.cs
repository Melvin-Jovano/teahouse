using System.Text.Json.Serialization;

namespace teahouse.Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceResponseEnum {
        Success = 0,
        Error = 1,
        InvalidInput = 2,
        DataNotFound = 3,
        DataAlreadyExist = 4,
    }
}