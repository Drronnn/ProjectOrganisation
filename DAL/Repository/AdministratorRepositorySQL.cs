using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL
{
    internal class AdministratorRepositorySQL : IRepository<Administrator>
    {
        private ProjectManagementContext db;
        public AdministratorRepositorySQL(ProjectManagementContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Administrator> GetList()
        {
            return db.Administrator.ToList();
        }

        public Administrator GetItem(int id)
        {
            return db.Administrator.Find(id);
        }

        public void Create(Administrator item)
        {
            db.Administrator.Add(item);
        }

        public void Update(Administrator item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Administrator item = db.Administrator.Find(id);
            if (item != null)
                db.Administrator.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}