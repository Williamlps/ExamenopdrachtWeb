using SvLib.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SvLib.Managers
{
    public class MerkManager
    {
        public static string ConnectionString { get; set; }

        public static List<Merk> GetByTypeMateriaal(int typeMateriaalId)
        {
            List<Merk> lijst = new List<Merk>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = @"SELECT DISTINCT m.Id, m.Naam 
                                          FROM Merk m
                                          INNER JOIN Materiaal mat ON mat.MerkId = m.Id
                                          WHERE mat.TypeMateriaalId = @TypeMateriaalId
                                          ORDER BY m.Naam";
                    objCmd.Parameters.AddWithValue("@TypeMateriaalId", typeMateriaalId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        Merk m = new Merk();
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

        public static List<Merk> GetAll()
        {
            List<Merk> lijst = new List<Merk>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, Naam FROM Merk ORDER BY Naam";
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        Merk m = new Merk();
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

        public static Merk GetById(int id)
        {
            Merk merk = null;
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, Naam FROM Merk WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    if (objRea.Read())
                    {
                        merk = new Merk();
                        if (objRea["Id"] != DBNull.Value)
                            merk.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Naam"] != DBNull.Value)
                            merk.Naam = objRea["Naam"].ToString();
                    }
                }
            }
            return merk;
        }

        public static void Insert(Merk merk)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "INSERT INTO Merk (Naam) VALUES (@Naam)";
                    objCmd.Parameters.AddWithValue("@Naam", merk.Naam);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Merk merk)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "UPDATE Merk SET Naam = @Naam WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Naam", merk.Naam);
                    objCmd.Parameters.AddWithValue("@Id", merk.Id);
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
                    objCmd.CommandText = "DELETE FROM Merk WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}