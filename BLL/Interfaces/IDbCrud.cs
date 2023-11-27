using System.Collections.Generic;


namespace BLL
{
    public interface IDbCrud
    {
        List<TaskModel> GetTasks();
        List<TaskModel> GetToDoTasks();
        List<TaskModel> GetProgressTasks();
        List<TaskModel> GetTestTasks();
        List<TaskModel> GetCompleteTasks();
        TaskModel GetTask(int taskId);
    }
}
