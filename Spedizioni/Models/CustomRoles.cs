using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace Spedizioni.Models
{
    public class CustomRoles : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) => throw new NotImplementedException();

        public override void CreateRole(string roleName) => throw new NotImplementedException();

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) => throw new NotImplementedException();

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) => throw new NotImplementedException();

        public override string[] GetAllRoles() => throw new NotImplementedException();
        //metodo che mi restituisce un array di tipo stringa
        public override string[] GetRolesForUser(string username)
        {
            List<String> Ruoli= new List<String>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Username",username );
                command.CommandText = " Select Ruolo FROM UTENTI where Username = @Username";
                command.Connection= connection;

                SqlDataReader reader= command.ExecuteReader();
                if(reader.HasRows)
                {
                    Ruoli.Add(reader["Ruolo"].ToString());
                }
            }catch(Exception ex)
            {

            }
            finally { 
                connection.Close(); 
            }
            //visto che il metodo mi restituisce un array di tipo stringa, trasformo la lista ruoli in array utilizzando ToArray()s
            return Ruoli.ToArray();
        }

        public override string[] GetUsersInRole(string roleName) => throw new NotImplementedException();

        public override bool IsUserInRole(string username, string roleName) => throw new NotImplementedException();

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) => throw new NotImplementedException();

        public override bool RoleExists(string roleName) => throw new NotImplementedException();
    }
}