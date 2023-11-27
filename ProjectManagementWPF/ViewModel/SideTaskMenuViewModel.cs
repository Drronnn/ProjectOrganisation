using BLL;
using ProjectManagementWPF.Window;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static BLL.TaskStatusModel;

namespace ProjectManagementWPF
{
    public class SideTaskMenuViewModel : INotifyPropertyChanged
    {
        public class TaskInfo
        {
            public string TaskTitle { get; set; }
            public string Description { get; set; }
            public int? EmployeeId { get; set; }
            public int ProjectId { get; set; }
            public string MainButtonText { get; set; }
            public string SecondButtonText { get; set; }
            public int TaskStatusId { get; set; }
        }

        public struct ProjectItem 
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public struct EmployeeItem
        {
            public int Id { get; set; }
            public string FIO { get; set; }
        }


        #region Command

        private RelayCommand mainButton;
        public RelayCommand MainButtonCommand
        {
            get
            {
                return mainButton ?? (mainButton = new RelayCommand(obj =>
                {
                    if (isNewTask)
                        CreateTask();
                    else
                    {
                        if (IsAdministrator)
                            UpdateTask();
                        else if (taskModel.TaskStatusId == (int)TaskStatusEnum.ToDo)
                            SetTaskToEmployee();
                        else
                            MoveTaskForward();
                    }
                }));
            }
        }

        private RelayCommand secondButton;
        public RelayCommand SecondButtonCommand
        {
            get
            {
                return secondButton ?? (secondButton = new RelayCommand(obj => { 

                    if (IsAdministrator)
                        RemoveTask(false);
                    else
                        CancelTask();
                }));
            }
        }

        private RelayCommand completeTask;
        public RelayCommand CompleteTaskCommand
        {
            get
            {
                return completeTask ?? (completeTask = new RelayCommand(obj => {

                    if (IsAdministrator)
                    {
                        RemoveTask(true);
                    }
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

        private TaskInfo _currentTask;
        public TaskInfo CurrentTask
        {

            get { return _currentTask; }
            set
            {
                _currentTask = value;
                NotifyPropertyChanged("CurrentTask");
            }
        }

        private bool _isNewTask;
        public bool isNewTask
        {

            get { return _isNewTask; }
            set
            {
                _isNewTask = value;
                NotifyPropertyChanged("isNewTask");
            }
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

        public ObservableCollection<ProjectItem> Projects { get; set; }
        public ObservableCollection<EmployeeItem> Employees { get; set; }

        private TaskModel taskModel;
        private ITaskService taskService;
        private IProjectService projectService;
        private IEmployeeService employeeService;
        private IAuthorizationService authorizationService;
        private AgileViewModel agileViewModel;
        public SideTaskMenuViewModel(AgileViewModel agileViewModel, ITaskService taskService, IProjectService projectService, IEmployeeService employeeService, IAuthorizationService authorizationService, TaskModel taskModel)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
            this.projectService = projectService;
            this.employeeService = employeeService;
            this.taskModel = taskModel;
            this.agileViewModel = agileViewModel;

            IsAdministrator = this.authorizationService.GetCurrentUser().Type == UserType.Administrator;

            Projects = new ObservableCollection<ProjectItem>();
            Employees = new ObservableCollection<EmployeeItem>();

            SetNewTask();
        }

        void SetNewTask()
        {
            FillProjectList();
            FillEmployeeList();

            if (taskModel.Id == -1)
                isNewTask = true;
            else
                isNewTask = false;

            CurrentTask = new TaskInfo
            {
                TaskTitle = taskModel.Title,
                Description = taskModel.Description,
                EmployeeId = taskModel.EmployeeId,
                ProjectId = taskModel.ProjectId,
                TaskStatusId = taskModel.TaskStatusId,
                MainButtonText = isNewTask ? "ДОБАВИТЬ" : IsAdministrator ? "СОХРАНИТЬ" : taskModel.TaskStatusId == (int)TaskStatusEnum.ToDo ? "ВЗЯТЬ" : "ПОДТВЕРДИТЬ ЭТАП",
                SecondButtonText = isNewTask ? "" : IsAdministrator ? "ОТМЕНИТЬ" : "ОТКАЗАТЬСЯ",
            };  
        }

        void FillProjectList()
        {
            var projectList = projectService.GetProjects();
            foreach (var project in projectList)
            {
                Projects.Add(new ProjectItem
                {
                    Id = project.Id,
                    Name = project.Name,   
                });
            }
        }
        void FillEmployeeList()
        {
            var employeeList = employeeService.GetEmployees();
            foreach (var employee in employeeList)
            {
                Employees.Add(new EmployeeItem
                {
                    Id = employee.Id,
                    FIO = employee.FIO,
                });
            }
        }

        void CreateTask()
        {
            if (CurrentTask.TaskTitle == null || CurrentTask.TaskTitle == "" ||
                CurrentTask.Description == null || CurrentTask.Description == "" ||
                CurrentTask.ProjectId == -1)
                return;

            TaskStatusEnum taskStatus = CurrentTask.EmployeeId == null ? TaskStatusEnum.ToDo : TaskStatusEnum.Progress;

            taskService.CreateTask(new TaskModel
            {
                Id = -1,
                TaskStatusId = (int)taskStatus,
                Description = CurrentTask.Description,
                EmployeeId = CurrentTask.EmployeeId,
                ProjectId = CurrentTask.ProjectId,
                Title = CurrentTask.TaskTitle
            });
            if (taskStatus == TaskStatusEnum.ToDo)
                agileViewModel.FillToDoList();
            else 
                agileViewModel.FillProgressList();

            agileViewModel.CloseSideMenu();
        }

        void UpdateTask()
        {
            if (CurrentTask.TaskTitle == null || CurrentTask.TaskTitle == "" ||
                CurrentTask.Description == null || CurrentTask.Description == "" ||
                CurrentTask.ProjectId == -1)
                return;

            taskService.UpdateTask(new TaskModel
            {
                Id = taskModel.Id,
                TaskStatusId = taskModel.TaskStatusId,
                Description = CurrentTask.Description,
                EmployeeId = CurrentTask.EmployeeId,
                ProjectId = taskModel.ProjectId,
                Title = CurrentTask.TaskTitle
            });

            agileViewModel.FillToDoList();
            agileViewModel.FillProgressList();
            agileViewModel.FillTestList();
            agileViewModel.FillCompleteList();

            agileViewModel.CloseSideMenu();
        }

        void SetTaskToEmployee()
        {
            if (taskModel.Id == -1)
                return;
            if (taskModel.EmployeeId != null)
                return;

            CurrentTask.EmployeeId = authorizationService.GetCurrentUser().Id;

            taskService.SetTaskToEmployee(taskModel.Id, (int)CurrentTask.EmployeeId);

            agileViewModel.FillProgressList();
            agileViewModel.FillToDoList();
            agileViewModel.CloseSideMenu();
        }

        void MoveTaskForward()
        {
            if (taskModel.EmployeeId != authorizationService.GetCurrentUser().Id)
                return;

            taskService.MoveTaskForward(taskModel.Id);
            agileViewModel.FillProgressList();
            agileViewModel.FillTestList();
            agileViewModel.FillCompleteList();
            agileViewModel.CloseSideMenu();
        }

        void RemoveTask(bool isCompleted)
        {
            taskService.ChangeTaskStatus(taskModel.Id, TaskStatusEnum.Removed);
            agileViewModel.FillProgressList();

            agileViewModel.FillToDoList();
            agileViewModel.FillTestList();
            agileViewModel.FillCompleteList();
            agileViewModel.CloseSideMenu();

            NotificationWindow notificationWindow;

            if (isCompleted)
                notificationWindow = new NotificationWindow("Задача успешно\nзавершена");
            else
                notificationWindow = new NotificationWindow("Задача отменена");
            notificationWindow.ShowDialog();
        }

        void CancelTask()
        {
            if (taskModel.EmployeeId == null)
                return;
            if (taskModel.EmployeeId != authorizationService.GetCurrentUser().Id)
                return;

            taskService.CancelTask(taskModel.Id);

            agileViewModel.FillToDoList();
            agileViewModel.FillProgressList();
            agileViewModel.FillTestList();
            agileViewModel.CloseSideMenu();

            NotificationWindow notificationWindow = new NotificationWindow("Вы отказались\nот задачи");
            notificationWindow.ShowDialog();
        }
    }
}
