using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerService : ICustomerService
    {
        IDbRepository context;

        public CustomerService(IDbRepository context)
        {
            this.context = context;
        }
        public int CreateCustomer(CustomerModel customer)
        {
            if (customer.Id == -1)
                customer.Id = context.Customer.GetList().FirstOrDefault() == null ? 1 : context.Customer.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            Customer c = new Customer
            {
                Id = customer.Id,
                FIO = customer.FIO,
                City = customer.City,
                Contract = new List<Contract>(),
            };

            context.Customer.Create(c);
            context.Save();

            return customer.Id;
        }

        public List<CustomerModel> GetCustomers()
        {
            return context.Customer.GetList().Select(i => new CustomerModel(i)).ToList();
        }
    }
}
