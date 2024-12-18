using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementAPI.Brokers.Managements.Authentications
{
    public interface IAuthenticationManagerBroker
    {
        ValueTask<SignInResult> CheckPasswordSignInAsync(
           User user,
           string password,
           bool lockoutOnFailure);
    }
}