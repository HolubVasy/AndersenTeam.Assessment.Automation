using Newtonsoft.Json;

namespace Andersen.Infrastructure.API.Models
{
    public class ValidationError
    {
        [JsonProperty("field")]
        public string Field { get; }

        [JsonProperty("message")]
        public string Message { get; }

        public bool IsWarning { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }

        public ValidationError(string field, string message, bool isWarning)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
            IsWarning = isWarning;
        }
    }
}