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

        // public static Villain GeVillain(int id) {
        //     Villain villain = new Villain();

        //     using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
        //         conn.Open();

        //         using(SqlCommand command = new SqlCommand(string.Format("SELECT * FROM HERO WHERE HEROID = \'{0}\'", id), conn)){
        //             using(SqlDataReader reader = command.ExecuteReader()){
        //                 // we have a reader which has the data in it
        //                 while(reader.Read()){
        //                     hero.heroID = reader.GetInt32(0);
        //                     hero.Name = reader.GetString(1);
        //                     hero.minDice = reader.GetInt32(2);
        //                     hero.maxDice = reader.GetInt32(3);
        //                     hero.Uses = reader.GetInt32(4);
        //                 }
        //             }
        //         }
        //         conn.Close();
        //     }
        //     return hero;
        // }
    }
}