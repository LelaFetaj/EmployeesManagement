using EmployeeManagementModels.Entities.Roles;

namespace EmployeeManagementAPI.Brokers.Managements.Roles
{
    public interface IRoleManagerBroker
    {
        ValueTask<Role> InsertRoleAsync(Role role);
        ValueTask<Role> SelectRoleByNameAsync(string roleName);
    }
}