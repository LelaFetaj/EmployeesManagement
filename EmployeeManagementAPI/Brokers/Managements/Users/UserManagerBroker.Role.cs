using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Brokers.Managements.Users
{
    sealed partial class UserManagerBroker
    {
        public async ValueTask<IdentityResult> AddToRoleAsync(User user, string roleName)
        {
            var broker = new UserManagerBroker(this.userManager);

            return await broker.userManager.AddToRoleAsync(user, roleName);
        }
    }
}