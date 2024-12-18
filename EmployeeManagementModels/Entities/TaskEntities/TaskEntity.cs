using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EmployeeManagementModels.Entities.Projects;
using EmployeeManagementModels.Entities.Users;

namespace EmployeeManagementModels.Entities.TaskEntities;
public class TaskEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? DueDate { get; set; }
    public Status? Status { get; set; }
    public Priority? Priority { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public Guid? AssigneeID { get; set; }
    public Guid ProjectId { get; set; }

    [JsonIgnore]
    public virtual Project Project { get; set; }
}