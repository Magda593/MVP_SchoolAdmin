using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class ClasaBLL
    {
        public ObservableCollection<Clasa> ClasaList { get; set; }

        ClasaDAL clasaDAL = new ClasaDAL();

        public ObservableCollection<Clasa> GetAllClasa()
        {
            return clasaDAL.GetAllClasa();
        }

        public void AddClasa(Clasa clasa)
        {
            if (string.IsNullOrEmpty(clasa.DiriginteID) || string.IsNullOrEmpty(clasa.AnStudiuID) || string.IsNullOrEmpty(clasa.SpecializareID) || string.IsNullOrEmpty(clasa.Nume))
            {
                throw new AgendaException("Trebuie completate toate campurile pentru adaugarea unei clase!");
            }

            clasaDAL.AddClasa(clasa);
            ClasaList.Add(clasa);
        }

        public void ModifyClasa(Clasa clasa)
        {
            if (clasa == null)
            {
                throw new AgendaException("Trebuie selectata o clasa");
            }
            if (string.IsNullOrEmpty(clasa.DiriginteID) || string.IsNullOrEmpty(clasa.AnStudiuID) || string.IsNullOrEmpty(clasa.SpecializareID) || string.IsNullOrEmpty(clasa.Nume))
            {
                throw new AgendaException("Trebuie completate toate campurile pentru modificarea clasei!");
            }
            clasaDAL.ModifyClasa(clasa);
        }

        public void DeleteClasa(Clasa clasa)
        {
            if (clasa == null)
            {
                throw new AgendaException("Trebuie precizata o clasa!");
            }
            clasaDAL.DeleteClasa(clasa);
            ClasaList.Remove(clasa);
        }

    }
}
