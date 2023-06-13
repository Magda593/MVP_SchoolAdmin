using MVP_Tema3.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace MVP_Tema3.Models.DataAccessLayer
{
    class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.ID = (int)reader["id"];
                    student.CNP = reader["CNP"].ToString();
                    student.Sex = reader["sex"].ToString();
                    student.Nume = reader["Nume"].ToString();
                    student.Prenume = reader["Prenume"].ToString();
                    student.Clasa = reader["Clasa"].ToString();
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CNP", student.CNP);
                cmd.Parameters.AddWithValue("@sex", student.Sex);
                cmd.Parameters.AddWithValue("@Nume", student.Nume);
                cmd.Parameters.AddWithValue("@Prenume", student.Prenume);
                cmd.Parameters.AddWithValue("@Clasa", student.Clasa);
                SqlParameter paramIdStudent = new SqlParameter("@Id", SqlDbType.Int);
                paramIdStudent.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
                student.ID = (int)paramIdStudent.Value;
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", student.ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudent(Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", student.ID);
                cmd.Parameters.AddWithValue("@CNP", student.CNP);
                cmd.Parameters.AddWithValue("@sex", student.Sex);
                cmd.Parameters.AddWithValue("@Nume", student.Nume);
                cmd.Parameters.AddWithValue("@Prenume", student.Prenume);
                cmd.Parameters.AddWithValue("@Clasa", student.Clasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
