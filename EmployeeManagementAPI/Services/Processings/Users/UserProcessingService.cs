using EmployeeManagementAPI.Brokers.DataTimes;
using EmployeeManagementAPI.Services.Foundations.Users;
using EmployeeManagementAPI.Services.Processings.Users;
using EmployeeManagementModels.DTOs.Users;
using EmployeeManagementModels.Entities.Users;

sealed partial class UserProcessingService : IUserProcessingService
{
    private readonly IUserService userService;
    private readonly IDateTimeBroker dateTimeBroker;
    public UserProcessingService(IUserService userService, IDateTimeBroker dateTimeBroker)
    {
        this.userService = userService;
        this.dateTimeBroker = dateTimeBroker;
    }
    public async ValueTask<User> CreateUserWithRoleAsync(CreateUserRequest createUserRequest, string roleName)
    {
        var user = new User
        {
            Email = createUserRequest.Email,
            UserName = createUserRequest.Username,
            //FirstName = createUserRequest.Firstname,
            //LastName = createUserRequest.Lastname,
            PhoneNumber = createUserRequest.PhoneNumber,
            //Gender = createUserRequest.Gender,
            //BirthDate = createUserRequest.BirthDate?.ToDateTime(TimeOnly.MinValue).ToUniversalTime(),
            CreatedDate = this.dateTimeBroker.GetCurrentDateTime(),
            UpdatedDate = this.dateTimeBroker.GetCurrentDateTime()
        };
        _ = await this.userService.RegisterUserAsync(user, createUserRequest.Password);
        if (!string.IsNullOrWhiteSpace(roleName))
        {
            await this.userService.AssignUserRole(user, roleName);
        }
        return user;
    }

    public async ValueTask<User> RetrieveUserByUsernameAsync(string username) =>
            await this.userService.RetreiveUserByUserNameAsync(username);

        public async ValueTask<User> RetrieveUserByEmailAsync(string email) =>
            await this.userService.RetreiveUserByEmailAsync(email);
}