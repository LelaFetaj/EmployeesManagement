using System.Linq.Expressions;
using EmployeeManagementAPI.Services.Foundations.Roles;
using EmployeeManagementModels.Entities.Roles;

namespace EmployeeManagementAPI.Services.Processings.Roles
{
    sealed class RoleProcessingService : IRoleProcessingService
    {
        private readonly IRoleService roleService;

        public RoleProcessingService(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async ValueTask<Role> AddRoleAsync(string roleName)
        {
            var role = await roleService.RetrieveRoleByNameAsync(roleName);

            // if (role is not null)
            // {
            //     throw new AlreadyExistsRoleException(roleName);
            // }

            Role newRole = new() { Name = roleName };

            return await roleService.AddRoleAsync(newRole);
        }
        
        public ValueTask<Role> RetrieveRoleByNameAsync(string roleName) =>
            this.roleService.RetrieveRoleByNameAsync(roleName);
    }
}