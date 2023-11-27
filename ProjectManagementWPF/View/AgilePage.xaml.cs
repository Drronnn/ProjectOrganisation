using BLL;
using ProjectManagementWPF.Components;
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
    /// Логика взаимодействия для AgilePage.xaml
    /// </summary>
    public partial class AgilePage : Page
    {
        private AgileViewModel VM;
        public AgilePage(ITaskService tServ, IProjectService projectService, IEmployeeService employeeService, IAuthorizationService authorizationService)
        {
            InitializeComponent();

            VM = new AgileViewModel(tServ, projectService, employeeService, authorizationService, taskSideMenu);
            DataContext = VM;
        }
    }
}
