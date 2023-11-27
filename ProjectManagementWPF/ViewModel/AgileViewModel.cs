using BLL;
using ProjectManagementWPF.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.TaskStatusModel;
using static ProjectManagementWPF.SideTaskMenuViewModel;

namespace ProjectManagementWPF
{
    public class AgileViewModel : INotifyPropertyChanged
    {
        #region Command

        private RelayCommand openTaskSideMenu;
        public RelayCommand OpenTaskSideMenuCommand
        {
            get
            {
                return openTaskSideMenu ?? (openTaskSideMenu = new RelayCommand(obj =>
                {


                    if (taskSideMenu.IsOpen())
                        CloseSideMenu();
                    else
                    {
                        int taskId = (int)obj;
                        FillSideTaskAndOpen(taskId);
                    }
                }));
            }
        }
        private RelayCommand openNewTask;
        public RelayCommand OpenNewTaskCommand
        {
            get
            {
                return openNewTask ?? (openNewTask = new RelayCommand(obj =>
                {
                    OpenNewTask();
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

        private bool _isAdministrator;
        public bool IsAdministrator
        {

            get { return _isAdministrator; }
            set
            {
                _isAdministrator = value;
                NotifyPropertyChanged("IsAdministrator");
            }
        }

        #endregion

        public struct TaskItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

        }
        public ObservableCollection<TaskItem> ToDoTasks { get; set; }
        public ObservableCollection<TaskItem> ProgressTasks { get; set; }
        public ObservableCollection<TaskItem> TestTasks { get; set; }
        public ObservableCollection<TaskItem> CompleteTasks { get; set; }

        private ITaskService taskService;
        private IProjectService projectService;
        private IAuthorizationService authorizationService;
        private IEmployeeService employeeService;
        private TaskSideMenu taskSideMenu;
        public AgileViewModel(ITaskService taskService,IProjectService projectService, IEmployeeService employeeService, IAuthorizationService authorizationService, TaskSideMenu taskSideMenu)
        {
            this.taskService = taskService;
            this.projectService = projectService;
            this.employeeService = employeeService;
            this.authorizationService = authorizationService;
            this.taskSideMenu = taskSideMenu;

            IsAdministrator = authorizationService.GetCurrentUser().Type == UserType.Administrator;

            ToDoTasks = new ObservableCollection<TaskItem>();
            ProgressTasks = new ObservableCollection<TaskItem>();
            TestTasks = new ObservableCollection<TaskItem>();
            CompleteTasks = new ObservableCollection<TaskItem>();

            FillAgileLists();
        }

        void FillAgileLists()
        {
            FillToDoList();
            FillProgressList();
            FillTestList();
            FillCompleteList();
        }

        public void FillToDoList()
        {
            ToDoTasks.Clear();
            var toDos = taskService.GetToDoTasks();

            foreach (var toDo in toDos)
            {
                ToDoTasks.Add(new TaskItem { Id = toDo.Id, Title = toDo.Title, Description = toDo.Description });
            }

        }

        public void FillTestList()
        {
            TestTasks.Clear();
            var tests = taskService.GetTestTasks();

            foreach (var test in tests)
            {
                TestTasks.Add(new TaskItem { Id = test.Id, Title = test.Title, Description = test.Description });
            }
        }

        public void FillProgressList()
        {
            ProgressTasks.Clear();
            var progresses = taskService.GetProgressTasks();

            foreach (var progress in progresses)
            {
                ProgressTasks.Add(new TaskItem { Id = progress.Id, Title = progress.Title, Description = progress.Description });
            }
        }

        public void FillCompleteList()
        {
            CompleteTasks.Clear();
            var completes = taskService.GetCompleteTasks();

            foreach (var complete in completes)
            {
                CompleteTasks.Add(new TaskItem { Id = complete.Id, Title = complete.Title, Description = complete.Description });
            }
        }

        void FillSideTaskAndOpen(int taskId)
        {
            var task = taskService.GetTask(taskId);
            taskSideMenu.CreateViewModel(this, taskService, projectService, employeeService,authorizationService, task);
            taskSideMenu.OpenSide();
        }

        void OpenNewTask()
        {
            taskSideMenu.CreateViewModel(this, taskService, projectService, employeeService, authorizationService, new TaskModel 
            { 
                Id = -1, 
                Description = "",
                ProjectId = -1,
                TaskStatusId = (int)TaskStatusEnum.ToDo,
                Title = "Новая задача",
                EmployeeId = null,
            });
            taskSideMenu.OpenSide();
        }

        public void CloseSideMenu()
        {
            taskSideMenu.CloseSide();
        }
    }
}
