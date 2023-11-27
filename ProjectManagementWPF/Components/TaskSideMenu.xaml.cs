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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagementWPF.Components
{
    /// <summary>
    /// Логика взаимодействия для TaskSideMenu.xaml
    /// </summary>
    public partial class TaskSideMenu : UserControl
    {
        private SideTaskMenuViewModel VM;
        private bool isOpen = false;
        public TaskSideMenu()
        {
            InitializeComponent();
            DataContext = VM;
        }

        public void CreateViewModel(AgileViewModel agileViewModel, ITaskService taskService, IProjectService projectService, IEmployeeService employeeService, IAuthorizationService authorizationService, TaskModel task)
        {
            VM = new SideTaskMenuViewModel(agileViewModel, taskService, projectService, employeeService, authorizationService, task);
            DataContext = VM;
        }

        public void OpenSide()
        {
            isOpen = true;
            ThicknessAnimation da = new ThicknessAnimation();
            da.Duration = TimeSpan.FromSeconds(0.3);
            da.EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut };
            da.To = new System.Windows.Thickness(0, 0, 0, 0);
            BeginAnimation(MarginProperty, da);

        }
        public void CloseSide()
        {
            isOpen = false;
            ThicknessAnimation da = new ThicknessAnimation();
            da.Duration = TimeSpan.FromSeconds(0.3);
            da.EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut };
            da.To = new System.Windows.Thickness(0, 0, -500, 0);
            BeginAnimation(MarginProperty, da);
        }

        public bool IsOpen()
        {
            return isOpen;
        }
    }
}
