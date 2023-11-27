using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class TaskRepositorySQL : IRepository<Task>
    {
        private ProjectManagementContext db;
        public TaskRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Task> GetList()
        {
            return db.Task.ToList();
        }

        public Task GetItem(int id)
        {
            return db.Task.Find(id);
        }

        public void Create(Task item)
        {
            db.Task.Add(item);
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Task item = db.Task.Find(id);
            if (item != null)
                db.Task.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
