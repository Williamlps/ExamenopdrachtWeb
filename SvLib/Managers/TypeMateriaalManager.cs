using SvLib.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SvLib.Managers
{
    public class TypeMateriaalManager
    {
        public static string ConnectionString { get; set; }

        public static List<TypeMateriaal> GetByTypeSport(int typeSportId)
        {
            List<TypeMateriaal> lijst = new List<TypeMateriaal>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, Naam, TypeSportId FROM TypeMateriaal WHERE TypeSportId = @TypeSportId";
                    objCmd.Parameters.AddWithValue("@TypeSportId", typeSportId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        TypeMateriaal tm = new TypeMateriaal();
                        if (objRea["Id"] != DBNull.Value)
                            tm.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Naam"] != DBNull.Value)
                            tm.Naam = objRea["Naam"].ToString();
                        if (objRea["TypeSportId"] != DBNull.Value)
                            tm.TypeSportId = Convert.ToInt32(objRea["TypeSportId"]);
                        lijst.Add(tm);
                    }
                }
            }
            return lijst;
        }
    }
}