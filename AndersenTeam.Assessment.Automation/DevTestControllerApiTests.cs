using AndersenTeam.Assessment.Infrastructure.Enums;
using AndersenTeam.Assessment.Infrastructure.Helpers;
using Assessment.Common.Models.DTOs.Result;
using FluentAssertions;

namespace AndersenTeam.Assessment.Automation
{
    public class DevTestControllerApiTests(AssessmentControllerApiTests.CustomWebApplicationFactory factory)
        : IClassFixture<AssessmentControllerApiTests.CustomWebApplicationFactory>
    {
        private const string AssociateResourceManagerId = "252422b0-2a7b-11eb-85e2-0c9d92c3d39d";
        private const string TechnicalInterviewerId = "807acfd4-3e46-11eb-85e2-0c9d92c3d39d";
        private const string MentorId = "807acfd3-3e46-11eb-85e2-0c9d92c3d39d";
        private const string LeadId = "613cc0b8-0f1e-11ec-85ea-0c9d92c3d39d";
        private const string CoreExpertId = "a063008c-6602-11eb-85e2-0c9d92c3d39d";
        private const string HeadOfExpertsId = "cb5608f5-6a9f-11ed-96e7-f1286019d2c0";

        private async Task<ResultModelWithoutData> ValidateRoles(
            string employeeId, 
            TechnologyLevelEnum level,
            RolesEnum role)
        {
            var uri = Path.Combine(UriHelper.BaseUri, UriHelper.RoleValidationUri);
            var result = await HttpClientHelper.SendGetRequestAnonymousAsync<ResultModelWithoutData>(
                uri,
                employeeId,
                level.ToString());

            return result ?? throw new InvalidOperationException("API returned null response");
        }

        [Theory]
        // Additional test cases covering more validation scenarios
        [InlineData("45678901-4567-4567-4567-456789012346", TechnologyLevelEnum.M1, 1, RolesEnum.AssociateResourceManager)]
        //[InlineData("56789012-5678-5678-5678-567890123457", TechnologyLevelEnum.M1, 1, RolesEnum.ResourceManager)]
        //[InlineData("67890123-6789-6789-6789-678901234568", TechnologyLevelEnum.M2, 2, RolesEnum.AssociateResourceManager)]
        //[InlineData("78901234-7890-7890-7890-789012345679", TechnologyLevelEnum.M2, 2, RolesEnum.ResourceManager)]
        //[InlineData("89012345-8901-8901-8901-890123456780", TechnologyLevelEnum.M3, 2, RolesEnum.OtherRole)]
        //[InlineData("90123456-9012-9012-9012-901234567891", TechnologyLevelEnum.M3, 2, RolesEnum.SeniorResourceManager)]
        //[InlineData("01234567-0123-0123-0123-012345678902", TechnologyLevelEnum.S1, 2, RolesEnum.OtherRole)]
        //[InlineData("12345678-1234-1234-1234-123456789013", TechnologyLevelEnum.S2, 3, RolesEnum.SeniorResourceManager)]
        //[InlineData("23456789-2345-2345-2345-234567890124", TechnologyLevelEnum.S3, 3, RolesEnum.OtherRole)]
        //[InlineData("34567890-3456-3456-3456-345678901235", TechnologyLevelEnum.S3, 3, RolesEnum.SeniorResourceManager)]
        //// Additional tests for broader validation coverage
        //[InlineData("45678901-1111-1111-1111-456789012346", TechnologyLevelEnum.J1, 0, RolesEnum.None)]
        //[InlineData("56789012-2222-2222-2222-567890123457", TechnologyLevelEnum.J2, 0, RolesEnum.None)]
        //[InlineData("67890123-3333-3333-3333-678901234568", TechnologyLevelEnum.J3, 0, RolesEnum.None)]
        //[InlineData("78901234-4444-4444-4444-789012345679", TechnologyLevelEnum.M1, 1, RolesEnum.AssociateResourceManager)]
        //[InlineData("89012345-5555-5555-5555-890123456780", TechnologyLevelEnum.M2, 2, RolesEnum.ResourceManager)]
        //[InlineData("90123456-6666-6666-6666-901234567891", TechnologyLevelEnum.M3, 2, RolesEnum.SeniorResourceManager)]
        //[InlineData("01234567-7777-7777-7777-012345678902", TechnologyLevelEnum.S1, 2, RolesEnum.OtherRole)]
        //[InlineData("12345678-8888-8888-8888-123456789013", TechnologyLevelEnum.S2, 3, RolesEnum.SeniorResourceManager)]
        //[InlineData("23456789-9999-9999-9999-234567890124", TechnologyLevelEnum.S3, 3, RolesEnum.OtherRole)]
        //[InlineData("34567890-0000-0000-0000-345678901235", TechnologyLevelEnum.S3, 3, RolesEnum.SeniorResourceManager)]
        public async Task ValidateEmployeeRoles_WithAdditionalCases_ReturnsSuccess(
            string employeeId,
            TechnologyLevelEnum level,
            int roleNumber,
            RolesEnum role)
        {
            var result = await ValidateRoles(employeeId, level, role);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be(string.Format("Role {0} is valid.", roleNumber));
        }
    }
}
