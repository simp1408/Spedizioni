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
    public class Privati
    {
        public int IDcliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Cod_fisc { get; set; }

        public string LuogoNascita { get; set; }

        public string Residenza { get; set; }

        public DateTime DataNascita { get; set; }

        public static List<Privati> GetListPrivati() 
        {
              List<Privati>ListaPrivati= new List<Privati>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * from PRIVATI";
                command.Connection = connection;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    Privati p = new Privati();
                    p.IDcliente = Convert.ToInt32(reader["IDcliente"]);
                    p.Nome = reader["Nome"].ToString() ;
                    p.Cognome = reader["Cognome"].ToString();
                    p.Cod_fisc = reader["Cod_fisc"].ToString();
                    p.LuogoNascita = reader["LuogoNascita"].ToString();
                    p.Residenza = reader["Residenza"].ToString();
                    p.DataNascita = Convert.ToDateTime(reader["DataNascita"]);
                    ListaPrivati.Add(p);

                }
            }
            catch(Exception ex) 
            {
                
            }
            finally {
                connection.Close(); 
            }
         
            return ListaPrivati;
       
        }

        public static List<SelectListItem> SelectCliente() 
        {
            List<SelectListItem> selectCliente = new List<SelectListItem>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();

             SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from Privati";
            command.Connection= connection;

            SqlDataReader reader= command.ExecuteReader();
            while(reader.Read()) 
            {
                SelectListItem selectItems = new SelectListItem
                {
                    Value = reader["IdCliente"].ToString(),
                    Text = reader["Nome"].ToString()+" "+ reader["Cognome"].ToString()
                };

                selectCliente.Add(selectItems);
            
            }
            return selectCliente;
        
        }
    }
}

