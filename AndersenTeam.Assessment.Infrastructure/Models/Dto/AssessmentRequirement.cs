namespace AndersenTeam.Assessment.Infrastructure.Models.Dto
{
    /// <summary>
    /// Represents a requirement for an assessment.
    /// </summary>
    public sealed class AssessmentRequirement
    {
        /// <summary>
        /// Gets the name of the assessment requirement.
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        /// Gets the type of the assessment requirement.
        /// </summary>
        public string Type { get; init; } = null!;

        /// <summary>
        /// Gets a value indicating whether the assessment requirement is completed.
        /// </ summary>
        public bool Completed { get; init; }

        /// <summary>
        /// Gets the list of child assessment requirements.
        /// </summary>
        public IList<AssessmentRequirement> Children { get; init; } = null!;
    }
}