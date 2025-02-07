using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Andersen.Infrastructure.API.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ErrorResultModel : ErrorResultModel<ErrorCode>
    {
        #region Constructors
        public ErrorResultModel(string errorMessage, ErrorCode errorCode = ErrorCode.UNEXPECTED)
            : base(errorMessage, errorCode)
        {
        }

        public ErrorResultModel(string errorMessage, ErrorCode errorCode, ModelStateDictionary modelState)
            : base(errorMessage, errorCode, modelState)
        {
        }

        public ErrorResultModel(string errorMessage, ErrorCode errorCode, List<ValidationError> error)
            : base(errorMessage, errorCode, error)
        {
        }

        public ErrorResultModel(ModelStateDictionary modelState)
            : base("Validation Failed", ErrorCode.VALIDATION_FAILED, modelState)
        {
        }
        #endregion

    }
}