using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class StatoSpedizioni
    {
        public int IDstato { get; set; }

        public string InPreparazione { get; set; }

        public string InTransito { get; set; }
        public string InConsegna { get; set; }

        public string Consegnato { get; set; }

        public string Smarrito { get; set; }

        public static List<StatoSpedizioni> GetStatoSpedizioni()
        {
            List<StatoSpedizioni> statoSpedizioni = new List<StatoSpedizioni>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * from StatoSpedizioni";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   StatoSpedizioni statoSp=new StatoSpedizioni();
                    statoSp.IDstato = Convert.ToInt32(reader["IDstato"]);
                    statoSp.InPreparazione=reader["InPreparazione"].ToString();
                    statoSp.InTransito=reader["InTransito"].ToString();
                    statoSp.InConsegna=reader["InConsegna"].ToString();
                    statoSp.Consegnato=reader["Consegnato"].ToString();
                    statoSp.Smarrito=reader["Smarrito"].ToString();
                    statoSpedizioni.Add(statoSp);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return statoSpedizioni;
        }
    }
}

