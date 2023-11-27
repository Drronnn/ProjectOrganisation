using BLL;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public  class ProjectViewModel
    {
        #region Command

        private RelayCommand addProject;
        public RelayCommand AddProjectCommand
        {
            get
            {
                return addProject ?? (addProject = new RelayCommand(obj =>
                {
                    NavigateToAddProjectPage();
                }));
            }
        }
        #endregion
        public struct ProjectItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string StartDateString { get; set; }
            public string EndDateString { get; set; }
            public string PriceString { get; set; }
            public int ContractId { get; set; }
            public string CustomerFIO { get; set; }

        }
        public ObservableCollection<ProjectItem> Projects { get; set; }
        public bool IsAdministrator { get; set; }

        private IProjectService projectService;
        private IContractService contractService;
        private Frame mainFrame;
        public ProjectViewModel(IProjectService projectService, Frame mainFrame, IContractService contractService, bool IsAdministrator)
        {

            this.projectService = projectService;
            this.contractService = contractService;
            this.mainFrame = mainFrame;
            this.IsAdministrator = IsAdministrator;
            Projects = new ObservableCollection<ProjectItem>();


            FillProjectLists();

        }

        void FillProjectLists()
        {
            var projectList = projectService.GetProjects();

            foreach (var project in projectList)
            {
                Projects.Add(new ProjectItem
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDateString = project.StartDate.ToString("dd/MM/yyyy"),
                    EndDateString = project.EndDate.ToString("dd/MM/yyyy"),
                    PriceString = project.Price.ToString() + " руб.",
                    ContractId = project.ContractId,
                    CustomerFIO = project.CustomerFIO,
                });
            }
        }

        void NavigateToAddProjectPage()
        {
            mainFrame.Navigate(new View.AddProjectPage(mainFrame, projectService, contractService));
        }

    }
}
