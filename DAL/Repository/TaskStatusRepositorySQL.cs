using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class TaskStatusRepositorySQL : IRepository<TaskStatus>
    {
        private ProjectManagementContext db;
        public TaskStatusRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<TaskStatus> GetList()
        {
            return db.TaskStatus.ToList();
        }

        public TaskStatus GetItem(int id)
        {
            return db.TaskStatus.Find(id);
        }

        public void Create(TaskStatus item)
        {
            db.TaskStatus.Add(item);
        }

        public void Update(TaskStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TaskStatus item = db.TaskStatus.Find(id);
            if (item != null)
                db.TaskStatus.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
