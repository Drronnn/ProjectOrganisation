using DAL;

namespace BLL
{
    public class AdministratorModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Login { get;set; }
        public string Password { get; set; }
        public AdministratorModel() { }

        public AdministratorModel(Administrator c)
        {
            Id = c.Id;
            FIO = c.FIO;
            Login = c.Login;
            Password = c.Password;
        }
    }
}
