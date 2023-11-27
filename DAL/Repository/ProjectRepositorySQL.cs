using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ProjectRepositorySQL : IRepository<Project>
    {
        private ProjectManagementContext db;
        public ProjectRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Project> GetList()
        {
            return db.Project.ToList();
        }

        public Project GetItem(int id)
        {
            return db.Project.Find(id);
        }

        public void Create(Project item)
        {
            db.Project.Add(item);
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Project item = db.Project.Find(id);
            if (item != null)
                db.Project.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
