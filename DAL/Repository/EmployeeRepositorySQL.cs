using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class EmployeeRepositorySQL : IRepository<Employee>
    {
        private ProjectManagementContext db;
        public EmployeeRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Employee> GetList()
        {
            return db.Employee.ToList();
        }

        public Employee GetItem(int id)
        {
            return db.Employee.Find(id);
        }

        public void Create(Employee item)
        {
            db.Employee.Add(item);
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee item = db.Employee.Find(id);
            if (item != null)
                db.Employee.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
