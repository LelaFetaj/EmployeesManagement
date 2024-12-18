using EmployeeManagementAPI.Services.Orchestrations;
using EmployeeManagementModels.DTOs.Authentications;
using EmployeeManagementModels.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // POST /api/users 
        // GET /api/users 
        // GET /api/users/{id} 
        // PUT /api/users/{id}
        // DELETE /api/users/{id}
        // all admin

        private readonly IUserOrchestrationService userOrchestrationService;

        public UserController(IUserOrchestrationService userOrchestrationService)
        {
            this.userOrchestrationService = userOrchestrationService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticatedResponse>> RegisterUser([FromBody] CreateUserRequest registerRequest)
        {
            return await userOrchestrationService.UserRegisterAsync(registerRequest);
        }
    }
    
}