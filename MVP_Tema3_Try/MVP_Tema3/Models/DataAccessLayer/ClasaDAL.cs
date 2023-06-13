using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Tema3.Models.DataAccessLayer
{
    class ClasaDAL
    {
        public ObservableCollection<Clasa> GetAllClasa()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasa", con);
                ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa c = new Clasa();
                    c.ID = (int)reader["ClasaID"];
                    c.DiriginteNume = (string)reader["DirigintaName"];
                    c.AnStudiu = reader["AnStudiu"].ToString();
                    c.SpecializareNume = (string)reader["SpecializarezNume"];
                    c.Nume = reader["Nume"].ToString();
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        //public ObservableCollection<Clasa> GetClaseBySpecializare(Specializare specializare)
        //{
        //    using (SqlConnection con = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("GetClaseBySpecializare", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramSpecializare = new SqlParameter("@specializare", specializare);
        //        cmd.Parameters.Add(paramSpecializare);

        //        ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();

        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Clasa c = new Clasa();
        //            c.ID = (int)reader["id"];
        //            c.DiriginteID = (int)reader["DiriginteID"];
        //            c.AnStudiuID = (int)reader["An_StudiuID"];
        //            c.SpecializareID = (int)reader["SpecializareID"];
        //            c.Nume = reader["Nume"].ToString();

        //            result.Add(c);
        //        }
        //        reader.Close();

        //        return result;
        //    }
        //}


        //public ObservableCollection<Clasa> GetClassesByMaterie(Materie materie)
        //{
        //    using (SqlConnection con = DALHelper.Connection)
        //    {
        //        SqlCommand cmd = new SqlCommand("GetClassesByMaterie", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@materie", materie);
        //        ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            result.Add(
        //                new Clasa()
        //                {
        //                    ID = (int)reader["id"],
        //                    Nume = reader["nume"].ToString(),
        //                    DiriginteID = (string)reader["diriginteID"]
        //                }
        //            );
        //        }
        //        reader.Close();
        //        return result;
        //    }
        //}

        public void AddClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@diriginteID", int.Parse(clasa.DiriginteID));
                //cmd.Parameters.AddWithValue("@An_StudiuID", int.Parse(clasa.AnStudiuID));
                //cmd.Parameters.AddWithValue("@specializareID", int.Parse(clasa.SpecializareID));
                //cmd.Parameters.AddWithValue("Nume", clasa.Nume);
                //SqlParameter paramIdClasa = new SqlParameter("@Id", SqlDbType.Int);
                //paramIdClasa.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(paramIdClasa);


                SqlParameter paramDiriginteID = new SqlParameter("@DiriginteID", int.Parse(clasa.DiriginteID));
                SqlParameter paramAnStudiuID = new SqlParameter("@An_StudiuID", int.Parse(clasa.AnStudiuID));
                SqlParameter paramSpecializareID = new SqlParameter("@SpecializareID", int.Parse(clasa.SpecializareID));
                SqlParameter paramNume = new SqlParameter("@Nume", clasa.Nume);
                SqlParameter paramIdClasa = new SqlParameter("@id", SqlDbType.Int);
                paramIdClasa.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramDiriginteID);
                cmd.Parameters.Add(paramAnStudiuID);
                cmd.Parameters.Add(paramSpecializareID);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramIdClasa);
                con.Open();
                cmd.ExecuteNonQuery();
                clasa.ID = (int)paramIdClasa.Value;

            }
        }

        public void DeleteClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", clasa.ID);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@ClasaID", clasa.ID);
                SqlParameter paramDiriginteID = new SqlParameter("@DiriginteID", clasa.DiriginteID);
                SqlParameter paramAnStudiuID = new SqlParameter("@An_StudiuID", clasa.AnStudiuID);
                SqlParameter paramSpecializareID = new SqlParameter("@SpecializareID", clasa.SpecializareID);
                SqlParameter paramNume = new SqlParameter("@Nume", clasa.Nume);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDiriginteID);
                cmd.Parameters.Add(paramAnStudiuID);
                cmd.Parameters.Add(paramSpecializareID);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


    }
}
