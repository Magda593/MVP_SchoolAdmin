using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class MaterieDAL
    {
        public ObservableCollection<Materie> GetAllMaterii()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMaterii", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.ID = (int)reader["MaterieID"];
                    m.Nume = (string)reader["MaterieName"];
                    m.ProfesorName = (string)reader["ProfesorName"];
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

        public ObservableCollection<Materie> GetMaterieByProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetMaterieByProfesor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profesor", profesor);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Materie()
                        {
                            ID = (int)reader["id"],
                            Nume = reader["nume"].ToString(),
                            ProfesorName = (string)reader["ProfesorName"]
                }
                    );
                }
                reader.Close();
                return result;
            }
        }


        public void AddMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddMaterie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profesor", int.Parse(materie.ProfesorID));
                cmd.Parameters.AddWithValue("@Nume", materie.Nume);
                SqlParameter paramIdMaterie = new SqlParameter("@Id", SqlDbType.Int);
                paramIdMaterie.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
                materie.ID = (int)paramIdMaterie.Value;
            }

        }

        public void DeleteMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMaterie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id", materie.ID);
                cmd.Parameters.Add(paramIdMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyMaterie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@ID", materie.ID);
                SqlParameter paramNume = new SqlParameter("@Nume", materie.Nume);
                SqlParameter paramProfesorID = new SqlParameter("@Profesor", materie.ProfesorID);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramProfesorID);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


    }
}
