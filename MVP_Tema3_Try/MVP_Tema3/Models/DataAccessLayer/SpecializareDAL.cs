using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace MVP_Tema3.Models.DataAccessLayer
{
    class SpecializareDAL
    {
        public ObservableCollection<Specializare> GetAllSpecializari()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecializari", con);
                ObservableCollection<Specializare> result = new ObservableCollection<Specializare>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Specializare s = new Specializare();
                    s.ID = (int)reader[0];
                    s.Nume = reader.GetString(1);
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSpecializare", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", specializare.Nume);
                SqlParameter paramIdSpecializare = new SqlParameter("@specId", SqlDbType.Int);
                paramIdSpecializare.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
                specializare.ID = paramIdSpecializare.Value as int?;
            }
        }

        public void DeleteSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecializare", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSpecializare = new SqlParameter("@id", specializare.ID);
                cmd.Parameters.Add(paramIdSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySpecializare", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdSpecializare = new SqlParameter("@specId", specializare.ID);
                SqlParameter paramNume = new SqlParameter("@nume", specializare.Nume);
                cmd.Parameters.Add(paramIdSpecializare);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
