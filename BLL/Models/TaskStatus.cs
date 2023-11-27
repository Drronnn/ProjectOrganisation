using DAL;
using System.Security.Policy;

namespace BLL
{
    public class TaskStatusModel
    {
        public enum TaskStatusEnum {ToDo = 1 ,Progress = 2, Test = 3, Complete = 4, Removed = 5 }
        public int Id { get; set; }
        public string Name { get; set; }

        public TaskStatusModel() { }

        public TaskStatusModel(TaskStatus c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }
}
