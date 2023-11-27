using DAL;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int TaskStatusId {  get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        [MaxLength(15)]
        public string Title { get; set; }
        public int? EmployeeId { get; set; }

        public TaskModel() { }

        public TaskModel(Task c)
        {
            Id = c.Id;
            TaskStatusId = c.TaskStatusId;
            ProjectId = c.ProjectId;
            Description = c.Description;
            Title = c.Title;
            EmployeeId = c.EmployeeId;
        }
    }
}
