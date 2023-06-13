using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace MVP_Tema3.Models.DataAccessLayer
{
    class ProfesorDAL
    {
        public ObservableCollection<Profesor> GetAllProfesori()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProfesori", con);
                ObservableCollection<Profesor> result = new ObservableCollection<Profesor>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor profesor = new Profesor();
                    profesor.ID = (int)reader["id"];
                    profesor.CNP = reader.GetString(1);
                    profesor.Sex = reader.GetString(2);
                    profesor.Nume = reader.GetString(3);
                    profesor.Prenume = reader.GetString(4);
                    result.Add(profesor);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProfesor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCNP = new SqlParameter("@cnp", profesor.CNP);
                SqlParameter paramSex = new SqlParameter("@sex", profesor.Sex);
                SqlParameter paramNume = new SqlParameter("@nume", profesor.Nume);
                SqlParameter paramPrenume = new SqlParameter("@prenume", profesor.Prenume);
                SqlParameter paramIdprofesor = new SqlParameter("@Id", SqlDbType.Int);
                paramIdprofesor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramCNP);
                cmd.Parameters.Add(paramSex);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                cmd.Parameters.Add(paramIdprofesor);
                con.Open();
                cmd.ExecuteNonQuery();
                profesor.ID = (int)paramIdprofesor.Value;
            }
        }

        public void DeleteProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProfesor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", profesor.ID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProfesor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id", profesor.ID);
                SqlParameter paramCNP = new SqlParameter("@cnp", profesor.CNP);
                SqlParameter paramSex = new SqlParameter("@sex", profesor.Sex);
                SqlParameter paramNume = new SqlParameter("@nume", profesor.Nume);
                SqlParameter paramPrenume = new SqlParameter("@prenume", profesor.Prenume);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramCNP);
                cmd.Parameters.Add(paramSex);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPrenume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
