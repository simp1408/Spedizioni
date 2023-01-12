using Spedizioni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Spedizioni.Controllers
{
    [Authorize]
    public class PrivatiController : Controller
    {
        // GET: Privati
        public ActionResult Index() => View();

        public ActionResult ListPrivati() => View(Privati.GetListPrivati());


        // GET: DETTAGLI
        public ActionResult Details(int id) => View();

        // GET: INSERIMENTO
        public ActionResult RegistrazionePrivati() => View();

        // POST: INSERIMENTO
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult RegistrazionePrivati(Privati p)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
                //SCRIVERE CONNESSIONI E QUERY INSERT
              
                SqlCommand command = new SqlCommand();
               
                command.Parameters.AddWithValue("@Nome", p.Nome);
                command.Parameters.AddWithValue("@Cognome", p.Cognome);
                command.Parameters.AddWithValue("@Cod_fisc", p.Cod_fisc);
                command.Parameters.AddWithValue("@LuogoNascita", p.LuogoNascita);
                command.Parameters.AddWithValue("@Residenza", p.Residenza);
                command.Parameters.AddWithValue("@DataNascita", p.DataNascita);
                command.CommandText = "INSERT INTO PRIVATI VALUES(@Nome,@Cognome,@Cod_fisc,@LuogoNascita,@Residenza,@DataNascita)";
                command.Connection= connection;

                int row=command.ExecuteNonQuery();
                if(row > 0) 
                {
                    ViewBag.MessaggioConferma = "Registrazione avvenuta con successo";
                }

               
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                
                connection.Close();
            }
            return RedirectToAction("ListaPrivati");
        }

        // GET: MODIFICA
        public ActionResult Edit(int id) => View();

        // POST: MODIFICA
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CANCELLAZIONE
        public ActionResult Delete(int id) => View();

        // POST: CANCELLAZIONE
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult QueryDatabase()
        {

            return View();
        }

        public JsonResult GetAllPrivati()
        {

            List<Privati> ListaPrivati = new List<Privati>();
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
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.Cod_fisc = reader["Cod_fisc"].ToString();
                    p.LuogoNascita = reader["LuogoNascita"].ToString();
                    p.Residenza = reader["Residenza"].ToString();
                    p.DataNascita = Convert.ToDateTime(reader["DataNascita"]);
                    ListaPrivati.Add(p);

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Json(ListaPrivati, JsonRequestBehavior.AllowGet);

        }

    
    }
}
