using System.Net;
using AndersenTeam.Assessment.Infrastructure.Enums;
using AndersenTeam.Assessment.Infrastructure.Helpers;
using AndersenTeam.Assessment.Infrastructure.Models.Dto;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace AndersenTeam.Assessment.Automation
{
public class AssessmentControllerApiTests(AssessmentControllerApiTests.CustomWebApplicationFactory factory)
    :IClassFixture<AssessmentControllerApiTests.CustomWebApplicationFactory>
{
    [Theory]
    #region Test cases
    //[InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.AssociateResourceManager,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"test")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.AssociateResourceManager,"test")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"")]
    #endregion
    public async Task 
        EditAssessment_NotRequiredEnglishNotRequiredRoleWithAndWithoutComment_ReturnsBadRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,    
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
                
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory]
    #region Test cases
    //[InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.OtherRole,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.None,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.OtherRole,"test")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.None,"test")]
    #endregion
    public async Task
        EditAssessment_NotRequiredEnglishNotRequiredRoleOtherAndNonWithAndWithoutComment_ReturnsBadRequest(
            string assessmentPartId,TechnologyLevelEnum technologyLevel,
            LanguageLevelEnum languageLevel,
            RolesEnum role,
            string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory]
    #region Test cases
    //[InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceDirector,"test")]
    [InlineData("08dbc343-4ede-4587-8396-6236eddc706c",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.SeniorResourceManager,"test")]
    #endregion
    public async Task
        EditAssessment_NotRequiredEnglishRequiredRoleWithoutComment_ReturnsOK(
            string assessmentPartId,TechnologyLevelEnum technologyLevel,
            LanguageLevelEnum languageLevel,
            RolesEnum role,
            string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    [InlineData("08dbb2ab-c02e-453d-8b65-fc95c723efa6",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.SeniorResourceManager,"")]
    [InlineData("08dbb2ab-c02e-453d-8b65-fc95c723efa6",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceDirector,"")]
    public async Task EditAssessment_NotRequiredEnglishRequiredRoleWithoutComment_ReturnsBadRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,    
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
                
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory]
    [InlineData("08dbb2ab-c02e-453d-8b65-fc95c723efa6",TechnologyLevelEnum.M1,LanguageLevelEnum.A2,RolesEnum.SeniorResourceManager,"test")]
    [InlineData("08dbb2ab-c02e-453d-8b65-fc95c723efa6",TechnologyLevelEnum.M1,LanguageLevelEnum.A2,RolesEnum.ResourceDirector,"test")]
    public async Task EditAssessment_NotRequiredEnglishRequiredRoleWithComment_ReturnsOk(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,    
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
                
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    #region Test cases
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.ResourceManager,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.AssociateResourceManager,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.OtherRole,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.None,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.ResourceManager,"test")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.AssociateResourceManager,"test")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.OtherRole,"test")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.None,"test")]
    #endregion
    public async Task
        EditAssessment_RequiredEnglishNotRequiredRoleWithAndWithoutComment_ReturnsOK(
            string assessmentPartId,TechnologyLevelEnum technologyLevel,
            LanguageLevelEnum languageLevel,
            RolesEnum role,
            string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    #region Test cases
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.OtherRole,"test")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.None,"test")]
    #endregion
    public async Task
        EditAssessment_RequiredEnglishNotRequiredRoleNoneAndOtherComment_ReturnsOK(
            string assessmentPartId,TechnologyLevelEnum technologyLevel,
            LanguageLevelEnum languageLevel,
            RolesEnum role,
            string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    #region Test cases
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.OtherRole,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.None,"")]
    #endregion
    public async Task
        EditAssessment_RequiredEnglishNotRequiredRoleNoneAndOtherWithoutComment_ReturnsOK(
            string assessmentPartId,TechnologyLevelEnum technologyLevel,
            LanguageLevelEnum languageLevel,
            RolesEnum role,
            string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.SeniorResourceManager,"test")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.ResourceDirector,"test")]
    public async Task EditAssessment_RequiredEnglishRequiredRoleWithoutAndWithComment_ReturnsOK(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.ResourceDirector,"")]
    [InlineData("08db376d-9ebb-47d4-8bce-326047b8470c",TechnologyLevelEnum.M2,LanguageLevelEnum.B1,RolesEnum.SeniorResourceManager,"")]
    public async Task EditAssessment_RequiredEnglishRequiredRoleWithoutComment_ReturnsOK(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory(DisplayName = "Check use cases, indicated in the PRTM-9209 bug.")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"test")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.AssociateResourceManager,"test")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.ResourceManager,"")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M2,LanguageLevelEnum.A2,RolesEnum.AssociateResourceManager,"")]
    [InlineData("08dcf26c-f908-4715-8ddc-bdd5125b1bf1",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.AssociateResourceManager,"")]
    [InlineData("08dcf26c-f908-4715-8ddc-bdd5125b1bf1",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.ResourceManager,"")]
        public async Task 
        EditAssessment_NotRequiredEnglishNotRequiredRoleWithAndWithoutComment_PRTM_9209_ReturnsBadRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory(DisplayName = "Check use cases, indicated in the PRTM-9210 bug.")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M3,LanguageLevelEnum.A1,RolesEnum.ResourceDirector,"")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.M3,LanguageLevelEnum.A1,RolesEnum.SeniorResourceManager,"")]
    [InlineData("08dcf26c-f908-4715-8ddc-bdd5125b1bf1",TechnologyLevelEnum.M3,LanguageLevelEnum.A1,RolesEnum.SeniorResourceManager,"")]
    public async Task 
        EditAssessment_NotRequiredEnglishRequiredRoleWithoutComment_PRTM_9210_ReturnsBadRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory(DisplayName = "Check use cases, indicated in the PRTM-9211 bug.")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.OtherRole,"qwerty")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.OtherRole,"")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.None,"qwerty")]
    [InlineData("08dce38a-13ee-4911-8839-c8a54d3775da",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.None,"")]
    public async Task 
        EditAssessment_NotRequiredEnglishNotRequiredRoleOtherRolesWithoutAndWithComment_PRTM_9211_ReturnsBadRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    [Theory(DisplayName = "Check use cases, indicated in the PRTM-9211 bug.")]
    [InlineData("08dc02d7-3a40-47ca-80f0-cd4b54d09ddf",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.ResourceDirector,"qwerty")]
    public async Task 
        EditAssessment_NotRequiredEnglishRequiredRoleWithCommentWithinRmLine_PRTM_9211_ReturnsOK(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);// Change based on expected result
    }
    
    [Theory(DisplayName = "Check use cases, indicated in the PRTM-9211 bug.")]
    [InlineData("08dc02d7-3a40-47ca-80f0-cd4b54d09ddf",TechnologyLevelEnum.S1,LanguageLevelEnum.A1,RolesEnum.SeniorResourceManager,"qwerty")]
    public async Task 
        EditAssessment_NotRequiredEnglishRequiredRoleWithCommentOutOfRmLine_PRTM_9211_ReturnsBackRequest(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,
        RolesEnum role,
        string? reasonForSkippingEnglish=default)
    {
        // Arrange
        var editAssessmentDto=GetAssessmentNotEnoughEnglishDto(assessmentPartId,
            technologyLevel,
            languageLevel,
            reasonForSkippingEnglish);
        
        // Act
        var response=await HttpClientHelper
            .SendRequest(editAssessmentDto, BearerTokenHelper.GetBearerToken(role));
        var result = await response!.Content.ReadAsStringAsync();
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);// Change based on expected result
    }
    
    
    
    #region Infrastructure
    
    private static EditAssessmentDto GetAssessmentNotEnoughEnglishDto(
        string assessmentPartId,TechnologyLevelEnum technologyLevel,
        LanguageLevelEnum languageLevel,string? reasonForSkippingEnglish=default)
    {
        return new EditAssessmentDto
        (
            Guid.Parse(assessmentPartId),
            AssessmentPartTypeEnum.Technology,
            technologyLevel,
            languageLevel,
            "Updated comment",
            reasonForSkippingEnglish
        );
    }
    
    // A factory class to manage the setup for creating HttpClient
    public class CustomWebApplicationFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public CustomWebApplicationFactory()
        {
            var serviceCollection=new ServiceCollection();
            serviceCollection.AddHttpClient();// Adding HttpClientFactory service
            var serviceProvider=serviceCollection.BuildServiceProvider();
            _httpClientFactory=serviceProvider.GetRequiredService<IHttpClientFactory>();
        }
        
        public HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient();
        }
    }
    
    #endregion
}
}
