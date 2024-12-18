using EmployeeManagementModels.Entities.TaskEntities;

namespace EmployeeManagementModels.Entities.Projects
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public ICollection<TaskEntity> TaskEntities { get; set; } = new List<TaskEntity>(); 
    }
}