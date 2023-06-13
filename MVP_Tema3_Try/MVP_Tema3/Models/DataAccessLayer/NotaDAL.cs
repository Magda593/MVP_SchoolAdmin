using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class NotaDAL
    {
        public ObservableCollection<Nota> GetAllNote()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllNote", con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.ID = (int)reader["id"];
                    n.StudentID = (string)reader["StudentID"];
                    n.MaterieID = (string)reader["MaterieID"];
                    n.DataNota = (string)reader["Data_nota"];
                    n.Valoare = (string)reader["Valoare"];
                    n.Teza = (string)reader["Teza"];
                    result.Add(n);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddNota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudentID = new SqlParameter("@studentID", nota.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", nota.MaterieID);
                SqlParameter paramDataNota = new SqlParameter("@dataNota", nota.DataNota);
                SqlParameter paramValoare = new SqlParameter("@valoare", nota.Valoare);
                SqlParameter paramTeza = new SqlParameter("@teza", nota.Teza);
                SqlParameter paramID = new SqlParameter("@notaID", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramDataNota);
                cmd.Parameters.Add(paramValoare);
                cmd.Parameters.Add(paramTeza);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
                nota.ID = (int)paramID.Value;
            }
        }

        public void DeleteNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteNota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", nota.ID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyNota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@ID", nota.ID);
                SqlParameter paramStudentID = new SqlParameter("@studentID", nota.StudentID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", nota.MaterieID);
                SqlParameter paramDataNota = new SqlParameter("@dataNota", nota.DataNota);
                SqlParameter paramValoare = new SqlParameter("@valoare", nota.Valoare);
                SqlParameter paramTeza = new SqlParameter("@teza", nota.Teza);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramStudentID);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramDataNota);
                cmd.Parameters.Add(paramValoare);
                cmd.Parameters.Add(paramTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
