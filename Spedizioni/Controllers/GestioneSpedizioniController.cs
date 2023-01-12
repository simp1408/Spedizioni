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
    public class GestioneSpedizioniController : Controller
    {
        // GET: GestioneSpedizioni
        public ActionResult Index() => View();

        // GET: GestioneSpedizioni/Details/5
        public ActionResult Details(int id) => View();

        // GET: GestioneSpedizioni/Create
        public ActionResult AggiungiSpedizioni()
        {
            ViewBag.ListCliente = Privati.SelectCliente();
            return View();
        }

        // POST: GestioneSpedizioni/Create
        [HttpPost]
        public ActionResult AggiungiSpedizioni(GestioneSpedizioni sp)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try
            {
               

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@NomeDestinatario", sp.NomeDestinatario);
                command.Parameters.AddWithValue("@IndirizzoDestinatario", sp.IndirizzoDestinatario);
                command.Parameters.AddWithValue("@CittaDestinazione", sp.CittaDestinazione);
                command.Parameters.AddWithValue("@Costo", sp.Costo);
                command.Parameters.AddWithValue("@Peso", sp.Peso);
                command.Parameters.AddWithValue("@DataSpedizione", sp.DataSpedizione);
                command.Parameters.AddWithValue("@DataCosegna", sp.DataCosegna);
                command.Parameters.AddWithValue("@IdCliente", sp.IdCliente);
                command.Parameters.AddWithValue("@IdAzienda", sp.IdAzienda);
                command.CommandText = "INSERT INTO SPEDIZIONI VALUES(@NomeDestinatario,@IndirizzoDestinatario,@CittaDestinazione,@Costo,@Peso,@DataSpedizione,@DataConsegna,@IdCliente,@IdAzienda)";
                command.Connection= connection;

                int row=command.ExecuteNonQuery();
                if (row > 0) 
                {
                    ViewBag.ListCliente = Privati.SelectCliente();
                    ViewBag.MessaggioConferma = "Inserimento avvenuto con successo";
                }
              
            }
            catch(Exception ex)
            {
            }
            finally
            {
               connection.Close();
             }
            return View();
        }

        // GET: GestioneSpedizioni/Edit/5
        public ActionResult Edit(int id) => View();

        // POST: GestioneSpedizioni/Edit/5
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

        // GET: GestioneSpedizioni/Delete/5
        public ActionResult Delete(int id) => View();

        // POST: GestioneSpedizioni/Delete/5
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
