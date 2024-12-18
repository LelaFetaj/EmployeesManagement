using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementModels.Entities.UserProfiles
{
    public class UserProfile
    {
        public Guid Id { get; set; } 

        public Guid UserId { get; set; } 

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Other;
        public DateTimeOffset? BirthDate { get; set; }
        public byte[] FileContent { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; } = string.Empty;

        public User User { get; set; } = null!;
    }
}