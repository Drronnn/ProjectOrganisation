

namespace DAL
{
    public interface IDbRepository
    {
        IRepository<Administrator> Administrator { get; }
        IRepository<Contract> Contract { get; }
        IRepository<Customer> Customer { get; }
        IRepository<Department> Department { get; }
        IRepository<Employee> Employee { get; }
        IRepository<Project> Project { get; }
        IRepository<Task> Task { get; }
        IRepository<TaskStatus> TaskStatus { get; }
        int Save();
    }
}
