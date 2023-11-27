namespace BLL
{
    public struct UserInfo
    {
        public UserType Type;
        public int Id;
        public string Name;
    }
    public enum UserType { Unauthorized = 0, Employee, Administrator }
    public interface IAuthorizationService
    {
        UserInfo GetCurrentUser();

        bool TryAuthorization(string login, string password);

        void LogOut();

        void CreateEmployee(string FIO, int departmentId, string login, string password);
    }

}
