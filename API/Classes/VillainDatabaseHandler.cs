using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace API {
    public class VillainDatabaseHandler:DatabaseHandler {

        public static List<Villain> GetVillains(){

            List<Villain> villains = new List<Villain>();
            // creates connection
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                // Creates command
                using (SqlCommand command = new SqlCommand("SELECT * FROM VILLAIN", conn)) {

                    using(SqlDataReader reader = command.ExecuteReader()){
                        // we have a reader which has the data in it
                        while(reader.Read()){
                            villains.Add(new Villain(){villainID = reader.GetInt32(0),
                                                    Name = reader.GetString(1)});
                        }
                    }
                }
                conn.Close();
            }
            return villains;   
        }

        public static string AddVillain(Villain newVillain) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();
                
                using(SqlCommand command = new SqlCommand("ADD_VILLAIN", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pVILLAINID", newVillain.villainID);
                    command.Parameters.AddWithValue("@pNAME", newVillain.Name);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Added Villain";
        }

        public static string UpdateVillain(Villain villain) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("UPDATE_VILLAIN", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pVILLAINID", villain.villainID);
                    command.Parameters.AddWithValue("@pNAME", villain.Name);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Updated Villain";
        }

        public static string DeleteVillain(Villain villain) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("DELETE_VILLAIN", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pVILLAINID", villain.villainID);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return "Deleted Villain";
        }

    }
}