using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementAPI.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> RegisterUserAsync(User user, string password);
        ValueTask<User> RetreiveUserByEmailAsync(string email);
        ValueTask<User> RetreiveUserByUserNameAsync(string username);
        ValueTask<bool> AssignUserRole(User user, string roleName);
    }
}