using System.Configuration;

namespace Repositories.Factory
{
    public class Factories
    {
        public static IFactory GetFactory()
        {
            string type = ConfigurationManager.AppSettings["factoryType"].ToString();
            switch (type)
            {
                case "ef":
                    return new EFFactory();
                case "ado":
                    return new ADOFactory();
                default:
                    return new EFFactory();
            }
        }
    }
}
