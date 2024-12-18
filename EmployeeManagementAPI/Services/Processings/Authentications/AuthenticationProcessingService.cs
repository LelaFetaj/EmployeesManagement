using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using EmployeeManagementAPI.Services.Foundations.Authentications;
using EmployeeManagementModels.Entities.Users;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementAPI.Services.Processings.Authentications
{
    sealed class AuthenticationProcessingService : IAuthenticationProcessingService
    {
        private readonly IAuthenticationService authenticationService;
        private readonly string privateKey;

        public AuthenticationProcessingService(
            IAuthenticationService authenticationService,
            IConfiguration configuration)
        {
            this.authenticationService = authenticationService;
            privateKey = configuration["AuthConfiguration:SigningKey"];
        }

        public async ValueTask<bool> IsPasswordCorrect(User user, string password) =>
            await authenticationService.IsPasswordCorrect(user, password);

        public string GenerateJwtToken(User user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(type: ClaimTypes.NameIdentifier,value: user.Id.ToString()),
                new Claim(ClaimTypes.Role,JsonSerializer.Serialize(new List<string> { role }))
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(privateKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}