using EmployeeManagementModels.Entities.Projects;
using EmployeeManagementModels.Entities.TaskEntities;
using EmployeeManagementModels.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EmployeeManagementAPI.Brokers.Storages
{
    public class ManagementDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ManagementDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = this.configuration.GetConnectionString(name: "ManagementConnection");
            optionsBuilder.UseSqlServer(connectionString);
            
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetManagementProperties(modelBuilder);
        }

        private void SetManagementProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(task =>
            {
                task.HasOne(t => t.Project)
                    .WithMany(p => p.TaskEntities)
                    .HasForeignKey(t => t.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade); 

                // task.HasOne<User>()
                //     .WithMany()  
                //     .HasForeignKey(t => t.AssigneeID)
                //     .OnDelete(DeleteBehavior.SetNull); 
                //     //.OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}