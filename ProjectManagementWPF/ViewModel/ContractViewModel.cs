using BLL;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectManagementWPF
{
    public class ContractViewModel
    {
        #region Command

        private RelayCommand addContract;
        public RelayCommand AddContractCommand
        {
            get
            {
                return addContract ?? (addContract = new RelayCommand(obj =>
                {
                    NavigateToAddContractPage();
                }));
            }
        }
        #endregion
        public struct ContractItem
        {
            public int Id { get; set; }
            public string FIO { get; set; }
            public string StartDateString { get; set; }
            public string EndDateString { get; set; }
            public string PriceString { get; set; }
            public string ProjectCount { get; set; }

        }
        public ObservableCollection<ContractItem> Contracts { get; set; }
        public bool IsAdministrator { get; set; }

        private IContractService contractService;
        private ICustomerService customerService;
        private Frame mainFrame;
        public ContractViewModel(IContractService contractService, ICustomerService customerService, Frame mainFrame, bool IsAdministrator)
        {
            
            this.contractService = contractService;
            this.customerService = customerService;
            this.mainFrame = mainFrame;
            this.IsAdministrator = IsAdministrator;

            Contracts = new ObservableCollection<ContractItem>();


            FillContractLists();

        }

        void FillContractLists()
        {
            var contractList = contractService.GetContracts();

            foreach (var contract in contractList)
            {
                Contracts.Add(new ContractItem
                {
                    Id = contract.Id,
                    FIO = contract.CustomerFIO,
                    StartDateString = contract.StartDate.ToString("dd/MM/yyyy"),
                    EndDateString = contract.EndDate.ToString("dd/MM/yyyy"),
                    PriceString = contract.Price.ToString() + " руб.",
                    ProjectCount = contractService.GetCurrentProjectCountForContract(contract.Id).ToString() + " / " + contract.ProjectCount.ToString()
                });
            }
        }

        void NavigateToAddContractPage()
        {
            mainFrame.Navigate(new View.AddContractPage(mainFrame, customerService, contractService));
        }
    }
}
