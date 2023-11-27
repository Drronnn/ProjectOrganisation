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
    public class AddContractViewModel : INotifyPropertyChanged
    {
        public struct CustomerItem 
        { 
            public int Id { get; set; }
            public string FIO { get; set; }
        }

        #region Command

        private RelayCommand changeCustomerType;
        public RelayCommand ChangeCustomerType
        {
            get
            {
                return changeCustomerType ?? (changeCustomerType = new RelayCommand(obj =>
                {
                    var real = (string)obj;
                    switch(real)
                    {
                        case "New":
                            IsNewCustomer = true;
                            break;
                        case "Old":
                            IsNewCustomer = false;
                            break;
                    }
                }));
            }
        }

        private RelayCommand addNewContract;
        public RelayCommand AddNewContractCommand
        {
            get
            {
                return addNewContract ?? (addNewContract = new RelayCommand(obj =>
                {
                    var values = (object[])obj;

                    if (IsNewCustomer)
                    {
                        if (values[0] == null || values[1] == null)
                            return;
                    }
                    else if(values[2] == null)
                        return;

                    if (values[3] == null || values[4] == null)
                        return;

                    int customerId = -1;

                    if (IsNewCustomer)
                        customerId = CreateNewCustomer((string)values[0], (string)values[1]);
                    else
                     customerId = (int)values[2];

                    decimal price = (decimal)values[3];
                    DateTime endTime = (DateTime)values[4];

                    CreateNewContract(customerId, price, ProjectCount, DateTime.Now, endTime);

                    mainFrame.Navigate(new View.ContractPage(contractService, mainFrame, customerService, true));

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

        private bool _isNewCustomer;
        public bool IsNewCustomer
        {

            get { return _isNewCustomer; }
            set
            {
                _isNewCustomer = value;
                NotifyPropertyChanged("IsNewCustomer");
            }
        }

        private int _projectCount;
        public int ProjectCount
        {

            get { return _projectCount; }
            set
            {
                _projectCount = value;
                NotifyPropertyChanged("ProjectCount");
            }
        }


        private decimal _projectPrice;
        public decimal ProjectPrice
        {

            get { return _projectPrice; }
            set
            {
                _projectPrice = value;
                UpdateProjectCount();
                NotifyPropertyChanged("ProjectPrice");
            }
        }
        #endregion

        private Frame mainFrame;
        private ICustomerService customerService;
        private IContractService contractService;

        public DateTime TodayDate { get { return DateTime.Now; } set { TodayDate = value; }  }
        public ObservableCollection<CustomerItem> Customers { get; set; }
        public AddContractViewModel(Frame mainFrame, ICustomerService customerService, IContractService contractService)
        {
            this.mainFrame = mainFrame;
            this.customerService = customerService;
            this.contractService = contractService;

            IsNewCustomer = true;
            ProjectPrice = 0;
            UpdateProjectCount();
            Customers = new ObservableCollection<CustomerItem>();
            FillCustomersList();
        }

        void FillCustomersList()
        {
            var customerList = customerService.GetCustomers();
            foreach (var customer in customerList)
                Customers.Add(new CustomerItem 
                {
                    Id = customer.Id,
                    FIO = customer.FIO,
                });
        }

        void CreateNewContract(int customerId, decimal price, int projectCount, DateTime startDate, DateTime endDate)
        {
            var result = contractService.CreateContract(new ContractModel
            {
                Id = -1,
                EndDate = endDate,
                StartDate = startDate,
                CustomerId = customerId,
                CustomerFIO = "",
                Price = price,
                ProjectCount = projectCount,
            });
            NotificationWindow notification;
            switch (result)
            {
                case CreateContractResult.Success:
                    notification = new NotificationWindow("Контракт создан");
                    notification.ShowDialog();
                    break;
                case CreateContractResult.FailureSmallPrice:
                    notification = new NotificationWindow("Нельзя создать контракт\nс 0 проектов");
                    notification.ShowDialog();
                    break;
            }
        }

        int CreateNewCustomer(string customerFIO, string customerCity)
        {
            return customerService.CreateCustomer(new CustomerModel
            {
                Id = -1,
                FIO = customerFIO,
                City = customerCity,
            });
        }

        void UpdateProjectCount()
        {
            ProjectCount = contractService.CalculateProjectCountFromPrice(ProjectPrice);
        }
    }
}
