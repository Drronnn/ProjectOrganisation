using BLL;
using ProjectManagementWPF.Window;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public class AddEmployeeViewModel
    {
        public struct DepartmentItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        #region Command


        private RelayCommand addNewEmployee;
        public RelayCommand AddNewEmployeeCommand
        {
            get
            {
                return addNewEmployee ?? (addNewEmployee = new RelayCommand(obj =>
                {
                    var values = (object[])obj;

                    if (values[0] == null || values[1] == null)
                        return;

                    string name = (string)values[0];
                    int departmentId = (int)values[1];

                    CreateNewEmployee(name, departmentId);

                    mainFrame.Navigate(new View.EmployeePage(employeeService, mainFrame, true));

                }));
            }
        }

        #endregion

        private Frame mainFrame;
        private IEmployeeService employeeService;

        public ObservableCollection<DepartmentItem> Departments { get; set; }
        public AddEmployeeViewModel(Frame mainFrame, IEmployeeService employeeService)
        {
            this.mainFrame = mainFrame;
            this.employeeService = employeeService;

            Departments = new ObservableCollection<DepartmentItem>();
            FillDepartmentList();
        }

        void FillDepartmentList()
        {
            var departmentList = employeeService.GetDepartments();
            foreach (var department in departmentList)
                Departments.Add(new DepartmentItem
                {
                    Id = department.Id,
                    Name = department.Name,
                });
        }

        void CreateNewEmployee(string FIO, int departmentId)
        {
            var newEmployee = employeeService.CreateEmployee(new EmployeeModel
            {
                Id = -1,
                DepartmentId = departmentId,
                FIO = FIO,
                TaskCount = 0,
                Login = "",
                Password = ""
            });

            NotificationWindow notification = new NotificationWindow("Новый сотрудник создан\nЛогин: " + newEmployee.Login + "\nПароль: " + newEmployee.Password);
            notification.ShowDialog();
        }
    }
}
