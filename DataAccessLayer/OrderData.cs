namespace DataAccessLayer
{
    using System.Configuration;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class OrderData
    {
        //private readonly SqlConnection _connection = new
        //  SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString());

        public DbDataReader ExecuteReader(string query)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlQuery = new SqlCommand(query, connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlQuery = new SqlCommand(query, connection);

            return sqlQuery.ExecuteNonQuery();
        }
    }
}
