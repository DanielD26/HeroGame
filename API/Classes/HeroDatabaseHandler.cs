using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace API {
    public class HeroDatabaseHandler:DatabaseHandler {

        public static List<Hero> GetHeroes(){

            List<Hero> heroes = new List<Hero>();
            // creates connection
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                // Creates command
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

        public static Hero GetHero(int id) {
            Hero hero = new Hero();

            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand(string.Format("SELECT * FROM HERO WHERE HEROID = \'{0}\'", id), conn)){
                    using(SqlDataReader reader = command.ExecuteReader()){
                        // we have a reader which has the data in it
                        while(reader.Read()){
                            hero.heroID = reader.GetInt32(0);
                            hero.Name = reader.GetString(1);
                            hero.minDice = reader.GetInt32(2);
                            hero.maxDice = reader.GetInt32(3);
                            hero.Uses = reader.GetInt32(4);
                        }
                    }
                }
                conn.Close();
            }
            return hero;
        }

        public static string AddHero(Hero newHero) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){
                conn.Open();

                using(SqlCommand command = new SqlCommand("ADD_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", newHero.heroID);
                    command.Parameters.AddWithValue("@pNAME", newHero.Name);
                    command.Parameters.AddWithValue("@pMINDICE", newHero.minDice);
                    command.Parameters.AddWithValue("@pMAXDICE", newHero.maxDice);
                    command.Parameters.AddWithValue("@pUSES", newHero.Uses);
                    command.ExecuteNonQuery();
                    
                    conn.Close();                 
                    
                }
            }
            return "Created Hero";
        }

        public static string UpdateHero(Hero hero) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("UPDATE_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", hero.heroID);
                    command.Parameters.AddWithValue("@pNAME", hero.Name);
                    command.Parameters.AddWithValue("@pMINDICE", hero.minDice);
                    command.Parameters.AddWithValue("@pMAXDICE", hero.maxDice);
                    command.Parameters.AddWithValue("@pUSES", hero.Uses);
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            return "Updated Hero";
        }

        public static string DeleteHero(Hero hero) {
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("DELETE_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", hero.heroID);
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            return "Deleted Hero";
        }
    }
}