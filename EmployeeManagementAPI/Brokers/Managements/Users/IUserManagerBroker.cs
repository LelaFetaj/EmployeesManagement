using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementAPI.Brokers.Managements.Users
{
    public partial interface IUserManagerBroker
    {
        ValueTask<User> InsertUserAsync(User user, string password);
        ValueTask<User> SelectUserByUserNameAsync(string username);
        ValueTask<User> SelectUserByEmailAsync(string email);
    }
}