using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Aziende
    {
        public int IDazienda { get; set; }

        public string NomeAzienda { get; set; }
        public string PartitaIva { get; set; }

        public string IndirizzoSede { get; set; }

        public string Citta { get; set; }

        public  static List<Aziende> GetListAziende()
        {
            List<Aziende>ListAziende= new List<Aziende>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * from AZIENDE";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   Aziende a = new Aziende();
                    a.IDazienda = Convert.ToInt32(reader["IDazienda"]);
                    a.NomeAzienda = reader["NomeAzienda"].ToString();
                    a.PartitaIva = reader["PartitaIva"].ToString() ;
                    a.IndirizzoSede = reader["IndirizzoSede"].ToString();
                    a.Citta = reader["Citta"].ToString() ;
                    ListAziende.Add(a);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ListAziende;
        }
    }
}

