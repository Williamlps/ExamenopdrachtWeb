using SvLib.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SvLib.Managers
{
    public class MaatManager
    {
        public static string ConnectionString { get; set; }

        public static List<Maat> GetByMateriaal(int materiaalId)
        {
            List<Maat> lijst = new List<Maat>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = @"SELECT m.Id, m.Naam 
                                          FROM Maat m
                                          INNER JOIN MateriaalMaat mm ON mm.MaatId = m.Id
                                          WHERE mm.MateriaalId = @MateriaalId";
                    objCmd.Parameters.AddWithValue("@MateriaalId", materiaalId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        Maat m = new Maat();
                        if (objRea["Id"] != DBNull.Value)
                            m.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Naam"] != DBNull.Value)
                            m.Naam = objRea["Naam"].ToString();
                        lijst.Add(m);
                    }
                }
            }
            return lijst;
        }

        public static List<Maat> GetAll()
        {
            List<Maat> lijst = new List<Maat>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, Naam FROM Maat ORDER BY Naam";
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        Maat m = new Maat();
                        if (objRea["Id"] != DBNull.Value)
                            m.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Naam"] != DBNull.Value)
                            m.Naam = objRea["Naam"].ToString();
                        lijst.Add(m);
                    }
                }
            }
            return lijst;
        }

        public static void Insert(Maat maat)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "INSERT INTO Maat (Naam) VALUES (@Naam)";
                    objCmd.Parameters.AddWithValue("@Naam", maat.Naam);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Maat maat)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "UPDATE Maat SET Naam = @Naam WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Naam", maat.Naam);
                    objCmd.Parameters.AddWithValue("@Id", maat.Id);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "DELETE FROM Maat WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}