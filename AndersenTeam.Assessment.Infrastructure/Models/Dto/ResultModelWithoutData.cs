using Andersen.Infrastructure.API.Models;
using Assessment.Common.Enums;

namespace Assessment.Common.Models.DTOs.Result;

public class ResultModelWithoutData
{
    public bool Success { get; }
    public int StatusCode { get; }
    public string Message { get; }

    public AssessmentRequirementType? AssessmentRequirenmentType { get; }

    public ErrorResultModel? Error { get; }
    
    #region Constructors
    
    public ResultModelWithoutData(bool success, 
        string message, 
        int statusCode,
        ErrorResultModel? error,
        AssessmentRequirementType? AssessmentRequirenmentType = null)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Error = error;
    }
    
    public static ResultModelWithoutData OkResult(string message="Success", 
        int statusCode = 200, AssessmentRequirementType? assessmentRequirenmentType = null)
        =>new(
        true,
        message,
        statusCode,
        ErrorResultModel.Empty,
        assessmentRequirenmentType);
    
    public static ResultModelWithoutData FailResult(string errorMessage,
        ErrorResultModel? error,
        int statusCode = 400, AssessmentRequirementType? assessmentRequirenmentType = null) => new (
        false,
        errorMessage,
        statusCode,
        error,
        assessmentRequirenmentType);
    
    #endregion
}