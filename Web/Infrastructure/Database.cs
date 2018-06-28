﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data.Common;
    using System.Data.SqlClient;

    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            // _connection = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename=D:\\BrainWare\\Web\\App_Data\\BrainWare.mdf");
            //Server = localhost; Database = master; Trusted_Connection = True;
            _connection = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename=D:\\Users\\sblackmore\\BrainWare\\Web\\App_Data\\BrainWare.mdf");

            _connection.Open();
        }


        public DbDataReader ExecuteReader(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}