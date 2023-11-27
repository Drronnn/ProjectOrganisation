using DAL;
using System;

namespace BLL
{
    public class ContractModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public int ProjectCount { get; set; }
        public string CustomerFIO { get; set; }

        public ContractModel() { }

        public ContractModel(Contract c)
        {
            Id = c.Id;
            CustomerId = c.CustomerId;
            StartDate = c.StartDate;
            EndDate = c.EndDate;
            Price = c.Price;
            ProjectCount = c.ProjectCount;
            CustomerFIO = c.Customer.FIO;
        }
    }
}
