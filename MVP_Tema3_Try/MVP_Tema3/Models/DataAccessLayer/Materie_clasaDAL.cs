using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class Materie_clasaDAL
    {
        public ObservableCollection<Materie_clasa> GetAllMaterieClasa()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMaterieClasa", con);
                ObservableCollection<Materie_clasa> result = new ObservableCollection<Materie_clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie_clasa mc = new Materie_clasa();
                    mc.ID = (int)reader[0];
                    mc.MaterieID = (int)reader[1];
                    mc.ClasaID = (int)reader[2];
                    mc.AreTeza = (bool)reader[3];
                    result.Add(mc);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddMaterieClasa(Materie_clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddMaterieClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramMaterieID = new SqlParameter("@materieID", materieClasa.MaterieID);
                SqlParameter paramClasaID = new SqlParameter("@clasaID", materieClasa.ClasaID);
                SqlParameter paramAreTeza = new SqlParameter("@areTeza", materieClasa.AreTeza);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramClasaID);
                cmd.Parameters.Add(paramAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMaterieClasa(Materie_clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMaterieClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterieClasa = new SqlParameter("@id", materieClasa.ID);
                cmd.Parameters.Add(paramIdMaterieClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyMaterieClasa(Materie_clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyMaterieClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterieClasa = new SqlParameter("@materieClasaID", materieClasa.ID);
                SqlParameter paramMaterieID = new SqlParameter("@materieID", materieClasa.MaterieID);
                SqlParameter paramClasaID = new SqlParameter("@clasaID", materieClasa.ClasaID);
                SqlParameter paramAreTeza = new SqlParameter("@areTeza", materieClasa.AreTeza);
                cmd.Parameters.Add(paramIdMaterieClasa);
                cmd.Parameters.Add(paramMaterieID);
                cmd.Parameters.Add(paramClasaID);
                cmd.Parameters.Add(paramAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
