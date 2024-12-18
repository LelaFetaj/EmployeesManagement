using EmployeeManagementModels.DTOs.Authentications;
using EmployeeManagementModels.DTOs.Users;

namespace EmployeeManagementAPI.Services.Orchestrations
{
    public interface IUserOrchestrationService
    {
        ValueTask<AuthenticatedResponse> UserRegisterAsync(CreateUserRequest registerRequest);
    }
}