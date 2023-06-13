using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class MedieBLL
    {
        public ObservableCollection<Medie> MedieList { get; set; }

        MedieDAL medieDAL = new MedieDAL();

        public ObservableCollection<Medie> GetAllMedii()
        {
            return medieDAL.GetAllMedii();
        }

        public void AddMedie(Medie medie)
        {
            if (medie.StudentID == 0 || medie.MaterieID == 0)
            {
                throw new AgendaException("StudentID si MaterieID trebuie sa fie precizate");
            }

            medieDAL.AddMedie(medie);
            MedieList.Add(medie);
        }

        public void ModifyMedie(Medie medie)
        {
            if (medie == null)
            {
                throw new AgendaException("Trebuie selectata o medie");
            }
            if (medie.StudentID == 0 || medie.MaterieID == 0)
            {
                throw new AgendaException("StudentID si MaterieID trebuie sa fie precizate");
            }
            medieDAL.ModifyMedie(medie);
        }

        public void DeleteMedie(Medie medie)
        {
            if (medie == null)
            {
                throw new AgendaException("Trebuie selectata o medie!");
            }

            medieDAL.DeleteMedie(medie);
            MedieList.Remove(medie);
        }

    }
}
