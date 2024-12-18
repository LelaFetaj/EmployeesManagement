using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Brokers.Managements.Authentications
{
    public class AuthenticationManagerBroker : IAuthenticationManagerBroker
    {
        private readonly SignInManager<User> signInManager;

        public AuthenticationManagerBroker(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async ValueTask<SignInResult> CheckPasswordSignInAsync(
            User user,
            string password,
            bool lockoutOnFailure)
        {
            return await this.signInManager.CheckPasswordSignInAsync(
                user,
                password,
                lockoutOnFailure);
        }
    }
}