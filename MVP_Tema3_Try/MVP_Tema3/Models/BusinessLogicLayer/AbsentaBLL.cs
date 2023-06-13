using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    public class AbsentaBLL
    {
        public ObservableCollection<Absenta> AbsentaList { get; set; }

        AbsentaDAL absentaDAL = new AbsentaDAL();

        public ObservableCollection<Absenta> GetAllAbsente()
        {
            return absentaDAL.GetAllAbsente();
        }

        public void AddAbsenta(Absenta absenta)
        {
            if (string.IsNullOrEmpty(absenta.StudentID) || string.IsNullOrEmpty(absenta.MaterieID))
            {
                throw new AgendaException("StudentID si MaterieID trebuie precizate");
            }

            absentaDAL.AddAbsenta(absenta);
            AbsentaList.Add(absenta);
        }

        public void ModifyAbsenta(Absenta absenta)
        {
            if (absenta == null)
            {
                throw new AgendaException("Trebuie selectata o absenta");
            }
            if (string.IsNullOrEmpty(absenta.StudentID) || string.IsNullOrEmpty(absenta.MaterieID))
            {
                throw new AgendaException("StudentID si MaterieID trebuie precizate");
            }
            absentaDAL.ModifyAbsenta(absenta);
        }

        public void DeleteAbsenta(Absenta absenta)
        {
            if (absenta == null)
            {
                throw new AgendaException("Trebuie precizata o absenta!");
            }
            absentaDAL.DeleteAbsenta(absenta);
            AbsentaList.Remove(absenta);
        }

    }
}
