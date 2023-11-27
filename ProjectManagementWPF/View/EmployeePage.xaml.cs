using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagementWPF.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private EmployeeViewModel VM;
        public EmployeePage(IEmployeeService employeeService, Frame mainFrame, bool IsAdministrator)
        {
            InitializeComponent();
            VM = new EmployeeViewModel(employeeService, mainFrame, IsAdministrator);
            DataContext = VM;
        }
    }
}
