using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Utenti
    {
        public int IDutente { get; set; }

        public string Username { get; set; }

        public string  Password { get; set; }
        public string Ruoli  { get; set; }

        public static List<Utenti> GetUtenti()
        {
            List<Utenti> ListaUtenti= new List<Utenti>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try {

                SqlCommand command = new SqlCommand();
                command.CommandText = "Select * from Utenti";
                command.Connection= connection;

                SqlDataReader reader= command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Utenti u= new  Utenti();
                        u.IDutente = Convert.ToInt32(reader["IDutente"]);
                        u.Username= reader["Username"].ToString();
                        u.Password = reader["password"].ToString();
                        ListaUtenti.Add(u); 
                    }
                }
            }
            catch(Exception ex) { }
            finally { connection.Close(); 
            }
            return ListaUtenti;
        }
    }
}