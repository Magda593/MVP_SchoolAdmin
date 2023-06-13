using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class StudentBLL
    {
        public ObservableCollection<Student> StudentsList { get; set; }

        StudentDAL studentDAL = new StudentDAL();

        public ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Nume))
            {
                throw new AgendaException("Numele studentului trebuie sa fie precizat");
            }
            studentDAL.AddStudent(student);
            StudentsList.Add(student);
        }

        public void ModifyStudent(Student student)
        {
            if (student == null)
            {
                throw new AgendaException("Trebuie selectat un student");
            }
            if (string.IsNullOrEmpty(student.Nume))
            {
                throw new AgendaException("Trebuie precizat numele studentului");
            }
            studentDAL.ModifyStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new AgendaException("Trebuie selectat un student!");
            }
            //else
            //{
            //    NotaDAL notaDAL = new NotaDAL();
            //    if (notaDAL.GetAllGradesForStudent(student).Count > 0)
            //    {
            //        throw new AgendaException("Nu se poate sterge studentul deoarece are note asociate.");
            //    }
            //}
            studentDAL.DeleteStudent(student);
            StudentsList.Remove(student);
        }

    }
}
