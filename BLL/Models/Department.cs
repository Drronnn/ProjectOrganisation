using DAL;


namespace BLL
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public DepartmentModel() { }

        public DepartmentModel(Department c)
        {
            Id = c.Id;
            Name = c.Name;
            Phone = c.Phone;
        }
    }
}
