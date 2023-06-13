using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class SpecializareBLL
    {
        public ObservableCollection<Specializare> SpecializariList { get; set; }

        SpecializareDAL specializareDAL = new SpecializareDAL();

        public ObservableCollection<Specializare> GetAllSpecializari()
        {
            return specializareDAL.GetAllSpecializari();
        }

        public void AddSpecializare(Specializare specializare)
        {
            if (string.IsNullOrEmpty(specializare.Nume))
            {
                throw new AgendaException("Numele specializarii trebuie specificat");
            }
            specializareDAL.AddSpecializare(specializare);
            SpecializariList.Add(specializare);
        }

        public void ModifySpecializare(Specializare specializare)
        {
            if (specializare == null)
            {
                throw new AgendaException("Trebuie selectata o specializare");
            }
            if (string.IsNullOrEmpty(specializare.Nume))
            {
                throw new AgendaException("Trebuie precizat numele specializarii");
            }
            specializareDAL.ModifySpecializare(specializare);
        }

        public void DeleteSpecializare(Specializare specializare)
        {
            if (specializare == null)
            {
                throw new AgendaException("Trebuie selectata o specializare!");
            }
            specializareDAL.DeleteSpecializare(specializare);
            SpecializariList.Remove(specializare);
        }

    }
}
