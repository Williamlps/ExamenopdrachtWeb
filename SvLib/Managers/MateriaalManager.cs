using SvLib.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SvLib.Managers
{
    public class MateriaalManager
    {
        public static string ConnectionString { get; set; }

        public static List<Materiaal> GetByTypeEnMerk(int typeMateriaalId, int merkId)
        {
            List<Materiaal> lijst = new List<Materiaal>();
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = @"SELECT Id, Model, MerkId, TypeMateriaalId, Foto 
                                          FROM Materiaal 
                                          WHERE TypeMateriaalId = @TypeMateriaalId AND MerkId = @MerkId";
                    objCmd.Parameters.AddWithValue("@TypeMateriaalId", typeMateriaalId);
                    objCmd.Parameters.AddWithValue("@MerkId", merkId);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    while (objRea.Read())
                    {
                        Materiaal m = new Materiaal();
                        if (objRea["Id"] != DBNull.Value)
                            m.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Model"] != DBNull.Value)
                            m.Model = objRea["Model"].ToString();
                        if (objRea["MerkId"] != DBNull.Value)
                            m.MerkId = Convert.ToInt32(objRea["MerkId"]);
                        if (objRea["TypeMateriaalId"] != DBNull.Value)
                            m.TypeMateriaalId = Convert.ToInt32(objRea["TypeMateriaalId"]);
                        if (objRea["Foto"] != DBNull.Value)
                            m.Foto = objRea["Foto"].ToString();
                        lijst.Add(m);
                    }
                }
            }
            return lijst;
        }

        public static Materiaal GetById(int id)
        {
            Materiaal materiaal = null;
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "SELECT Id, Model, MerkId, TypeMateriaalId, Foto FROM Materiaal WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    SqlDataReader objRea = objCmd.ExecuteReader();
                    if (objRea.Read())
                    {
                        materiaal = new Materiaal();
                        if (objRea["Id"] != DBNull.Value)
                            materiaal.Id = Convert.ToInt32(objRea["Id"]);
                        if (objRea["Model"] != DBNull.Value)
                            materiaal.Model = objRea["Model"].ToString();
                        if (objRea["MerkId"] != DBNull.Value)
                            materiaal.MerkId = Convert.ToInt32(objRea["MerkId"]);
                        if (objRea["TypeMateriaalId"] != DBNull.Value)
                            materiaal.TypeMateriaalId = Convert.ToInt32(objRea["TypeMateriaalId"]);
                        if (objRea["Foto"] != DBNull.Value)
                            materiaal.Foto = objRea["Foto"].ToString();
                    }
                }
            }
            return materiaal;
        }

        public static void Insert(Materiaal materiaal)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "INSERT INTO Materiaal (Model, MerkId, TypeMateriaalId, Foto) VALUES (@Model, @MerkId, @TypeMateriaalId, @Foto)";
                    objCmd.Parameters.AddWithValue("@Model", materiaal.Model);
                    objCmd.Parameters.AddWithValue("@MerkId", materiaal.MerkId);
                    objCmd.Parameters.AddWithValue("@TypeMateriaalId", materiaal.TypeMateriaalId);
                    objCmd.Parameters.AddWithValue("@Foto", (object)materiaal.Foto ?? DBNull.Value);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Materiaal materiaal)
        {
            using (SqlConnection objCn = new SqlConnection())
            {
                objCn.ConnectionString = ConnectionString;
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCn;
                    objCmd.CommandText = "UPDATE Materiaal SET Model = @Model, MerkId = @MerkId, TypeMateriaalId = @TypeMateriaalId, Foto = @Foto WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Model", materiaal.Model);
                    objCmd.Parameters.AddWithValue("@MerkId", materiaal.MerkId);
                    objCmd.Parameters.AddWithValue("@TypeMateriaalId", materiaal.TypeMateriaalId);
                    objCmd.Parameters.AddWithValue("@Foto", (object)materiaal.Foto ?? DBNull.Value);
                    objCmd.Parameters.AddWithValue("@Id", materiaal.Id);
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
                    objCmd.CommandText = "DELETE FROM Materiaal WHERE Id = @Id";
                    objCmd.Parameters.AddWithValue("@Id", id);
                    objCn.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }
    }
}