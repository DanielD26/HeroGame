using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace API
{
    public static class DatabaseHandler
    {
        static string GetConnectionString() {
            try {
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
            
         public static List<Hero> GetHeroes(){

            List<Hero> heroes = new List<Hero>();

            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM HERO", conn)) {

                    using(SqlDataReader reader = command.ExecuteReader()){
                        // we have a reader which has the data in it
                        while(reader.Read()){
                            heroes.Add(new Hero(){heroID = reader.GetInt32(0),
                                                            Name = reader.GetString(1),
                                                            minDice = reader.GetInt32(2),
                                                            maxDice = reader.GetInt32(3),
                                                            Uses = reader.GetInt32(4)});
                        }
                    }
                }
                conn.Close();
            }
            return heroes;   
        }  

    }
}
