using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    public class An_studiuDAL
    {
        public ObservableCollection<An_studiu> GetAllAnStudiu()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAnStudiu", con);
                ObservableCollection<An_studiu> result = new ObservableCollection<An_studiu>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    An_studiu a = new An_studiu();
                    a.ID = (int)reader["id"];
                    a.An = reader["an"].ToString();
                    result.Add(a);
                }
                
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddAnStudiu(An_studiu anStudiu)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAnStudiu", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("An", anStudiu.An);
                SqlParameter paramIdAnStudiu = new SqlParameter("@specId", SqlDbType.Int);
                paramIdAnStudiu.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdAnStudiu);
                
                con.Open();
                cmd.ExecuteNonQuery();
                
                anStudiu.ID = (int)paramIdAnStudiu.Value;
            }
        }

        public void DeleteAnStudiu(An_studiu anStudiu)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAnStudiu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter paramId = new SqlParameter("@id", anStudiu.ID);
                cmd.Parameters.Add(paramId);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyAnStudiu(An_studiu anStudiu)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyAnStudiu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter paramId = new SqlParameter("@specId", anStudiu.ID);
                SqlParameter paramAn = new SqlParameter("@an", anStudiu.An);
               
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramAn);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
