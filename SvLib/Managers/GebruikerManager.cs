using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvLib.Managers
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class GebruikerManager
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["Cn"].ConnectionString;

        public static bool Login(string gebruikersnaam, string wachtwoord)
        {
            bool resultaat = false;
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT COUNT(*) FROM Gebruiker WHERE Gebruikersnaam = @Gebruikersnaam AND Wachtwoord = @Wachtwoord";
                    objCmd.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                    objCmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);
                    objCn.Open();
                    int count = Convert.ToInt32(objCmd.ExecuteScalar());
                    resultaat = count > 0;
                }
            }
            return resultaat;
        }
    }
}
