using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class MaterieBLL
    {
        public ObservableCollection<Materie> MaterieList { get; set; }

        MaterieDAL materieDAL = new MaterieDAL();

        public ObservableCollection<Materie> GetAllMaterii()
        {
            return materieDAL.GetAllMaterii();
        }

        public void AddMaterie(Materie materie)
        {
            if (string.IsNullOrEmpty(materie.Nume))
            {
                throw new AgendaException("Numele materiei trebuie sa fie precizat");
            }

            materieDAL.AddMaterie(materie);
            MaterieList.Add(materie);
        }

        public void ModifyMaterie(Materie materie)
        {
            if (materie == null)
            {
                throw new AgendaException("Trebuie selectata o materie");
            }
            if (string.IsNullOrEmpty(materie.Nume))
            {
                throw new AgendaException("Trebuie precizat numele materiei");
            }
            materieDAL.ModifyMaterie(materie);
        }

        public void DeleteMaterie(Materie materie)
        {
            if (materie == null)
            {
                throw new AgendaException("Trebuie selectata o materie!");
            }

            materieDAL.DeleteMaterie(materie);
            MaterieList.Remove(materie);
        }

    }
}
