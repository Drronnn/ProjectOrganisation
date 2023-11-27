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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private AddEmployeeViewModel VM;
        public AddEmployeePage(Frame mainFrame, IEmployeeService employeeService)
        {
            InitializeComponent();
            VM = new AddEmployeeViewModel(mainFrame, employeeService);
            DataContext = VM;
        }
    }
}
