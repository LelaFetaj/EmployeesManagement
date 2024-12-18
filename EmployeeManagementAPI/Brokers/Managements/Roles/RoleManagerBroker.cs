using EmployeeManagementAPI.Brokers.Managements.Roles;
using EmployeeManagementModels.Entities.Roles;
using Microsoft.AspNetCore.Identity;

public class RoleManagerBroker : IRoleManagerBroker
{
    private readonly RoleManager<Role> roleManager;
    public RoleManagerBroker(RoleManager<Role> roleManager)
    {
        this.roleManager = roleManager;
    }
    public async ValueTask<Role> InsertRoleAsync(Role role)
    {
        var broker = new RoleManagerBroker(this.roleManager);
        await broker.roleManager.CreateAsync(role);
        return role;
    }
    
    public async ValueTask<Role> SelectRoleByNameAsync(string roleName)
    {
        var broker = new RoleManagerBroker(this.roleManager);

        return await broker.roleManager.FindByNameAsync(roleName);
    }
}