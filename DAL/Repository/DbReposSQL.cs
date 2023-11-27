
namespace DAL
{
    public class DbReposSQL : IDbRepository
    {
        private ProjectManagementContext db;
        private AdministratorRepositorySQL AdministratorRepository;
        private ContractRepositorySQL ContractRepository;
        private CustomerRepositorySQL CustomerRepository;
        private DepartmentRepositorySQL DepartmentRepository;
        private EmployeeRepositorySQL EmployeeRepository;
        private ProjectRepositorySQL ProjectRepository;
        private TaskRepositorySQL TaskRepository;
        private TaskStatusRepositorySQL TaskStatusRepository;

        public DbReposSQL()
        {
            db = new ProjectManagementContext();
        }

        public IRepository<Administrator> Administrator
        {
            get
            {
                if (AdministratorRepository == null)
                    AdministratorRepository = new AdministratorRepositorySQL(db);
                return AdministratorRepository;
            }
        }


        public IRepository<Contract> Contract
        {
            get
            {
                if (ContractRepository == null)
                    ContractRepository = new ContractRepositorySQL(db);
                return ContractRepository;
            }
        }

        public IRepository<Customer> Customer
        {
            get
            {
                if (CustomerRepository == null)
                    CustomerRepository = new CustomerRepositorySQL(db);
                return CustomerRepository;
            }
        }

        public IRepository<Department> Department
        {
            get
            {
                if (DepartmentRepository == null)
                    DepartmentRepository = new DepartmentRepositorySQL(db);
                return DepartmentRepository;
            }
        }

        public IRepository<Employee> Employee
        {
            get
            {
                if (EmployeeRepository == null)
                    EmployeeRepository = new EmployeeRepositorySQL(db);
                return EmployeeRepository;
            }
        }


        public IRepository<Project> Project
        {
            get
            {
                if (ProjectRepository == null)
                    ProjectRepository = new ProjectRepositorySQL(db);
                return ProjectRepository;
            }
        }

        public IRepository<Task> Task
        {
            get
            {
                if (TaskRepository == null)
                    TaskRepository = new TaskRepositorySQL(db);
                return TaskRepository;
            }
        }

        public IRepository<TaskStatus> TaskStatus
        {
            get
            {
                if (TaskStatusRepository == null)
                    TaskStatusRepository = new TaskStatusRepositorySQL(db);
                return TaskStatusRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
