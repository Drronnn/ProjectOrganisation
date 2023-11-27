using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ContractRepositorySQL : IRepository<Contract>
    {
        private ProjectManagementContext db;
        public ContractRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Contract> GetList()
        {
            return db.Contract.ToList();
        }

        public Contract GetItem(int id)
        {
            return db.Contract.Find(id);
        }

        public void Create(Contract item)
        {
            db.Contract.Add(item);
        }

        public void Update(Contract item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contract item = db.Contract.Find(id);
            if (item != null)
                db.Contract.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
