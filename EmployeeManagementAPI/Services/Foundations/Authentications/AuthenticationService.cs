using EmployeeManagementAPI.Brokers.Managements.Authentications;
using EmployeeManagementAPI.Services.Foundations.Authentications;
using EmployeeManagementModels.Entities.Users;

sealed partial class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationManagerBroker authenticationManagerBroker;
    public AuthenticationService(
        IAuthenticationManagerBroker authenticationManagerBroker)
    {
        this.authenticationManagerBroker = authenticationManagerBroker;
    }
    public async ValueTask<bool> IsPasswordCorrect(
        User user,
        string password,
        bool lockoutOnFailure = false)
        {
            var result = await this.authenticationManagerBroker.CheckPasswordSignInAsync(
                user,
                password,
                lockoutOnFailure);
            return result.Succeeded;
        }
}