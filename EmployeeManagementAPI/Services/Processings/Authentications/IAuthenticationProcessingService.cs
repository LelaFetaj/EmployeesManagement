using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementAPI.Services.Processings.Authentications
{
    public interface IAuthenticationProcessingService
    {
        ValueTask<bool> IsPasswordCorrect(User user, string password);
        public string GenerateJwtToken(User user, string role);
    }
}