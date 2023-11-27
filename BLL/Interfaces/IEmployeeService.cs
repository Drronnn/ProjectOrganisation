using System.Collections.Generic;

namespace BLL
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployees();
        List<DepartmentModel> GetDepartments();
        EmployeeModel CreateEmployee (EmployeeModel employee);
    }
}
