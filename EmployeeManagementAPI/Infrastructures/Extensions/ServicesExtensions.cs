using System.Text;
using EmployeeManagementAPI.Brokers.DataTimes;
using EmployeeManagementAPI.Brokers.Managements.Authentications;
using EmployeeManagementAPI.Brokers.Managements.Roles;
using EmployeeManagementAPI.Brokers.Managements.Users;
using EmployeeManagementAPI.Brokers.Storages;
using EmployeeManagementAPI.Services.Foundations.Authentications;
using EmployeeManagementAPI.Services.Foundations.Roles;
using EmployeeManagementAPI.Services.Foundations.Users;
using EmployeeManagementAPI.Services.Orchestrations;
using EmployeeManagementAPI.Services.Processings.Authentications;
using EmployeeManagementAPI.Services.Processings.Roles;
using EmployeeManagementAPI.Services.Processings.Users;
using EmployeeManagementModels.Configurations;
using EmployeeManagementModels.Entities.Roles;
using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EmployeeManagementAPI.Infrastructures.Extensions
{
    public static partial class ServicesExtensions
    {
        public static void AddCustomAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AuthConfiguration authConfiguration = configuration
                .GetSection(nameof(AuthConfiguration))
                .Get<AuthConfiguration>();

            PasswordConfiguration passwordConfiguration = configuration
                .GetSection(nameof(PasswordConfiguration))
                .Get<PasswordConfiguration>();

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = passwordConfiguration.RequiredLength;
                options.Password.RequireDigit = passwordConfiguration.RequireDigit;
                options.Password.RequireLowercase = passwordConfiguration.RequireLowercase;
                options.Password.RequireUppercase = passwordConfiguration.RequireUppercase;
                options.Password.RequireNonAlphanumeric = passwordConfiguration.RequireNonAlphanumeric;
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            // .AddEntityFrameworkStores<StorageBroker>();
            .AddEntityFrameworkStores<AuthenticationDbContext>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = authConfiguration.ValidateIssuer,
                        ValidateAudience = authConfiguration.ValidateAudience,
                        ValidateIssuerSigningKey = authConfiguration.ValidateIssuerSigningKey,
                        RequireExpirationTime = authConfiguration.RequireExpirationTime,
                        ValidateLifetime = authConfiguration.ValidateLifetime,
                        RequireSignedTokens = authConfiguration.RequireSignedTokens,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(authConfiguration.SigningKey)),
                    };
                });
        }

        public static void AddAuthenticationContext(this IServiceCollection services)
        {
            // services.AddDbContext<StorageBroker>();
            services.AddDbContext<AuthenticationDbContext>();
        }

        public static void AddManagementContext(this IServiceCollection services)
        {
            // services.AddDbContext<StorageBroker>();
            services.AddDbContext<ManagementDbContext>();
        }
        public static void AddAuthenticationBrokers(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<AuthenticationDbContext>();
            services.AddScoped<ManagementDbContext>();
            // services.AddScoped<IStorageBroker, StorageBroker>();
            services.AddScoped<IUserManagerBroker, UserManagerBroker>();
            services.AddScoped<IRoleManagerBroker, RoleManagerBroker>();
            services.AddScoped<IAuthenticationManagerBroker, AuthenticationManagerBroker>();
        }

        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IAuthenticationProcessingService, AuthenticationProcessingService>();
            services.AddTransient<IUserProcessingService, UserProcessingService>();
            services.AddTransient<IRoleProcessingService, RoleProcessingService>();

            services.AddTransient<IUserOrchestrationService, UserOrchestrationService>();
        }

        // public static void AddCustomHealthChecks(
        //     this IHealthChecksBuilder healthChecksBuilder,
        //     IConfiguration configuration)
        // {
        //     string connectionString = configuration.GetConnectionString(
        //         name: "DefaultConnection");

        //     healthChecksBuilder
        //         .AddDbContextCheck<StorageBroker>(nameof(StorageBroker))
        //          .AddSqlServer(
        //             connectionString,
        //             name: "SQL Server");
        // }
        public static void AddCustomHealthChecks(
            this IHealthChecksBuilder healthChecksBuilder,
            IConfiguration configuration)
        {
            string authenticationConnection = configuration.GetConnectionString("AuthenticationConnection");
            string managementConnection = configuration.GetConnectionString("ManagementConnection");

            healthChecksBuilder
                .AddSqlServer(authenticationConnection, name: "Authentication Database")
                .AddSqlServer(managementConnection, name: "Management Database");
        }

        // public static void AddControllerWithFilters(this IServiceCollection services)
        // {
        //     var externalControllerFeatureProvider = new ExternalControllerFeatureProvider();

        //     // Add the custom provider to the ApplicationPartManager
        //     services.Configure<MvcOptions>(options =>
        //     {
        //         options.Conventions.Add(new ExternalControllerFeatureProvider());
        //     });

        //     services.AddControllers(options =>
        //     {
        //         options.Filters.Add(typeof(GlobalExceptionFilter));
        //     })
        //     .AddJsonOptions(options =>
        //     {
        //         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        //         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        //     });
        // }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = "EmployeeManagementAPI",
                    Version = "v1",
                };

                options.SwaggerDoc(
                    name: "v1",
                    info: openApiInfo);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT token that is issued after login"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void UseSwaggerService(this IApplicationBuilder builder)
        {
            builder.UseSwagger();

            builder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    url: $"./v1/swagger.json",
                    name: "EmployeeManagementAPI v1");
            });
        }
    }
}