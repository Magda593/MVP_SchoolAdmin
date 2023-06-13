using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class AbsentaDAL
    {
        public ObservableCollection<Absenta> GetAllAbsente()
        {
            SqlConnection con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsente", con);
                ObservableCollection<Absenta> result = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Absenta a = new Absenta();
                    a.ID = (int)reader["ID"];
                    a.StudentID = (string)reader["StudentID"];
                    a.MaterieID = (string)reader["MaterieID"];
                    a.DataAbsenta = (DateTime)reader["DataAbsenta"];
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

        public void AddAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudentID = new SqlParameter("@studentID", absenta.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", absenta.MaterieID);
                SqlParameter paramDataAbsenta = new SqlParameter("@data_absenta", absenta.DataAbsenta);
                
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramDataAbsenta);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter paramId = new SqlParameter("@id", absenta.ID);
                cmd.Parameters.Add(paramId);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter paramId = new SqlParameter("@id", absenta.ID);
                SqlParameter paramStudentID = new SqlParameter("@studentID", absenta.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", absenta.MaterieID);
                SqlParameter paramDataAbsenta = new SqlParameter("@data_absenta", absenta.DataAbsenta);
                
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramDataAbsenta);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
