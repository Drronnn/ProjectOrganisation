using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DepartmentRepositorySQL : IRepository<Department>
    {
        private ProjectManagementContext db;
        public DepartmentRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Department> GetList()
        {
            return db.Department.ToList();
        }

        public Department GetItem(int id)
        {
            return db.Department.Find(id);
        }

        public void Create(Department item)
        {
            db.Department.Add(item);
        }

        public void Update(Department item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Department item = db.Department.Find(id);
            if (item != null)
                db.Department.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
