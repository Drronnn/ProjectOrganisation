using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class AuthorizationService : IAuthorizationService
    {
        IDbRepository context;
        UserInfo curUser;

        public AuthorizationService(IDbRepository context)
        {
            this.context = context;
            curUser = new UserInfo { Type = UserType.Unauthorized, Id = -1, Name = "" };
        }

        public UserInfo GetCurrentUser()
        {
            return curUser;
        }

        public bool TryAuthorization(string login, string password)
        {
            Employee e = context.Employee.GetList().Where(i => i.Login == login).FirstOrDefault();
            if (e != null)
            {
                if (e.Password == password)
                {
                    curUser.Type = UserType.Employee;
                    curUser.Id = e.Id;
                    curUser.Name = e.FIO;
                    return true;
                }

            }

            Administrator a = context.Administrator.GetList().Where(i => i.Login == login).FirstOrDefault();

            if (a != null)
            {
                if (a.Password == password)
                {
                    curUser.Type = UserType.Administrator;
                    curUser.Id = a.Id;
                    curUser.Name = a.FIO;
                    return true;
                }

                return false;
            }

            return false;
        }

        public void LogOut()
        {
            curUser.Type = UserType.Unauthorized;
            curUser.Id = -1;
        }

        public void CreateEmployee(string FIO, int departmentId, string login, string password)
        {
            Employee e = new Employee
            {
                Id = context.Employee.GetList().FirstOrDefault() == null ? 1 : context.Employee.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1,
                FIO = FIO,
                DepartmentId = departmentId,
                Department = context.Department.GetItem(departmentId),
                Login = login,
                Password = password,
                Task = new List<DAL.Task>(),
            };

            context.Employee.Create(e);
            context.Save();
        }
    }
}
