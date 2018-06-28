namespace DataAccessLayer
{
    using System.Configuration;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class OrderData
    {
        private readonly SqlConnection connection = new
          SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString);
    }
}
