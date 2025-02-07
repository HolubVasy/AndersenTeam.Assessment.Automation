using System.ComponentModel;

namespace Andersen.Infrastructure.API.Models
{
    public enum ErrorCode
    {
        /// <summary>
        /// Indeicates not error
        /// </summary>
        NONE,

        /// <summary>
        /// Common bad request error (status code 400 - BAD REQUEST)
        /// </summary>
        BAD_REQUEST,

        /// <summary>
        /// Common database exception  (status code 400 - BAD REQUEST)
        /// </summary>
        ITEM_ALREADY_EXIST,

        /// <summary>
        /// Common bad request error (status code 400 - BAD REQUEST)
        /// </summary>
        ARGUMENT_ERROR,

        /// <summary>
        /// Token expired exception  (status code 401 - UNAUTHORIZED)
        /// </summary>
        TOKEN_EXPIRED,

        /// <summary>
        /// Token validation failed or does not exist (status code 401 - UNAUTHORIZED)
        /// </summary>
        UNAUTHORIZED,

        /// <summary>
        /// Access denied (status code 403 - FORBIDDEN)
        /// </summary>
        ACCESS_DENIED,

        /// <summary>
        /// Access denied (status code 403 - FORBIDDEN)
        /// </summary>
        ACCESS_LOGIN_INCORRECT,

        /// <summary>
        /// Common Not found error  (status code 404 - NOT FOUND)
        /// </summary>
        NOT_FOUND,

        /// <summary>
        /// Validation error (status code 422 - UNPROCESSABLE ENTITY)
        /// </summary>
        VALIDATION_FAILED,

        /// <summary>
        /// Common 1C Interaction exception  (status code 500 - INTERNAL SERVER ERROR)
        /// </summary>
        EXTERNAL_SERVICE_EXEPTION,

        /// <summary>
        /// Common database exception  (status code 500 - INTERNAL SERVER ERROR)
        /// </summary>
        DATABASE_EXEPTION,

        /// <summary>
        /// Synchronization failed exception (status code 500 - INTERNAL SERVER ERROR)
        /// </summary>
        SYNC_FAILED,

        /// <summary>
        /// Synchronization failed exception (status code 500 - INTERNAL SERVER ERROR)
        /// </summary>
        RESOURCE_LOCKED_EXCEPTION,

        /// <summary>
        /// Failed configure service (status code 500 - INTERNAL SERVER ERROR)
        /// </summary>
        CONFIGURATION_EXCEPTION,

        /// <summary>
        /// Timeout failed exception (status code 504 -  - INTERNAL SERVER ERROR)
        /// </summary>
        TIMEOUT,

        /// <summary>
        /// UNEXPECTED Exception (status code 500)
        /// </summary>
        UNEXPECTED,

        /// <summary>
        /// Failed refresh token (status code 505 - special code)
        /// </summary>
        ERR_REFRESH_TOKEN,

        /// <summary>
        /// User friendly message
        /// </summary>
        USER_FRIENDLY_MESSAGE,

        /// <summary>
        /// Indicates that some assessment parts was not sent successfully.
        /// </summary>
        ASSESSMENT_PART_NOT_SENT_SUCCESSFULLY,
        
        /// <summary>
        /// Indicates that some input parameters are incorrect.
        /// </summary>
        INVALID_INPUT,

        /// <summary>
        /// Indicates pdp objectives validation result.
        /// </summary>
        [Description("PdpObjectives")]
        PDP_OBJECTIVES_VALIDATION,

        /// <summary>
        /// Indicates English requirenments validation result.
        /// </summary>
        [Description("EnglishLevel")]
        ENGLISH_LEVEL_VALIDATION,

        /// <summary>
        /// Indicates technology and cerificate requirenments validation result.
        /// </summary>
        [Description("TechnologyCertificates")]
        TECHNOLOGY_CERTIFICATES_VALIDATION,

        /// <summary>
        /// Indicates skill set update requirenments validation result.
        /// </summary>
        [Description("SkillSetUpdate")]
        SKILL_SET_UPDATE_VALIDATION,

        /// <summary>
        /// Indicates pdp objectives validation result.
        /// </summary>
        [Description("Php objectives not accessable")]
        PDP_OBJECTIVES_NOT_ACCESSABLE,

        /// <summary>
        /// CV is not accessible
        /// </summary>
        [Description("CV is not accessible")]
        CV_NOT_ACCESSIBLE,
    }
}
