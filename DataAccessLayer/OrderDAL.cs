namespace DataAccessLayer
{
    using BusinessModel;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class OrderDAL
    {
        public List<Order> GetOrders()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);
            var values = new List<Order>();
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("dbo.GetOrdersForCompany", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;

                        values.Add(new Order()
                        {
                            CompanyName = record.GetString(0),
                            Description = record.GetString(1),
                            OrderId = record.GetInt32(2),
                            OrderProducts = new List<OrderProduct>()
                        });
                    }
                }
            }
            return values;
        }

        public List<OrderProduct> GetOrderProducts(string query)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);
            var values = new List<OrderProduct>();
            using (connection)
            {
                connection.Open();

                var sqlQuery = new SqlCommand(query, connection);

                using (SqlDataReader reader = sqlQuery.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;

                        values.Add(new OrderProduct()
                        {
                            OrderId = record.GetInt32(1),
                            ProductId = record.GetInt32(2),
                            Price = record.GetDecimal(0),
                            Quantity = record.GetInt32(3),
                            Product = new Product()
                            {
                                Name = record.GetString(4),
                                Price = record.GetDecimal(5)
                            }
                        });
                    }
                }
            }
            return values;
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
