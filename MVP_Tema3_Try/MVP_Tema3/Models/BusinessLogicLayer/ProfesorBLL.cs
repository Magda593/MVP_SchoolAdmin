using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class ProfesorBLL
    {
        public ObservableCollection<Profesor> ProfesoriList { get; set; }

        ProfesorDAL profesorDAL = new ProfesorDAL();

        public ObservableCollection<Profesor> GetAllProfesori()
        {
            return profesorDAL.GetAllProfesori();
        }

        public void AddProfesor(Profesor profesor)
        {
            if (string.IsNullOrEmpty(profesor.Nume) || string.IsNullOrEmpty(profesor.Prenume))
            {
                throw new AgendaException("Numele si prenumele profesorului trebuie sa fie precizate");
            }
            profesorDAL.AddProfesor(profesor);
            ProfesoriList.Add(profesor);
        }

        public void ModifyProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                throw new AgendaException("Trebuie selectat un profesor");
            }
            if (string.IsNullOrEmpty(profesor.Nume) || string.IsNullOrEmpty(profesor.Prenume))
            {
                throw new AgendaException("Numele si prenumele profesorului trebuie sa fie precizate");
            }
            profesorDAL.ModifyProfesor(profesor);
        }

        public void DeleteProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                throw new AgendaException("Trebuie selectat un profesor!");
            }
            else
            {
                
                MaterieDAL materieDAL = new MaterieDAL();
                if (materieDAL.GetMaterieByProfesor(profesor).Count > 0)
                {
                    throw new AgendaException("Nu se poate șterge profesorul deoarece este asociat cu cursuri existente.");
                }
            }
            profesorDAL.DeleteProfesor(profesor);
            ProfesoriList.Remove(profesor);
        }

    }
}
