using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Brokers.Managements.Users
{
    public partial interface IUserManagerBroker
    {
        ValueTask<IdentityResult> AddToRoleAsync(User user, string roleName); 
    }
}