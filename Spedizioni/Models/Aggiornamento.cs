using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Aggiornamento
    {
        public int IDaggiornamento { get; set; }
        public DateTime DataAggiornamento { get; set; }

        public string Descrizione { get; set; }

        public string Luogo { get; set; }

        public int IdStato { get; set; }
        public int IdSpedizione { get; set; }

        public static List<Aggiornamento> GetAggiornamento()
        {
            List<Aggiornamento> ListaAggiornamenti = new List<Aggiornamento>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * from Aggiornamenti";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Aggiornamento aggiornamento= new Aggiornamento();
                    aggiornamento.IDaggiornamento = Convert.ToInt32(reader["IDaggiornamento"]);
                    aggiornamento.DataAggiornamento = Convert.ToDateTime(reader["DataAggiornamento"]);
                    aggiornamento.Descrizione = reader["Descrizione"].ToString();
                    aggiornamento.Luogo = reader["Luogo"].ToString();
                    aggiornamento.IdStato = Convert.ToInt32(reader["IdStato"]);
                    aggiornamento.IdSpedizione = Convert.ToInt32(reader["IdSpedizione"]);
                  
                    ListaAggiornamenti.Add(aggiornamento);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ListaAggiornamenti;
        }
    }
}

