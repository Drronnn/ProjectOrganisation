using Ninject.Modules;
using DAL;

namespace BLL
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IDbRepository>().To<DbReposSQL>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
