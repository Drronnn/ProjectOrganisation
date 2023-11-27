using BLL;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public class EmployeeViewModel
    {
        #region Command

        private RelayCommand addEmployee;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return addEmployee ?? (addEmployee = new RelayCommand(obj =>
                {
                    NavigateToAddEmployeePage();
                }));
            }
        }
        #endregion
        public struct EmployeeItem
        {
            public int Id { get; set; }
            public string FIO { get; set; }
            public string DepartmentName { get; set; }
            public int TaskCount { get; set; }

        }
        public ObservableCollection<EmployeeItem> Employees { get; set; }
        public bool IsAdministrator { get; set; }

        private IEmployeeService employeeService;
        private Frame mainFrame;
        public EmployeeViewModel(IEmployeeService employeeService, Frame mainFrame, bool IsAdministrator)
        {

            this.employeeService = employeeService;
            this.mainFrame = mainFrame;
            this.IsAdministrator = IsAdministrator;

            Employees = new ObservableCollection<EmployeeItem>();


            FillEmployeeLists();

        }

        void FillEmployeeLists()
        {
            var employeeList = employeeService.GetEmployees();

            foreach (var employee in employeeList)
            {
                Employees.Add(new EmployeeItem
                {
                    Id = employee.Id,
                    DepartmentName = employee.DepartmentName,
                    FIO = employee.FIO,
                    TaskCount = employee.TaskCount,
                });
            }
        }

        void NavigateToAddEmployeePage()
        {
            mainFrame.Navigate(new View.AddEmployeePage(mainFrame, employeeService));
        }
    }
}
