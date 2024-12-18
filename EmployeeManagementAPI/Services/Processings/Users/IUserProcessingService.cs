using EmployeeManagementModels.DTOs.Users;
using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementAPI.Services.Processings.Users
{
    public interface IUserProcessingService
    {
        ValueTask<User> CreateUserWithRoleAsync(CreateUserRequest createUserRequest, string roleName);
        ValueTask<User> RetrieveUserByUsernameAsync(string username);
        ValueTask<User> RetrieveUserByEmailAsync(string email);
    }
}