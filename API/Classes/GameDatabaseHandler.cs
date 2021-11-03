using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace API {
    public class GameDatabaseHandler:DatabaseHandler {

        public static string AddResult(Game newResult){
            // creates connection
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                // Creates command
                using (SqlCommand command = new SqlCommand("ADD_RESULT", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pRESULT", newResult.winner);
                    command.Parameters.AddWithValue("@pATTACKS", newResult.attacks);
                    command.Parameters.AddWithValue("@pDATE", newResult.date);
                    command.ExecuteNonQuery();

                }
                conn.Close();
            }
            return "Added Result";   
        }

        public static List<Game> GetGames(){

            List<Game> games = new List<Game>();
            // creates connection
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                // Creates command
                using (SqlCommand command = new SqlCommand("SELECT * FROM GAME", conn)) {

                    using(SqlDataReader reader = command.ExecuteReader()){
                        // we have a reader which has the data in it
                        while(reader.Read()){
                            games.Add(new Game(){winner = reader.GetString(0),
                                                  attacks = reader.GetString(1),
                                                  date = reader.GetDateTime(2)});
                        }
                    }
                }
                conn.Close();
            }
            return games;   
        }
    }
}