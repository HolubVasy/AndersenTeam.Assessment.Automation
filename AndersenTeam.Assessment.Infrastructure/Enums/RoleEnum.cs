using System.ComponentModel;

namespace AndersenTeam.Assessment.Infrastructure.Enums
{
public enum RolesEnum
{
    [Description("None role")]
    None = 0,
    
    [Description("Associate Resource Manager")]
    AssociateResourceManager = 1,
    
    [Description("Resource Manager")]
    ResourceManager,
    
    [Description("Senior Resource Manager")]
    SeniorResourceManager,
    
    [Description("Resource Director")]
    ResourceDirector,
    
    [Description("Any other role")]
    OtherRole,
}
}