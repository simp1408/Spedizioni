using Spedizioni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedizioni.Controllers
{
    [Authorize]
    public class AziendeController : Controller
    {

        // GET: Aziende
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult ListAziende()
        {
          
            return View();
        }

        // GET: DETTAGLIO AZIENDA
        public ActionResult Details(int id) => View();

        // GET: INSERIMENTO AZIENDA
        public ActionResult RegistrazioneAzienda() => View();


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RegistrazioneAzienda(Aziende a)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
              
                SqlCommand command = new SqlCommand();
               
                command.Parameters.AddWithValue("@NomeAzienda", a.NomeAzienda);
                command.Parameters.AddWithValue("@PartitaIva",a.PartitaIva);
                command.Parameters.AddWithValue("@IndirizzoSede",a.IndirizzoSede );
                command.Parameters.AddWithValue("@Citta",a.Citta );
                command.CommandText = "INSERT INTO AZIENDE VALUES(@NomeAzienda,@PartitaIva,@IndirizzoSede,@Citta)";
                command.Connection = connection;

                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    ViewBag.MessaggioConferma = "Registrazione avvenuta con successo";
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

                connection.Close();
            }
            return View();
        }

        // GET:  MODIFICA AZIENDA
        public ActionResult Edit(int id) => View();

        // POST: MODIFICA AZIENDA
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

        // GET: CANCELLAZIONE AZIENDA
        public ActionResult Delete(int id) => View();

        // POST: CANCELLAZIONE AZIENDA
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
        
    }
}
