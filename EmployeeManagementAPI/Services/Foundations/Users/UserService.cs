using EmployeeManagementAPI.Brokers.Managements.Users;
using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Services.Foundations.Users
{
    sealed partial class UserService : IUserService
    {
        private readonly IUserManagerBroker userManagerBroker;
        public UserService(IUserManagerBroker userManagerBroker)
        {
            this.userManagerBroker = userManagerBroker;
        }

        public async ValueTask<User> RegisterUserAsync(User user, string password)
        {
            return await userManagerBroker.InsertUserAsync(user, password);
        }

        public async ValueTask<User> RetreiveUserByEmailAsync(string email)
        {
            return await this.userManagerBroker.SelectUserByEmailAsync(email);
        }

        public async ValueTask<User> RetreiveUserByUserNameAsync(string username) 
        {
            return await this.userManagerBroker.SelectUserByUserNameAsync(username);
        }

        public async ValueTask<bool> AssignUserRole(User user, string roleName) 
        {
            IdentityResult result =
                await this.userManagerBroker.AddToRoleAsync(user, roleName);

            return result.Succeeded;
        }
    }
}