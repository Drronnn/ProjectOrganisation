using BLL;
using ProjectManagementWPF.Window;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public class AddProjectViewModel
    {
        public struct ContractItem
        {
            public int Id { get; set; }
            public string DisplayInfo { get; set; }
        }

        #region Command


        private RelayCommand addNewProject;
        public RelayCommand AddNewProjectCommand
        {
            get
            {
                return addNewProject ?? (addNewProject = new RelayCommand(obj =>
                {
                    var values = (object[])obj;

                    if (values[0] == null || values[1] == null || values[2] == null || values[3] == null)
                        return;

                    string name = (string)values[0];
                    int contractId = (int)values[1];
                    decimal price = (decimal)values[2];
                    DateTime endTime = (DateTime)values[3];

                    CreateNewProject(contractId, price, name, DateTime.Now, endTime);

                    mainFrame.Navigate(new View.ProjectPage(projectService, mainFrame, contractService, true));

                }));
            }
        }

        #endregion

        private Frame mainFrame;
        private IProjectService projectService;
        private IContractService contractService;

        public DateTime TodayDate { get { return DateTime.Now; } set { TodayDate = value; } }
        public ObservableCollection<ContractItem> Contracts { get; set; }
        public AddProjectViewModel(Frame mainFrame, IProjectService projectService, IContractService contractService)
        {
            this.mainFrame = mainFrame;
            this.projectService = projectService;
            this.contractService = contractService;

            Contracts = new ObservableCollection<ContractItem>();
            FillContractList();
        }

        void FillContractList()
        {
            var contractList = contractService.GetContracts();
            foreach (var contract in contractList)
                Contracts.Add(new ContractItem
                {
                    Id = contract.Id,
                    DisplayInfo = "№" + contract.Id.ToString() + " : " + contract.CustomerFIO,
                });
        }

        void CreateNewProject(int contractId, decimal price, string name, DateTime startDate, DateTime endDate)
        {
            var result = projectService.CreateProject(new ProjectModel
            {
                Id = -1,
                ContractId = contractId,
                EndDate = endDate,
                StartDate = startDate,
                CustomerFIO = "",
                Name = name,
                Price = price,
            });
            NotificationWindow notification;
            switch (result)
            {
                case ProjectCreationResult.Success:
                    notification = new NotificationWindow("Проект создан");
                    notification.ShowDialog();
                    break;
                case ProjectCreationResult.FailureFullContract:
                    notification = new NotificationWindow("Этот контракт\nисчерпал свои проекты");
                    notification.ShowDialog();
                    break;
                case ProjectCreationResult.FailureNoMoneyForContract:
                    notification = new NotificationWindow("Бюджет контракта\nне потянет");
                    notification.ShowDialog();
                    break;
            }

            }
        }

    }

