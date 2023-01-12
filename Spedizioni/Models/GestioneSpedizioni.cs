using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedizioni.Models
{
    public class GestioneSpedizioni
    {

        public int IDspedizione { get; set; }
        public string NomeDestinatario { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string CittaDestinazione { get; set; }
        public decimal Costo { get; set; }
        public decimal Peso { get; set; }

        public DateTime DataSpedizione { get; set; }
        public DateTime DataCosegna { get; set; }

        public int IdCliente { get; set; }
        public int IdAzienda { get; set; }

        public static List<GestioneSpedizioni> GetSpedizioni()
        {
            List<GestioneSpedizioni> ListaSpedizioni = new List<GestioneSpedizioni>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT* FROM SPEDIZIONI";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GestioneSpedizioni sp = new GestioneSpedizioni();
                    sp.IDspedizione = Convert.ToInt32(reader["IDspedizione"]);
                    sp.NomeDestinatario = reader["NomeDestinatario"].ToString();
                    sp.IndirizzoDestinatario = reader["IndirizzoDestinatario"].ToString();
                    sp.CittaDestinazione = reader["CittaDestinazione"].ToString();
                    sp.Costo = Convert.ToDecimal(reader["Costo"]);
                    sp.Peso = Convert.ToDecimal(reader["Peso"]);
                    sp.DataSpedizione = Convert.ToDateTime(reader["DataSpedizione"]);
                    sp.DataCosegna = Convert.ToDateTime(reader["DataConsegna"]);
                    sp.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    sp.IdAzienda = Convert.ToInt32(reader["IdAzienda"]);
                    ListaSpedizioni.Add(sp);

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return ListaSpedizioni;
        }
    }
}
