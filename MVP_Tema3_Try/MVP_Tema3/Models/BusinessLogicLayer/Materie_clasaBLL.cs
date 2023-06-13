using MVP_Tema3.Exceptions;
using MVP_Tema3.Models.DataAccessLayer;
using MVP_Tema3.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace MVP_Tema3.Models.BusinessLogicLayer
{
    class Materie_clasaBLL
    {
        public ObservableCollection<Materie_clasa> MaterieClasaList { get; set; }

        Materie_clasaDAL materieClasaDAL = new Materie_clasaDAL();

        public ObservableCollection<Materie_clasa> GetAllMaterieClasa()
        {
            return materieClasaDAL.GetAllMaterieClasa();
        }

        public void AddMaterieClasa(Materie_clasa materieClasa)
        {
            if (materieClasa.MaterieID == 0 || materieClasa.ClasaID == 0)
            {
                throw new AgendaException("Trebuie selectata o materie si o clasa pentru adaugarea in tabela Materie_clasa!");
            }

            materieClasaDAL.AddMaterieClasa(materieClasa);
            MaterieClasaList.Add(materieClasa);
        }

        public void ModifyMaterieClasa(Materie_clasa materieClasa)
        {
            if (materieClasa == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare din tabela Materie_clasa");
            }
            if (materieClasa.MaterieID == 0 || materieClasa.ClasaID == 0)
            {
                throw new AgendaException("Trebuie selectata o materie si o clasa pentru modificarea inregistrarii din tabela Materie_clasa!");
            }
            materieClasaDAL.ModifyMaterieClasa(materieClasa);
        }

        public void DeleteMaterieClasa(Materie_clasa materieClasa)
        {
            if (materieClasa == null)
            {
                throw new AgendaException("Trebuie selectata o inregistrare din tabela Materie_clasa!");
            }
            materieClasaDAL.DeleteMaterieClasa(materieClasa);
            MaterieClasaList.Remove(materieClasa);
        }

    }
}
