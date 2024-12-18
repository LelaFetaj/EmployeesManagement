using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementAPI.Services.Foundations.Authentications
{
    public interface IAuthenticationService
    {
        ValueTask<bool> IsPasswordCorrect(
            User user,
            string password,
            bool lockoutOnFailure = false);
    }
}