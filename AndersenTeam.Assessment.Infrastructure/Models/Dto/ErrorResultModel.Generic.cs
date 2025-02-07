using System.Collections.Generic;
using System.Linq;
using Andersen.Infrastructure.API.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Andersen.Infrastructure.API.Models;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class ErrorResultModel<T> : IErrorResultModel<T>
where T : System.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public T Code { get; set; }
    
    public string Message { get; set; }
    
    [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
    public List<ValidationError> Errors { get; }
    
    
    #region Constructors
    public ErrorResultModel() { }
    
    public ErrorResultModel(string errorMessage, T errorCode)
    {
        Code = errorCode;
        Message = errorMessage;
    }
    public ErrorResultModel(string errorMessage, T errorCode, ModelStateDictionary modelState)
        : this(errorMessage, errorCode)
    {
        Errors = modelState.Keys
            .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
            .ToList();
    }

    public ErrorResultModel(string errorMessage, T errorCode, List<ValidationError> errors)
        : this(errorMessage, errorCode)
    {
        Errors = errors;
    }
    #endregion
    
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
    
    public static ErrorResultModel Empty=new (string.Empty,ErrorCode.NONE);
}