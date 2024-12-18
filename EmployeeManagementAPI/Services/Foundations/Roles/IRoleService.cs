using EmployeeManagementModels.Entities.Roles;

namespace EmployeeManagementAPI.Services.Foundations.Roles
{
    public interface IRoleService
    {
        ValueTask<Role> AddRoleAsync(Role role);
        ValueTask<Role> RetrieveRoleByNameAsync(string roleName);
    }
}