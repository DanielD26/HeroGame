using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace API
{
    public class DatabaseHandler
    {
        public static string GetConnectionString() {
            try {
                // Connects API to database
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "database-1.cdtpahc1o8go.us-east-1.rds.amazonaws.com";
                builder.UserID = "admin";
                builder.Password = "password1";
                builder.InitialCatalog = "HeroGame";
                return builder.ConnectionString;
            }
            catch(Exception e) {
                throw new Exception("Error in GetConnectionString(): " + e.Message);
            }
        }
    }
}
