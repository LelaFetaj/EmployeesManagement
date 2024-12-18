using EmployeeManagementModels.Entities.UserProfiles;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementModels.Entities.Users;
public class User : IdentityUser<Guid>
{
    public required string UserName { get; set; } = string.Empty;
    //public required string LastName { get; set; } = string.Empty;
    public required string Email { get; set; }
    public string PasswordHash { get; set; }
    //public Gender Gender { get; set; } = Gender.Other;
    //public DateTimeOffset? BirthDate { get; set; }
    public Guid CreatedBy { get; set; }
    public required DateTimeOffset CreatedDate { get; set; }
    public Guid UpdatedBy { get; set; }
    public required DateTimeOffset UpdatedDate { get; set; }

    public virtual UserProfile Profile { get; set; }
}