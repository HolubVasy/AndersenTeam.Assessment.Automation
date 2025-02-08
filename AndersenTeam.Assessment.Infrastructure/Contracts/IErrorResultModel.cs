using Andersen.Infrastructure.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Andersen.Infrastructure.API.Interfaces
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public interface IErrorResultModel<T> : IError<T>
         where T : System.Enum
    {
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        List<ValidationError> Errors { get; }
    }


    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public interface IError<T> where T : System.Enum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        T Code { get; set; }

        string Message { get; set; }
    }
}