using SvLib.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SvLib.Managers
{
    public class MateriaalMaatManager
    {
        public static string ConnectionString { get; set; }

        public static MateriaalMaat GetByMateriaalEnMaat(int materiaalId, int maatId)
        {
            MateriaalMaat mm = null;
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, MateriaalId, MaatId, Aantal FROM MateriaalMaat WHERE MateriaalId = @MateriaalId AND MaatId = @MaatId";
                    objCmd.Parameters.AddWithValue("@MateriaalId", materiaalId);
                    objCmd.Parameters.AddWithValue("@MaatId", maatId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    if (objRea.Read())
                    {
                        mm = new MateriaalMaat();
                        if (objRea["Id"] != DBNull.Value)
                            mm.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["MateriaalId"] != DBNull.Value)
                            mm.MateriaalId = Convert.ToInt32(objRea["MateriaalId"]);
                        if (objRea["MaatId"] != DBNull.Value)
                            mm.MaatId = Convert.ToInt32(objRea["MaatId"]);
                        if (objRea["Aantal"] != DBNull.Value)
                            mm.Aantal = Convert.ToInt32(objRea["Aantal"]);
                    }
                }
            }
            return mm;
        }

        public static int GetBeschikbaar(int materiaalId, int maatId, DateTime beginDatum, DateTime eindDatum)
        {
            int maxAantal = 0;
            int verhuurdAantal = 0;

            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Aantal FROM MateriaalMaat WHERE MateriaalId = @MateriaalId AND MaatId = @MaatId";
                    objCmd.Parameters.AddWithValue("@MateriaalId", materiaalId);
                    objCmd.Parameters.AddWithValue("@MaatId", maatId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    if (objRea.Read())
                    {
                        if (objRea["Aantal"] != DBNull.Value)
                            maxAantal = Convert.ToInt32(objRea["Aantal"]);
                    }
                }
            }

            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = @"SELECT ISNULL(SUM(um.Aantal), 0)
                                  FROM UitleningMateriaal um
                                  INNER JOIN MateriaalMaat mm ON mm.Id = um.MateriaalMaatId
                                  INNER JOIN Uitlening u ON u.Id = um.UitleningId
                                  WHERE mm.MateriaalId = @MateriaalId 
                                  AND mm.MaatId = @MaatId
                                  AND u.DatumUitlening <= @EindDatum 
                                  AND u.DatumInlevering >= @BeginDatum";
                    objCmd.Parameters.AddWithValue("@MateriaalId", materiaalId);
                    objCmd.Parameters.AddWithValue("@MaatId", maatId);
                    objCmd.Parameters.AddWithValue("@BeginDatum", beginDatum);
                    objCmd.Parameters.AddWithValue("@EindDatum", eindDatum);
                    objCn.Open();
                    verhuurdAantal = Convert.ToInt32(objCmd.ExecuteScalar());
                }
            }

            return maxAantal - verhuurdAantal;
        }
        public static void Insert(MateriaalMaat mm)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "INSERT INTO MateriaalMaat (MateriaalId, MaatId, Aantal) VALUES (@MateriaalId, @MaatId, @Aantal)";
                    objCmd.Parameters.AddWithValue("@MateriaalId", mm.MateriaalId);
                    objCmd.Parameters.AddWithValue("@MaatId", mm.MaatId);
                    objCmd.Parameters.AddWithValue("@Aantal", mm.Aantal);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAantal(int id, int aantal)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "UPDATE MateriaalMaat SET Aantal = @Aantal WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Aantal", aantal);
                    objCmd.Parameters.AddWithValue("@Id", id);
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
                    objCmd.CommandText = "DELETE FROM MateriaalMaat WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}