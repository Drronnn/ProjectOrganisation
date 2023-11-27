using DAL;

namespace BLL
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string City { get; set; }

        public CustomerModel() { }

        public CustomerModel(Customer c)
        {
            Id = c.Id;
            FIO = c.FIO;
            City = c.City;
        }
    }
}
