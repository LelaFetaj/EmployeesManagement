using EmployeeManagementModels.Entities.Roles;
using EmployeeManagementModels.Entities.UserProfiles;
using EmployeeManagementModels.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EmployeeManagementAPI.Brokers.Storages
{
    public class AuthenticationDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IConfiguration configuration;

        public AuthenticationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = this.configuration.GetConnectionString(name: "AuthenticationConnection");
            optionsBuilder.UseSqlServer(connectionString);
            
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureIdentityTables(modelBuilder);
        }

        private static void ConfigureIdentityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable(name: "Roles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable(name: "RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable(name: "UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable(name: "UserLogins");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable(name: "UserRoles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable(name: "UserTokens");

            modelBuilder.Entity<User>(action =>
            {
                action.ToTable(name: "Users");

                action.HasIndex(prop => prop.Email).IsUnique();
                action.HasIndex(prop => prop.UserName).IsUnique();

                action.HasIndex(prop => prop.CreatedDate);
                action.HasIndex(prop => prop.UpdatedDate);

                action
                    .HasOne(user => user.Profile)
                    .WithOne(profile => profile.User)
                    .HasForeignKey<UserProfile>(profile => profile.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<UserProfile>(action =>
            {
                action.ToTable("UserProfiles");

                action.HasIndex(profile => profile.FirstName);
                action.HasIndex(profile => profile.LastName);
                action.HasIndex(profile => profile.BirthDate);

                action
                    .Property(profile => profile.Gender)
                    .HasConversion(
                        x => x.ToString(),
                        x => (Gender)Enum.Parse(typeof(Gender), x));
            });

            List<Role> roles = new()
        {
            new Role {
                Name = "Admin",
                Id = Guid.NewGuid(),
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role {
                Name = "Employee" ,
                Id = Guid.NewGuid(),
                NormalizedName = "EMPLOYEE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };

            modelBuilder.Entity<Role>(action =>
            {
                action.HasData(roles);
            });
        }
    }
}