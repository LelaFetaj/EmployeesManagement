using EmployeeManagementModels.Entities.Roles;

namespace EmployeeManagementAPI.Services.Processings.Roles
{
    public interface IRoleProcessingService
    {
        ValueTask<Role> AddRoleAsync(string roleName);
        ValueTask<Role> RetrieveRoleByNameAsync(string roleName);
    }
}