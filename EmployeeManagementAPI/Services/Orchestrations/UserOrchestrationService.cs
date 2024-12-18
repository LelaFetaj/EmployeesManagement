using EmployeeManagementAPI.Services.Processings.Authentications;
using EmployeeManagementAPI.Services.Processings.Roles;
using EmployeeManagementAPI.Services.Processings.Users;
using EmployeeManagementModels.DTOs.Authentications;
using EmployeeManagementModels.DTOs.Users;
using EmployeeManagementModels.Entities.Roles;

namespace EmployeeManagementAPI.Services.Orchestrations
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IAuthenticationProcessingService authenticationProcessingService;
        private readonly IUserProcessingService userProcessingService;
        private readonly IRoleProcessingService roleProcessingService;

        public UserOrchestrationService(
            IAuthenticationProcessingService authenticationProcessingService,
            IUserProcessingService userProcessingService,
            IRoleProcessingService roleProcessingService)
        {
            this.authenticationProcessingService = authenticationProcessingService;
            this.userProcessingService = userProcessingService;
            this.roleProcessingService = roleProcessingService;
        }

        public async ValueTask<AuthenticatedResponse> UserRegisterAsync(CreateUserRequest registerRequest)
        {
            var storageUser =
                await this.userProcessingService.RetrieveUserByUsernameAsync(registerRequest.Username);

            // if (storageUser is not null)
            // {
            //     throw new AlreadyExistsUserException(registerRequest.Username);
            // }

            var storageUserByEmail =
                await this.userProcessingService.RetrieveUserByEmailAsync(registerRequest.Email);

            // if (storageUserByEmail is not null)
            // {
            //     throw new AlreadyExistsUserException(registerRequest.Email);
            // }

            Role role =
                await this.roleProcessingService.RetrieveRoleByNameAsync(registerRequest.RoleName);

            // if (role is null)
            // {
            //     throw new NotFoundRoleException(registerRequest.RoleName);
            // }

            var user =
                await this.userProcessingService.CreateUserWithRoleAsync(registerRequest, registerRequest.RoleName);

            return new AuthenticatedResponse
            {
                AuthenticationToken = this.authenticationProcessingService.GenerateJwtToken(user, role.Name)
            };
        }
    }
}