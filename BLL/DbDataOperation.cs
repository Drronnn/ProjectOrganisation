using DAL;
using System.Collections.Generic;
using System.Linq;


namespace BLL
{
    public class DbDataOperation : IDbCrud
    {
        IDbRepository db;

        public DbDataOperation(IDbRepository repos)
        {
            db = repos;
        }

        public List<TaskModel> GetCompleteTasks()
        {
            return db.Task.GetList().Where(i => i.TaskStatusId == 4).Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetProgressTasks()
        {
            return db.Task.GetList().Where(i => i.TaskStatusId == 2).Select(i => new TaskModel(i)).ToList();
        }

        public TaskModel GetTask(int taskId)
        {
            return new TaskModel(db.Task.GetItem(taskId));
        }

        public List<TaskModel> GetTasks()
        {
            return db.Task.GetList().Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetTestTasks()
        {
            return db.Task.GetList().Where(i => i.TaskStatusId == 3).Select(i => new TaskModel(i)).ToList();
        }

        public List<TaskModel> GetToDoTasks()
        {
            return db.Task.GetList().Where(i => i.TaskStatusId == 1).Select(i => new TaskModel(i)).ToList();
        }
    }
}
