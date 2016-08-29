using System.Configuration;

namespace Imposto.Core.Data
{
   public static class BaseDao
    {
       public static string ObterConectionString()
       {
           return ConfigurationManager.ConnectionStrings["Conn"].ToString();
       }
    }
}