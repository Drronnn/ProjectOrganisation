using BLL;
using BLL.Services;
using Ninject;
using ProjectManagementWPF.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Command

        private RelayCommand navigate;
        public RelayCommand NavigateCommand
        {
            get
            {
                return navigate ?? (navigate = new RelayCommand(obj =>
                {
                    var real = (string)obj;
                    switch (real)
                    {
                        case "Agile":
                            NavigateToAgilePage();
                            break;
                        case "Employee":
                            NavigateToEmployeePage();
                            break;
                        case "Project":
                            NavigateToProjectPage();
                            break;
                        case "Contract":
                            NavigateToContractPage();
                            break;
                    }
                }));
            }
        }

        private RelayCommand logOutCommand;
        public RelayCommand LogOutCommand
        {
            get
            {
                return logOutCommand ?? (logOutCommand = new RelayCommand(obj =>
                {
                    authorizationService.LogOut();
                    authFrame.Navigate(new View.AuthorizationPage(authFrame, authorizationService, this));
                    IsLogin = false;
                }));
            }
        }

        private RelayCommand close;
        public RelayCommand CloseCommand
        {
            get
            {
                return close ?? (close = new RelayCommand(obj =>
                {
                    CloseWindow();
                }));
            }
        }

        private RelayCommand maxmin;
        public RelayCommand MaxMinCommand
        {
            get
            {
                return maxmin ?? (maxmin = new RelayCommand(obj =>
                {
                    MaxMinWindow();
                }));
            }
        }

        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isLogin;
        public bool IsLogin
        {

            get { return _isLogin; }
            set
            {
                _isLogin = value;
                NotifyPropertyChanged("IsLogin");
            }
        }
        #endregion

        private MainWindow mainWindow;
        private Frame mainFrame;
        private Frame authFrame;

        private ITaskService taskService;
        private IContractService contractService;
        private ICustomerService customerService;
        private IProjectService projectService;
        private IAuthorizationService authorizationService;
        private IEmployeeService employeeService;
        public MainWindowViewModel(StandardKernel kernel, MainWindow mainWindow, Frame mainFrame, Frame authFrame, IAuthorizationService authorizationService)
        {
            taskService = kernel.Get<ITaskService>();
            contractService = kernel.Get<IContractService>();
            customerService = kernel.Get<ICustomerService>();
            projectService = kernel.Get<IProjectService>();
            employeeService = kernel.Get<IEmployeeService>();

            this.authorizationService = authorizationService;

            IsLogin = authorizationService.GetCurrentUser().Type != UserType.Unauthorized;

            this.mainWindow = mainWindow;
            this.mainFrame = mainFrame;
            this.authFrame = authFrame;

        }

        void CloseWindow()
        {
            mainWindow.Close();
        }
        void MaxMinWindow()
        {
            if (mainWindow.WindowState == WindowState.Maximized)
                mainWindow.WindowState = WindowState.Normal;
            else
                mainWindow.WindowState = WindowState.Maximized;
        }

        void NavigateToAgilePage()
        {
            mainFrame.Navigate(new View.AgilePage(taskService, projectService, employeeService, authorizationService));
        }
        
        void NavigateToContractPage()
        {
            mainFrame.Navigate(new View.ContractPage(contractService, mainFrame, customerService, authorizationService.GetCurrentUser().Type == UserType.Administrator));
        }

        void NavigateToProjectPage()
        {
            mainFrame.Navigate(new View.ProjectPage(projectService, mainFrame, contractService, authorizationService.GetCurrentUser().Type == UserType.Administrator));
        }
        void NavigateToEmployeePage()
        {
            mainFrame.Navigate(new View.EmployeePage(employeeService, mainFrame, authorizationService.GetCurrentUser().Type == UserType.Administrator));
        }
        public void LogIn()
        {
            NavigateToAgilePage();
            mainWindow.ResetToAgile();
            IsLogin = true;
        }

    }
}
