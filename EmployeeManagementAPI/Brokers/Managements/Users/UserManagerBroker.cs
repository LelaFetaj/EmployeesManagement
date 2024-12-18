using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Brokers.Managements.Users
{
    sealed partial class UserManagerBroker : IUserManagerBroker
    {
        private readonly UserManager<User> userManager;
        public UserManagerBroker(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async ValueTask<User> InsertUserAsync(User user, string password)
        {
            var broker = new UserManagerBroker(userManager);
            await broker.userManager.CreateAsync(user, password);
            return user;
        }

        public async ValueTask<User> SelectUserByUserNameAsync(string username)
        {
            var broker = new UserManagerBroker(this.userManager);

            return await broker.userManager.FindByNameAsync(username);
        }

        public async ValueTask<User> SelectUserByEmailAsync(string email)
        {
            var broker = new UserManagerBroker(this.userManager);

            return await broker.userManager.FindByEmailAsync(email);
        }
    }
}