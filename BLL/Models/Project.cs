using DAL;
using System;

namespace BLL
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string CustomerFIO { get; set; }

        public ProjectModel() { }

        public ProjectModel(Project c)
        {
            Id = c.Id;
            ContractId = c.ContractId;
            Name = c.Name;
            StartDate = c.StartDate;
            EndDate = c.EndDate;
            Price = c.Price;
            CustomerFIO = c.Contract.Customer.FIO;
        }
    }
}
