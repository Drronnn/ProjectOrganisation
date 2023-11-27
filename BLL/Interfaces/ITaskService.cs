using System.Collections.Generic;
using static BLL.TaskStatusModel;

namespace BLL
{
    public interface ITaskService
    {
        List<TaskModel> GetToDoTasks();
        List<TaskModel> GetProgressTasks();
        List<TaskModel> GetTestTasks();
        List<TaskModel> GetCompleteTasks();
        void ChangeTaskStatus(int taskId, TaskStatusEnum status);
        TaskModel GetTask(int taskId);
        void UpdateTask(TaskModel task);
        void CreateTask(TaskModel task);
        void MoveTaskForward(int taskId);
        void SetTaskToEmployee(int taskId, int employeeId);
        void CancelTask(int taskId);
    }
}
