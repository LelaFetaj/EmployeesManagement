using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementModels.DTOs.Users;
public class ModifyUserRequest
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTimeOffset BirthDate { get; set; }
}