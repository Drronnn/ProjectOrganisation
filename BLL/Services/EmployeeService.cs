using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeService : IEmployeeService
    {
        IDbRepository context;

        public EmployeeService(IDbRepository context)
        {
            this.context = context;
        }
        public EmployeeModel CreateEmployee(EmployeeModel employee)
        {
            if (employee.Id == -1)
                employee.Id = context.Employee.GetList().FirstOrDefault() == null ? 1 : context.Employee.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            employee.Login = employee.FIO.Split(' ')[0] + employee.Id.ToString();

            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+-!*=";
            int length = 6; // задаем длину строки
            string result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            employee.Password = result;
            Employee c = new Employee
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                Department = context.Department.GetItem(employee.DepartmentId),
                FIO = employee.FIO,
                Login = employee.Login,
                Password = employee.Password,
                Task = new List<DAL.Task>(),
            };

            context.Employee.Create(c);

            context.Save();

            return employee;
        }

        public List<DepartmentModel> GetDepartments()
        {
            return context.Department.GetList().Select(i => new DepartmentModel(i)).ToList();
        }

        public List<EmployeeModel> GetEmployees()
        {
            return context.Employee.GetList().Select(i => new EmployeeModel(i)).ToList();
        }
    }
}
