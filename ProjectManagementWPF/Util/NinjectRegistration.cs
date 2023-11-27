using BLL;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementWPF
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskService>().To<TaskService>();
            Bind<IContractService>().To<ContractService>();
            Bind<ICustomerService>().To<CustomerService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IAuthorizationService>().To<AuthorizationService>();
            Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}
