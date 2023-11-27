using DAL;


namespace BLL
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TaskCount { get; set; }
        public string Login { get;set; }
        public string Password { get; set; }
        public EmployeeModel() { }

        public EmployeeModel(Employee c)
        {
            Id = c.Id;
            FIO = c.FIO;
            DepartmentId = c.DepartmentId;
            DepartmentName = c.Department.Name;
            Login = c.Login;
            Password = c.Password;
            TaskCount = c.Task.Count;
        }
    }
}
