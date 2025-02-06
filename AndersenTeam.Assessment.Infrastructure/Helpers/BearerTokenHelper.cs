using AndersenTeam.Assessment.Infrastructure.Enums;

namespace AndersenTeam.Assessment.Infrastructure.Helpers;

public static class BearerTokenHelper
{
    public static string GetBearerToken(RolesEnum role)=>
        role switch
        {
            RolesEnum.None=>BearerTokenConstants.None,
            RolesEnum.AssociateResourceManager=>BearerTokenConstants.AssociateResourceManager,
            RolesEnum.ResourceManager=>BearerTokenConstants.ResourceManager,
            RolesEnum.SeniorResourceManager=>BearerTokenConstants.SeniorResourceManager,
            RolesEnum.ResourceDirector=>BearerTokenConstants.ResourceDirector,
            RolesEnum.OtherRole=>BearerTokenConstants.OtherRole,
            _=>throw new ArgumentOutOfRangeException(nameof(role),role,null)
        };
}