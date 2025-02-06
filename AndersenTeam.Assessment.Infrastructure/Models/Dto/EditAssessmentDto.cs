using AndersenTeam.Assessment.Infrastructure.Enums;

namespace AndersenTeam.Assessment.Infrastructure.Models.Dto;

public record EditAssessmentDto
(
    Guid AssessmentPartId,
    AssessmentPartTypeEnum Type,
    TechnologyLevelEnum? TechnologyLevel,
    LanguageLevelEnum? LanguageLevel,
    string Comment,
    string? EnglishRequirementSkipReason
);