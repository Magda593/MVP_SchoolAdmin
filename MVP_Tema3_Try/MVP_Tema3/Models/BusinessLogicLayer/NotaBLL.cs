using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class NotaBLL
    {
        public ObservableCollection<Nota> NotaList { get; set; }

        NotaDAL notaDAL = new NotaDAL();

        public ObservableCollection<Nota> GetAllNote()
        {
            return notaDAL.GetAllNote();
        }

        public void AddNota(Nota nota)
        {
            if (string.IsNullOrEmpty(nota.StudentID) || string.IsNullOrEmpty(nota.MaterieID))
            {
                throw new AgendaException("StudentID si MaterieID trebuie sa fie precizate");
            }

            notaDAL.AddNota(nota);
            NotaList.Add(nota);
        }

        public void ModifyNota(Nota nota)
        {
            if (nota == null)
            {
                throw new AgendaException("Trebuie selectata o nota");
            }
            if (string.IsNullOrEmpty(nota.StudentID)  || string.IsNullOrEmpty(nota.MaterieID))
            {
                throw new AgendaException("StudentID si MaterieID trebuie sa fie precizate");
            }
            notaDAL.ModifyNota(nota);
        }

        public void DeleteNota(Nota nota)
        {
            if (nota == null)
            {
                throw new AgendaException("Trebuie selectata o nota!");
            }

            notaDAL.DeleteNota(nota);
            NotaList.Remove(nota);
        }

    }
}
