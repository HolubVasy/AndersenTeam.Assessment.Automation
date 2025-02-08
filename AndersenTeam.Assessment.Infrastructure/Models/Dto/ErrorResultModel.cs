using Andersen.Infrastructure.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AndersenTeam.Assessment.Infrastructure.Models.Dto
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