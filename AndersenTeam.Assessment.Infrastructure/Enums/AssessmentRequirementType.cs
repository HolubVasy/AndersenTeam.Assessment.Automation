using System.ComponentModel;

namespace Assessment.Common.Enums
{
    public enum AssessmentRequirementType
    {
        [Description("None")]
        None = 0,

        [Description("Complete PDP Objectives")]
        PdpObjectives = 1,

        [Description("Get English level not less than {0}. Current level is {1}")]
        EnglishLevel = 2,

        [Description("TechnologyCertificates")]
        TechnologyCertificates = 3,

        [Description("Update Skill Set within 30 days prior to assessment initiation")]
        SkillSetUpdate = 4,

        [Description("Get {0} roles")]
        EmployeeRole = 5

    }
}
