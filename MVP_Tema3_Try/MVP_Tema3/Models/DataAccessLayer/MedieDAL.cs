using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class MedieDAL
    {
        public ObservableCollection<Medie> GetAllMedii()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMedii", con);
                ObservableCollection<Medie> result = new ObservableCollection<Medie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medie m = new Medie();
                    m.ID = (int)reader["id"];
                    m.StudentID = (int)reader["StudentID"];
                    m.MaterieID = (int)reader["MaterieID"];
                    m.Valoare = (int)reader["valoare"];
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddMedie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudentID = new SqlParameter("@studentID", medie.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", medie.MaterieID);
                SqlParameter paramValoare = new SqlParameter("@valoare", medie.Valoare);
                SqlParameter paramID = new SqlParameter("@medieID", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramValoare);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
                medie.ID = (int)paramID.Value;
            }
        }

        public void DeleteMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMedie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", medie.ID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyMedie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ID", medie.ID);
                SqlParameter paramStudentID = new SqlParameter("@studentID", medie.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", medie.MaterieID);
                SqlParameter paramValoare = new SqlParameter("@valoare", medie.Valoare);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramValoare);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
