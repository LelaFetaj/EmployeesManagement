using EmployeeManagementAPI.Brokers.Managements.Roles;
using EmployeeManagementAPI.Services.Foundations.Roles;
using EmployeeManagementModels.Entities.Roles;

sealed partial class RoleService : IRoleService
{
    private readonly IRoleManagerBroker roleManagerBroker;
    public RoleService(IRoleManagerBroker roleManagerBroker)
    {
        this.roleManagerBroker = roleManagerBroker;
    }
    public async ValueTask<Role> AddRoleAsync(Role role) 
    {
        return await this.roleManagerBroker.InsertRoleAsync(role);
    }
    public async ValueTask<Role> RetrieveRoleByNameAsync(string roleName) 
    {

        return await this.roleManagerBroker.SelectRoleByNameAsync(roleName);
    }
}