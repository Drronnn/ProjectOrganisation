using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class CustomerRepositorySQL : IRepository<Customer>
    {
        private ProjectManagementContext db;
        public CustomerRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Customer> GetList()
        {
            return db.Customer.ToList();
        }

        public Customer GetItem(int id)
        {
            return db.Customer.Find(id);
        }

        public void Create( Customer item)
        {
            db.Customer.Add(item);
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer item = db.Customer.Find(id);
            if (item != null)
                db.Customer.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
